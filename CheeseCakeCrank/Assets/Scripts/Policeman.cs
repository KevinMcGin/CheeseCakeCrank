using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

    // Private fields
    private int currentDoorThumps;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();
        FindObjectOfType<Instruction>().Police();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueText)
        {
            dialogueText.transform.position = Camera.main.WorldToScreenPoint(transform.position) +
                new Vector3(0, 100 * (float)Screen.height / (float)768);
        }

        // Horrific else ifs: implement state pattern please
        if (state.CompareTo("arriving") == 0)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, doorstep.transform.position, step);
        }
        else if (state.CompareTo("thumping door") == 0)
        {
            source.PlayOneShot(doorThumpSound, doorThumpVolume);
            currentDoorThumps++;
            setState("waiting");
            StartCoroutine(DealWithDoor());
        }
        else if (state.CompareTo("waiting") == 0)
        {
            // Do nothing!
        }
        else if (state.CompareTo("smashing door") == 0)
        {
            source.PlayOneShot(doorSmashSound, doorSmashVolume);
            setState("chasing player");
        }
        else if (state.CompareTo("chasing player") == 0)
        {
            float step = speed * Time.deltaTime;
            // To Do: set this to actual player position
            Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            transform.position = Vector3.MoveTowards(transform.position, playerPos, step);
        }
        else if (state.CompareTo("request statement") == 0)
        {
            setState("taking statement");
            StartCoroutine(TakeStatement());
        }
        else if (state.CompareTo("taking statement") == 0)
        {
            FindObjectOfType<PlayerController>().setInteracting(true);
        }
        else if(state.CompareTo("departing") == 0)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, spawnPoint, step);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(doorstepTag))
        {
            if (state.CompareTo("arriving") == 0)
                setState("thumping door");
        }
        else if (other.CompareTag(playerTag))
        {
            if (state.CompareTo("chasing player") == 0)
            {
                setState("request statement");
                // To Do: lock "other" player gameObject so that it has to wait while giving statement
            }
        }
        else if (other.CompareTag(spawnPointTag))
        {
            if (state.CompareTo("departing") == 0)
            {
                Destroy(this.gameObject);
            }
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

    IEnumerator DealWithDoor()
    {
        yield return new WaitForSeconds(waitSecondsBetweenDoorThumpAttempts);
        if (currentDoorThumps < numDoorThumpsToAttempt)
        {
            setState("thumping door");
        }
        else
            setState("smashing door");
    }

    IEnumerator TakeStatement()
    {
        dialogueText.SetActive(true);
        source.clip = talkingSounds[Random.Range(0, talkingSounds.Length - 1)];
        source.Play();
        yield return new WaitForSeconds(statementDurationSeconds);
        setState("departing");
        FindObjectOfType<PlayerController>().setInteracting(false);
        Destroy(dialogueText);
    }
}