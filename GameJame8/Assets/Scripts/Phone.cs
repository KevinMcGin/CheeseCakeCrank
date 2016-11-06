using UnityEngine;
using System.Collections;

public class Phone : MonoBehaviour {

    CountDown timer = new CountDown();

    public AudioClip phoneSound;
    public AudioClip callerSound;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void Ring()
    {
        //Audio
        GetComponent<AudioSource>().PlayOneShot(phoneSound);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(Input.GetAxis("Interact") > 0)
            {
                GetComponent<AudioSource>().PlayOneShot(callerSound);
            }
        }
    }

}
