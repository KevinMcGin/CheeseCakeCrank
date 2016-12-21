using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sink : CookingPropStay {

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        used = false;
    }

    void OnTriggerStay(Collider col)
    {
        ShitPickup shit = col.gameObject.GetComponent<ShitPickup>();
        if (shit)
        {
            List<string> l = new List<string>();
            l.Add("Shit");
            Interact(ref l);
            Destroy(col.gameObject);
        }
    }
}
