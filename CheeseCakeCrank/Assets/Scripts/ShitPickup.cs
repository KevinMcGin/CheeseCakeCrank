using UnityEngine;
using System.Collections;

public class ShitPickup : Pickup
{

    public float timerCops;
    CountDown count;
    public Rigidbody policemanPrefab;
    // Use this for initialization
    void Start ()
    {
        count = new CountDown();
        count.StartTimer(timerCops);

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (count.timerDone())
        {
            Rigidbody police = Instantiate(policemanPrefab);
            police.GetComponent<Policeman>().DogComplain();
        }
    }
}
