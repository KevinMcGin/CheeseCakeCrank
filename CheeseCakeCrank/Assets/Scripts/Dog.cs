using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour {

    enum DogState
    {
        Sitting1,
        Sitting2  
    };

    public AudioClip shitSound;
    public AudioClip barkSound;

    AudioSource source;

    DogState state;

    CountDown timerMove = new CountDown();

    float timeStay = 6;
    float speed = 5;
    float minWaitBark = 5;
    float maxWaitBark = 15;

    public GameObject sit1;
    public GameObject sit2;
    public GameObject shit;

    // Use this for initialization
    void Start ()
    {
        timerMove.StartTimer(timeStay);
        source = gameObject.AddComponent<AudioSource>();
        StartCoroutine(Bark());
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

        if(timerMove.timerDone())
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

    public void Shit()
    {
        //Take shit
        GameObject shitObject = GameObject.Instantiate<GameObject>(shit);
        shitObject.transform.position = transform.position;
        source.PlayOneShot(shitSound);
        FindObjectOfType<Instruction>().DogPooSink();
    }

    IEnumerator Bark()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitBark, maxWaitBark));
            source.PlayOneShot(barkSound);
        }
    }
}
