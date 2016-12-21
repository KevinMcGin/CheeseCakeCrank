using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    public GameObject jehovah;
    public Phone phone;
    public Dog dog;

    float minWaitDistraction = 15;
    float maxWaitDistraction = 15;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Distractions());
	}

    IEnumerator Distractions()
    {
        while (true)
        {
            PhoneDistraction();
            yield return new WaitForSeconds(Random.Range(minWaitDistraction, maxWaitDistraction));
            //Phone
            PhoneDistraction();
            yield return new WaitForSeconds(Random.Range(minWaitDistraction, maxWaitDistraction));
            //Dog poo
            DogDistraction();
            yield return new WaitForSeconds(Random.Range(minWaitDistraction, maxWaitDistraction));
            //Jehovah
            JehovahDistraction();
        }
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
    void JehovahDistraction()
    {
        GameObject.Instantiate<GameObject>(jehovah);
    }
    void PhoneDistraction()
    {
        StartCoroutine(phone.Ring());
    }
    void DogDistraction()
    {
        dog.Shit();
    }
}
