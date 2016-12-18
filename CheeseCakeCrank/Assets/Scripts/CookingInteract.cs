using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CookingInteract : MonoBehaviour {

    CountDown interactionTimer = new CountDown();
    CookingProp prop;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
       if(interactionTimer.timerDone())
        {
            GetComponent<PlayerController>().setInteracting(false);
            prop.FinishInteracting(ref GetComponent<Inventory>().items);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "CookingInteraction")
        {
            if (Input.GetAxis("Interact") > 0)
            {
                CookingProp propLocal = col.gameObject.GetComponent<CookingProp>();
                if (propLocal.Interact(ref GetComponent<Inventory>().items))
                {
                    prop = propLocal;
                    interactionTimer.StartTimer(prop.GetTimer());
                    GetComponent<PlayerController>().setInteracting(true);

                    GetComponent<PlayerController>().SetHolding(false);

                    GetComponent<Inventory>().RemoveItem();
                }
            }
        }
    }
}
