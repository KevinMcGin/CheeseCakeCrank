using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class CoolCake : CookingPropGo
{

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (stateThis == state.cooked)
        {
            timerText.GetComponent<Text>().color = Color.blue;
        }
        else if (stateThis == state.burnt)
        {
            timerText.GetComponent<Text>().text = "COLD!!";
            FindObjectOfType<TimerGame>().GameLost();
        }
    }


    protected override void ChildFinish()
    {
        FindObjectOfType<TimerGame>().GameWon();
        Destroy(this.gameObject);
    }

    public void PutDown()
    {
        List<string> l = new List<string>();
        Interact(ref l);
        timerText.transform.position = Camera.main.WorldToScreenPoint(transform.position) + 
            new Vector3(0, 40 * (float)Screen.height / (float)768);

        stateThis = state.cooking;

        transform.parent.tag = "Untagged";
    }
}
