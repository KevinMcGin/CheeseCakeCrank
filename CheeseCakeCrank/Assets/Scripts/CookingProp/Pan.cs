using UnityEngine;
using System.Collections;

public class Pan : CookingPropStay
{

    public Sprite on;
    public Sprite off;
    
	// Update is called once per frame
	void LateUpdate ()
    {
        if (stateThis == state.idle)
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
        FindObjectOfType<Instruction>().LemonOnCake();
        Destroy(this.gameObject);
    }
}
