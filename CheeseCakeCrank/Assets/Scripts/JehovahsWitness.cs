using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.JehovahStates;

public class JehovahsWitness : CrankCaller
{

    // Public fields
    public AudioClip doorbellSound;
    [Range(0.0f, 1.0f)]
    public float doorbellVolume;
    public int numDoorbellPressesToAttempt;
    public float waitSecondsBetweenDoorbellAttempts;
    public Rigidbody policemanPrefab;
    public float policeCallDurationSeconds;
    public float TalkDurationSeconds;
    public int currentDoorbellPresses;

    public JehovahState state1;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        currentDoorbellPresses = 0;
        state1 = new JehovahArriving(this);
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

    public bool AtDoor()
    {
        return state1.isDoor();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(doorstepTag) && state.CompareTo("arriving") == 0 )
        {
            state1 = new JehovahPressingDoorbell(this);
            // Start timer and do other stuff here
            // Repeatedly press doorbell X number of times
            // Wait Y seconds been presses
            // Eventually give up and go away

            // That's when things escalate
        }
        else if (other.CompareTag(spawnPointTag))
        {
            state1.Leave();
        }
    }

    public IEnumerator DealWithDoor()
    {
        yield return new WaitForSeconds(waitSecondsBetweenDoorbellAttempts);
        state1.FirstArriving();
    }

    public IEnumerator CallPolice()
    {
        yield return new WaitForSeconds(policeCallDurationSeconds);
        Rigidbody police = Instantiate(policemanPrefab);
        police.GetComponent<Policeman>().DoorComplain();
        state1 = new JehovahDeparting(this);
    }

    public IEnumerator Talk()
    {
        source.clip = talkingSounds[Random.Range(0, talkingSounds.Length - 1)];
        source.Play();
        FindObjectOfType<PlayerController>().setInteracting(true);
        state1 = new JehovahTalking(this);
        dialogueText.GetComponent<Text>().text = "Have you heard the good news?";
        dialogueText.SetActive(true);

        yield return new WaitForSeconds(TalkDurationSeconds);
        FindObjectOfType<PlayerController>().setInteracting(false);
        dialogueText.SetActive(false);
        state1 = new JehovahDeparting(this);
    }
}