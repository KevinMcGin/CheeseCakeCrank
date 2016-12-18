using UnityEngine;
using System.Collections;

public class Blender : CookingProp
{
    public Sprite loaded;
    public Sprite on;
    public Sprite empty;

    void Update()
    {
        if(used)
        {
            GetComponent<SpriteRenderer>().sprite = empty;
        }
        else
        {
            if(inUse)
            {
                GetComponent<SpriteRenderer>().sprite = on;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = loaded;
            }
        }
    }
	
}
