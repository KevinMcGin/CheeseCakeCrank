using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    public GameObject jehovah;
    public Phone phone; 

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Distractions());
	}

    IEnumerator Distractions()
    {
        yield return new WaitForSeconds(Random.Range(5, 8));
        while (true)
        {
            //Phone
            PhoneDistraction();
            yield return new WaitForSeconds(Random.Range(5,12));
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
        phone.Ring();
    }
}
