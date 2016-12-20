using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CookingPropGo : CookingProp
{
    public float timerBurnt;
    CountDown countBurnt;

    protected override void Start()
    {
        countBurnt = new CountDown();
        base.Start();
    }
    protected override void Update()
    {
        base.Update();

        if (stateThis == state.cooking)
        {
            if (count.timerDone())
            {
                stateThis = state.cooked;
                count = new CountDown();
                countBurnt.StartTimer(timerBurnt - timer);
                timerText.GetComponent<Text>().color = Color.red;
            }
        }
        else if (stateThis == state.cooked)
        {
            timerText.GetComponent<Text>().text = System.String.Format("{0:0.00}", timerBurnt - countBurnt.GetFractionDone() * timerBurnt) + 's';
            if (countBurnt.timerDone())
            {
                stateThis = state.burnt;
            }
        }
        else if (stateThis == state.burnt)
        {
            timerText.GetComponent<Text>().text = "BURNT!!";
        }
    }
    public override void TakeCake()
    {
        if(stateThis == state.cooked)
        {
            FinishInteracting();
        }
    }
    protected override void ChildStart()
    {

    }
}
