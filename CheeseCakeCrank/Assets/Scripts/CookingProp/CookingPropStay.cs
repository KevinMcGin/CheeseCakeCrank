using UnityEngine;
using System.Collections;

public class CookingPropStay : CookingProp {

    bool interactButtonReleased = false;
    protected override void Update()
    {
        base.Update();
        if (Input.GetButtonUp("Interact") && stateThis == state.cooking)
        {
            interactButtonReleased = true;
        }
        if (stateThis == state.cooking)
        {
            if(count.timerDone())
            {
                FinishInteracting();
            }
            else if (Input.GetButtonDown("Interact") && interactButtonReleased)
            {
                stateThis = state.cookingPause;
                count.Pause();
                playerController.setInteracting(false);
                source.Stop();
            }
        }       
    }
    public override void TakeCake()
    {
        if (stateThis == state.cookingPause)
        {
            stateThis = state.cooking;
            count.Continue();
            playerController.setInteracting(true);
            interactButtonReleased = false;
            source.Play();
        }
    }

    protected override void ChildStart()
    {
        playerController.setInteracting(true);
    }
}
