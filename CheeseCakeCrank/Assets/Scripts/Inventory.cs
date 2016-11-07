using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Inventory : MonoBehaviour {

    public List<string> items = new List<string>();

	// Use this for initialization
	void Start ()
    {
	}

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "PickUp")
        {
            if(Input.GetAxis("Interact") > 0)
            {
                items.Add(col.GetComponent<Pickup>().item);
                col.GetComponent<Pickup>().Collect();

                //change player animation
            }
        }
    }
}
