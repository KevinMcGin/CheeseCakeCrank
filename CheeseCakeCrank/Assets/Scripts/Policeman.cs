using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.CopStates;

public class Policeman : CrankCaller
{

    // Public fields
    public AudioClip doorThumpSound;
    [Range(0.2f, 1.0f)] public float doorThumpVolume;
    public AudioClip doorSmashSound;
    [Range(0.2f, 1.0f)] public float doorSmashVolume;
    public int numDoorThumpsToAttempt;
    public float waitSecondsBetweenDoorThumpAttempts;
    public string playerTag;
    public float statementDurationSeconds;
    public int currentDoorThumps;
    public PoliceState state1;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();
        FindObjectOfType<Instruction>().Police();
        state1 = new PoliceArriving(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueText)
        {
            dialogueText.transform.position = Camera.main.WorldToScreenPoint(transform.position) +
                new Vector3(0, 100 * (float)Screen.height / (float)768);
        }
        state1.DoState();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(doorstepTag))
        {
            state1.FirstArriving();
        }
        else if (other.CompareTag(playerTag))
        {
            state1.StartStatement();
        }
        else if (other.CompareTag(spawnPointTag))
        {
            state1.Leave();
        }
    }

    public void PhoneComplain()
    {
        dialogueText.GetComponent<Text>().text = "You're alive, answer your phone!";
    }
    public void DogComplain()
    {
        dialogueText.GetComponent<Text>().text = "Clean up after your dog";
    }
    public void DoorComplain()
    {
        dialogueText.GetComponent<Text>().text = "Answer your door, you could've been dead!";
    }

    public IEnumerator DealWithDoor()
    {
        yield return new WaitForSeconds(waitSecondsBetweenDoorThumpAttempts);
        if (currentDoorThumps < numDoorThumpsToAttempt)
        {
            state1 = new PoliceThumpingDoor(this);
        }
        else
            state1 = new PoliceSmashingState(this);
    }

    public IEnumerator TakeStatement()
    {
        dialogueText.SetActive(true);
        source.clip = talkingSounds[Random.Range(0, talkingSounds.Length - 1)];
        source.Play();
        yield return new WaitForSeconds(statementDurationSeconds);
        state1 = new PoliceDeparting(this);
        FindObjectOfType<PlayerController>().setInteracting(false);
        Destroy(dialogueText);
    }
}