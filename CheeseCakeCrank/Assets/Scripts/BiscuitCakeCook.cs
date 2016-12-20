using UnityEngine;
using System.Collections;

public class BiscuitCakeCook : CakeCook {

    protected override void ChildFinish()
    {
        base.ChildFinish();
        FindObjectOfType<Instruction>().BakeCheese();
    }
}
