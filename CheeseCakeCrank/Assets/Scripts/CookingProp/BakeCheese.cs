using UnityEngine;
using System.Collections;

public class BakeCheese : CookingPropGo
{

    protected override void ChildStart()
    {
        FindObjectOfType<Instruction>().TakeCheeseOut();
    }
    protected override void ChildFinish()
    {
        base.ChildFinish();
        FindObjectOfType<Instruction>().DropCheese();
    }
}
