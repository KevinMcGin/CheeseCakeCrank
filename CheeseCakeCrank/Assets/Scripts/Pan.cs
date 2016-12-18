using UnityEngine;
using System.Collections;

public class Pan : CookingProp {

    public Sprite on;
    public Sprite off;

    protected override void ChildFinish()
    {
        Destroy(this.gameObject);
    }
    
	// Update is called once per frame
	void Update ()
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
