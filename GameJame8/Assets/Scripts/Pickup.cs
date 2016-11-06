using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public string item;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void Collect()
    {
        gameObject.SetActive(false);
    }
}
