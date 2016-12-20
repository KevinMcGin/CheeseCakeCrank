using UnityEngine;
using System.Collections;

public class Mortar : CookingPropStay
{

    public Sprite on;
    public Sprite off;

    // Update is called once per frame
    void LateUpdate()
    {
        if (used)
        {
            GetComponent<SpriteRenderer>().sprite = off;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = on;
        }
    }

    protected override void ChildFinish()
    {
        FindObjectOfType<Instruction>().CheeseOnCake();
    }
}
