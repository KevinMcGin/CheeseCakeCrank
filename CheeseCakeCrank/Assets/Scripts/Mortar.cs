using UnityEngine;
using System.Collections;

public class Mortar : CookingProp {

    public Sprite on;
    public Sprite off;

    // Update is called once per frame
    void Update()
    {
        if (inUse)
        {
            GetComponent<SpriteRenderer>().sprite = on;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = off;
        }
    }
}
