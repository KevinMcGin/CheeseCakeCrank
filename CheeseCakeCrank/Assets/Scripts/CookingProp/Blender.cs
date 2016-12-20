using UnityEngine;
using System.Collections;

public class Blender : CookingPropStay
{
    public Sprite loaded;
    public Sprite on;
    public Sprite empty;

    void LateUpdate()
    {
        if(used)
        {
            GetComponent<SpriteRenderer>().sprite = empty;
        }
        else if(stateThis == state.cooking)
        {
            GetComponent<SpriteRenderer>().sprite = on;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = loaded;
        }
    }

    protected override void ChildFinish()
    {
        FindObjectOfType<Instruction>().BakeBiscuit();
    }

}
