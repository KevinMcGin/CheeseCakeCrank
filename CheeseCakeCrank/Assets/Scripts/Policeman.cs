using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.CopStates;
using Assets.Scripts.CopStates.ChaseStates;

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
    public Transform[] goToPostitions;
    public PlayerRoom roomOfPlayer;

    public PoliceState state;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();
        FindObjectOfType<Instruction>().Police();
        state = new PoliceArriving(this,new ChaseRoom1(state));

        roomOfPlayer = FindObjectOfType<PlayerRoom>();
        goToPostitions = new Transform[roomOfPlayer.Rooms.Length];
        for (int i = 0; i < roomOfPlayer.Rooms.Length;i++)
        {
            //Child of 1 and 3 has more accurate position, bit hacky
            if (i != 1 && i != 3)
            {
                goToPostitions[i] = roomOfPlayer.Rooms[i].transform;
            }
            else
            {
                goToPostitions[i] = roomOfPlayer.Rooms[i].transform.GetChild(0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueText)
        {
            dialogueText.transform.position = Camera.main.WorldToScreenPoint(transform.position) +
                new Vector3(0, 100 * (float)Screen.height / (float)768);
        }
        state.DoState();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(doorstepTag))
        {
            state.FirstArriving();
        }
        else if (other.CompareTag(playerTag))
        {
            state.StartStatement();
        }
        else if (other.CompareTag(spawnPointTag))
        {
            state.Die();
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
            state = new PoliceThumpingDoor(this,state.chaseState);
        }
        else
            state = new PoliceSmashingState(this,state.chaseState);
    }

    public IEnumerator TakeStatement()
    {
        dialogueText.SetActive(true);
        source.clip = talkingSounds[Random.Range(0, talkingSounds.Length - 1)];
        source.Play();
        yield return new WaitForSeconds(statementDurationSeconds);
        state = new PoliceLeaveHouse(this, state.chaseState);
        FindObjectOfType<PlayerController>().setInteracting(false);
        Destroy(dialogueText);
    }
}