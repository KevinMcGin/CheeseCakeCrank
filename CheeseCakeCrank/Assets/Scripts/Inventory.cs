using UnityEngine;
using System.Collections.Generic;
using System;


public class Inventory : MonoBehaviour {

    enum dir
    {
        left,right,up,down
    };

    public List<string> items = new List<string>();
    public List<GameObject> sprites;
    public List<string> spriteNames;
    public GameObject itemRenderer;
    Vector3 centerPos;
    Vector3 sideDist;
    dir dirThis;

    AudioSource source;
    public AudioClip PickUpSound;
    public AudioClip PutDownSound;
    public AudioClip PooSound;

    // Use this for initialization
    void Start ()
    {
        sideDist = new Vector3(1.7f, 1.1f);
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetAxis("Drop") > 0 && items.Count > 0 && itemRenderer)
        {
            DropItem();
        }
    }

    public void DropItem()
    {
        itemRenderer.transform.parent = null;
        if (items[0] == "Shit")
        {
            itemRenderer.GetComponent<ShitPickup>().enabled = true;
            source.clip = PooSound;
            source.Play();
        }
        else
        {
            itemRenderer.AddComponent<Pickup>();
            itemRenderer.GetComponent<Pickup>().item = items[0];
            source.clip = PutDownSound;
            source.Play();
        }
        itemRenderer.AddComponent<BoxCollider>();
        itemRenderer.GetComponent<BoxCollider>().isTrigger = true;
        foreach(SpriteRenderer s in itemRenderer.GetComponentsInChildren<SpriteRenderer>())
        {
            s.sortingOrder = 1;
        }
        itemRenderer.GetComponent<SpriteRenderer>().sortingOrder = 0;

        itemRenderer.tag = "PickUp";

        if(items[0] == "BakedBiscuit")
        {
            FindObjectOfType<Instruction>().GetWisk();
        }
        else if (items[0] == "BakeCake")
        {
            FindObjectOfType<Instruction>().GetLemon();
        }
        else if (items[0] == "LemonToppedToCool")
        {
            itemRenderer.transform.FindChild("Biscuit").GetComponent<CoolCake>().PutDown();
            FindObjectOfType<Instruction>().GetCake();
        }
        items.Remove(items[0]);

        GetComponent<PlayerController>().SetHolding(false);

        itemRenderer = null;

    }

    public void RemoveItem()
    {
        Destroy(itemRenderer);
        itemRenderer = null;
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

            centerPos = itemRenderer.transform.localPosition;

            if(dirThis == dir.left)
            {
                LeftMoving();
            }
            else if (dirThis == dir.right)
            {
                RightMoving();
            }
            else if (dirThis == dir.down)
            {
                DownMoving();
            }
            else if (dirThis == dir.up)
            {
                UpMoving();
            }

            if(itemName == "Wisk")
            {
                FindObjectOfType<Instruction>().WiskCheese();
            }
            else if(itemName == "Lemon")
            {
                FindObjectOfType<Instruction>().FryLemon();
            }
            else if (itemName == "LemonToppedToCool")
            {
                FindObjectOfType<Instruction>().DropCoolCake();
            }

            if (itemName == "Shit")
            {
                source.clip = PooSound;
                source.Play();
            }
            else
            {
                source.clip = PutDownSound;
                source.Play();
            }

            return true;
        }
        else
        {
            print("Error: Pickup doesn't exist: " + itemName);
            return false;
        }
    }

    public void LeftMoving()
    {
        if (itemRenderer)
        {
            foreach (SpriteRenderer s in itemRenderer.GetComponentsInChildren<SpriteRenderer>())
            {
                s.sortingOrder = 4;
            }
            itemRenderer.GetComponent<SpriteRenderer>().sortingOrder = 3;
            itemRenderer.transform.localPosition = centerPos + new Vector3(-sideDist.x,sideDist.y);
        }
        dirThis = dir.left;
    }
    public void RightMoving()
    {
        if (itemRenderer)
        {
            foreach (SpriteRenderer s in itemRenderer.GetComponentsInChildren<SpriteRenderer>())
            {
                s.sortingOrder = 4;
            }
            itemRenderer.GetComponent<SpriteRenderer>().sortingOrder = 3;
            itemRenderer.transform.localPosition = centerPos + new Vector3(sideDist.x, sideDist.y);
        }
        dirThis = dir.right;
    }
    public void UpMoving()
    {
        if (itemRenderer)
        {
            foreach (SpriteRenderer s in itemRenderer.GetComponentsInChildren<SpriteRenderer>())
            {
                s.sortingOrder = 1;
            }
            itemRenderer.GetComponent<SpriteRenderer>().sortingOrder = 0;
            itemRenderer.transform.localPosition = centerPos;
        }
        dirThis = dir.up;
    }
    public void DownMoving()
    {
        if (itemRenderer)
        {
            foreach (SpriteRenderer s in itemRenderer.GetComponentsInChildren<SpriteRenderer>())
            {
                s.sortingOrder = 4;
            }
            itemRenderer.GetComponent<SpriteRenderer>().sortingOrder = 3;
            itemRenderer.transform.localPosition = centerPos;

        }
        dirThis = dir.down;
    }

    void OnTriggerStay(Collider col)
    {
        if (Input.GetAxis("PickUp") > 0 &&
            col.tag == "PickUp" &&
            items.Count == 0 &&
            !GetComponent<PlayerController>().getInteracting())
        {
            if(PickUpItem(col.GetComponent<Pickup>().item))
            {
                col.gameObject.GetComponent<Pickup>().Collect();
            }            
        }
    }
}
