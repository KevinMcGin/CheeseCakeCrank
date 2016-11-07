using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour {

    enum DogState
    {
        Sitting1,
        Sitting2,
        SittingOutside,
        Outside        
    };

    public AudioClip shitSound;

    DogState state;

    CountDown timerMove = new CountDown();
    CountDown timerOutside = new CountDown();
    CountDown timerShit = new CountDown();

    float timeStay = 6;
    float timeOutside = 15;
    float timeShit = 5;

    float speed = 5;

    public GameObject sit1;
    public GameObject sit2;
    public GameObject sitOutside;
    public GameObject outSide;

    public GameObject shit;

    // Use this for initialization
    void Start ()
    {
        timerMove.StartTimer(timeStay);
        timerOutside.StartTimer(timeOutside);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(state == DogState.Sitting1)
        {
            transform.position = Vector3.MoveTowards(transform.position, sit1.transform.position, speed * Time.deltaTime);
        }
        else if (state == DogState.Sitting2)
        {
            transform.position = Vector3.MoveTowards(transform.position, sit2.transform.position, speed * Time.deltaTime);
        }
        else if (state == DogState.SittingOutside)
        {
            transform.position = Vector3.MoveTowards(transform.position, sitOutside.transform.position, speed * Time.deltaTime);
        }
        else if (state == DogState.Outside)
        {
            transform.position = Vector3.MoveTowards(transform.position, outSide.transform.position, speed * Time.deltaTime);
        }

        if(state != DogState.SittingOutside && state != DogState.Outside)
        {
            if(timerOutside.timerDone())
            {
                state = DogState.SittingOutside;
                timerShit.StartTimer(timeShit);
            }
            else if(timerMove.timerDone())
            {
                timerMove.StartTimer(timeStay);
                if (state == DogState.Sitting1)
                {
                    state = DogState.Sitting2;
                }
                else if (state == DogState.Sitting2)
                {
                    state = DogState.Sitting1;
                }
            }
        }
        else if(state == DogState.SittingOutside)
        {
            if (timerShit.timerDone())
            {
                state = DogState.Sitting1;
                timerMove.StartTimer(timeStay);
                timerOutside.StartTimer(timeOutside);

                //Take shit
                GameObject shitObject = GameObject.Instantiate<GameObject>(shit);
                shitObject.transform.position = transform.position;
                GetComponent<AudioSource>().PlayOneShot(shitSound);
            }
        }

    }

    public void GoOutside()
    {
        state = DogState.Outside;
    }
}
