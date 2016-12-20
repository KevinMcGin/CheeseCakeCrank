using UnityEngine;
using System.Collections;

public class BakeBiscuit : CookingPropGo {

	protected override void ChildStart()
    {
        FindObjectOfType<Instruction>().TakeBiscuitOut();
    }
    protected override void ChildFinish()
    {
        FindObjectOfType<Instruction>().DropBiscuit();
    }
}
