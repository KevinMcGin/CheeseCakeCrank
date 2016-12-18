using UnityEngine;
using System.Collections.Generic;
using System;


public class Inventory : MonoBehaviour {

    public List<string> items = new List<string>();
    public List<GameObject> sprites;
    public List<string> spriteNames;
    GameObject itemRenderer;

    // Use this for initialization
    void Start ()
    {

    }

    void Update()
    {
        if(Input.GetAxis("Drop") > 0 && items.Count > 0)
        {
            DropItem();
        }
    }

    public void DropItem()
    {
        itemRenderer.transform.parent = null;
        itemRenderer.AddComponent<Pickup>();
        itemRenderer.GetComponent<Pickup>().item = items[0];
        itemRenderer.AddComponent<BoxCollider>();
        itemRenderer.GetComponent<BoxCollider>().isTrigger = true;
        foreach(SpriteRenderer s in itemRenderer.GetComponentsInChildren<SpriteRenderer>())
        {
            s.sortingOrder = 1;
        }
        itemRenderer.GetComponent<SpriteRenderer>().sortingOrder = 0;

        itemRenderer.tag = "PickUp";

        items.Remove(items[0]);

        GetComponent<PlayerController>().SetHolding(false);

        itemRenderer = null;

    }

    public void RemoveItem()
    {
        Destroy(itemRenderer);
    }

    public bool PickUpItem(string itemName)
    {
        if (spriteNames.Contains(itemName))
        {
            items.Add(itemName);

            //change player animation
            GetComponent<PlayerController>().SetHolding(true);
            itemRenderer = GameObject.Instantiate<GameObject>(sprites[spriteNames.IndexOf(itemName)]);
            itemRenderer.transform.parent = this.transform;
            itemRenderer.transform.localPosition = itemRenderer.transform.position;
            itemRenderer.transform.localScale = new Vector3(itemRenderer.transform.localScale.x * this.transform.transform.localScale.x,
            itemRenderer.transform.localScale.y * this.transform.transform.localScale.y,
            itemRenderer.transform.localScale.z * this.transform.transform.localScale.z);
            return true;
        }
        else
        {
            print("Error: Pickup doesn't exist: " + itemName);
            return false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(Input.GetAxis("PickUp") > 0 &&
            col.tag == "PickUp" && 
            items.Count == 0)
        {
            if(PickUpItem(col.GetComponent<Pickup>().item))
            {
                col.gameObject.GetComponent<Pickup>().Collect();
            }            
        }
    }
}
