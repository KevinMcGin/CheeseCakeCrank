using UnityEngine;
using System.Collections;

public class Sink : CookingPropStay {

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        used = false;
    }
}
