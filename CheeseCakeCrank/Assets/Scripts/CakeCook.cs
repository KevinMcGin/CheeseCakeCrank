using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CakeCook : CookingProp {

    protected override void ChildFinish()
    {
        Destroy(transform.parent.gameObject);
    }
}
