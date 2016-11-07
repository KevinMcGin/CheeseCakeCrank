using UnityEngine;
using System.Collections;

public class JehovahsWitness : CrankCaller
{

    // Public fields
    public AudioClip doorbellSound;
    [Range(0.0f, 1.0f)] public float doorbellVolume;
    public int numDoorbellPressesToAttempt;
    public float waitSecondsBetweenDoorbellAttempts;
    public Rigidbody policemanPrefab;
    public float policeCallDurationSeconds;

    // Private fields
    private int currentDoorbellPresses;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();
        currentDoorbellPresses = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Horrific else ifs: implement state pattern please
        if (state.CompareTo("arriving") == 0)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, doorstep.transform.position, step);
        }
        else if (state.CompareTo("pressing doorbell") == 0)
        {
            source.PlayOneShot(doorbellSound, doorbellVolume);
            currentDoorbellPresses++;
            setState("waiting");
            StartCoroutine(DealWithDoor());
        }
        else if (state.CompareTo("waiting") == 0)
        {
            // Do nothing!
        }
        else if (state.CompareTo("passively aggressively worry") == 0)
        {
            setState("calling police");
            StartCoroutine(CallPolice());
        }
        else if (state.CompareTo("calling police") == 0)
        {
            // Do nothing!
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
            setState("pressing doorbell");
            // Start timer and do other stuff here
            // Repeatedly press doorbell X number of times
            // Wait Y seconds been presses
            // Eventually give up and go away
            
            // That's when things escalate
        }
        else if(other.CompareTag(spawnPointTag))
        {
            if(state.CompareTo("departing") == 0)
                Destroy(this.gameObject);
        }
    }

    IEnumerator DealWithDoor()
    {
        yield return new WaitForSeconds(waitSecondsBetweenDoorbellAttempts);
        if (currentDoorbellPresses < numDoorbellPressesToAttempt)
        {
            setState("pressing doorbell");
        }
        else
            setState("passively aggressively worry");
    }
    
    IEnumerator CallPolice()
    {
        yield return new WaitForSeconds(policeCallDurationSeconds);
        Instantiate(policemanPrefab);
        setState("departing");
    }
}