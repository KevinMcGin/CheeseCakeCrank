using UnityEngine;
using System.Collections;

public class Phone : MonoBehaviour {

    CountDown timer = new CountDown();
    float timePhoneRings = 10;

    public AudioClip phonePickUpSound;
    public AudioClip phonePutDownSound;
    public AudioClip callerSound;
    public AudioClip[] sonVoices;
    public Rigidbody policemanPrefab;

    AudioSource source;

    enum state
    {
        idle,ringing,onPhone
    };
    state stateThis = state.idle;

    // Use this for initialization
    void Start ()
    {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public IEnumerator Ring()
    {
        if (stateThis == state.idle)
        {
            //Audio
            source.clip = callerSound;
            source.loop = true;
            source.Play();
            stateThis = state.ringing;
            FindObjectOfType<Instruction>().GetPhone();

            yield return new WaitForSeconds(timePhoneRings);
            if (stateThis == state.ringing)
            {
                source.Stop();

                //call cops
                Rigidbody police = Instantiate(policemanPrefab);
                police.GetComponent<Policeman>().PhoneComplain();
            }

        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" &&
            stateThis == state.ringing &&
            Input.GetButtonDown("Interact"))
        {
            StartCoroutine(Call());
        }
    }

    IEnumerator Call()
    {
        GetComponent<AudioSource>().PlayOneShot(callerSound);
        stateThis = state.ringing;
        FindObjectOfType<PlayerController>().setInteracting(true);
        source.clip = phonePickUpSound;
        source.loop = false;
        source.Play();

        yield return new WaitForSeconds(1);
        source.clip = sonVoices[Random.Range(0, sonVoices.Length - 1)];
        source.Play();

        yield return new WaitForSeconds(1);
        source.clip = phonePutDownSound;
        source.Play();

        yield return new WaitForSeconds(.1f);
        FindObjectOfType<PlayerController>().setInteracting(false);
        stateThis = state.idle;
    }

}
