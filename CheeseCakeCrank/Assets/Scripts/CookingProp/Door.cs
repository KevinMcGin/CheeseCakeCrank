using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Door : CookingProp {

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
	}

    // Update is called once per frame
    protected override void Update ()
    {
        base.Update();
        timerText.GetComponent<Text>().text = "";
        if (stateThis == state.cooking)
        {
            if (count.timerDone())
            {
                stateThis = state.cooked;
                //Nothing here needed?

            }
        }
    }

    public override bool Interact(ref List<string> items)
    {
        JehovahsWitness jehovah = FindObjectOfType<JehovahsWitness>();
        if (jehovah)
        {
            if (jehovah.AtDoor())
            {
                StartCoroutine(jehovah.Talk());

                count = new CountDown();
                count.StartTimer(jehovah.TalkDurationSeconds);
                stateThis = state.cooking;
                return true;
            }
        }
        return false;
    }
    protected override void ChildStart()
    {
        

    }
}
