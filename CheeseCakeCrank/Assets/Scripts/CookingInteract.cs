using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CookingInteract : MonoBehaviour {
    // Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "CookingInteraction")
        {
            if (Input.GetButtonDown("Interact"))
            {
                CookingProp prop = col.gameObject.GetComponent<CookingProp>();
                if (prop.Interact(ref GetComponent<Inventory>().items))
                {
                    GetComponent<PlayerController>().SetHolding(false);
                    GetComponent<Inventory>().RemoveItem();
                }
                else if(GetComponent<Inventory>().items.Count == 0)
                {
                    prop.TakeCake();
                }
            }
        }
    }
}
