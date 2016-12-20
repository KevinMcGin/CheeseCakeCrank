using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CakeCook : CookingPropStay {

    protected override void Update()
    {
        base.Update();
        timerText.transform.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0, 40 * (float)Screen.height / (float)768);
    }
    protected override void ChildFinish()
    {
        Destroy(transform.parent.gameObject);
    }
}
