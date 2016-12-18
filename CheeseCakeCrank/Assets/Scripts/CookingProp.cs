using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CookingProp : MonoBehaviour {
    
    public float timer;

    public string[] itemsNeeded;

    public string[] itemsReturn;

    bool used = false;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public float GetTimer()
    {
        return timer;
    }

    public bool Interact(ref List<string> items)
    {

        if(used)
        {
            return false;
        }
        for(int i = 0; i < itemsNeeded.Length; i++)
        {
            if(!items.Contains(itemsNeeded[i]))
            {
                return false;
            }
        }
        for (int i = 0; i < itemsNeeded.Length; i++)
        {
            items.Remove(itemsNeeded[i]);
        }
        return true;
    }

    public void FinishInteracting(ref List<string> items)
    {
        for (int i = 0; i < itemsReturn.Length; i++)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().PickUpItem(itemsReturn[i]);
        }
        used = true;
    }
}
