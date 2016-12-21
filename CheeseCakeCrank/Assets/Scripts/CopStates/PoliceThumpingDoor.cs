using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates
{
    class PoliceThumpingDoor : PoliceState
    {
        public PoliceThumpingDoor(Policeman p, MoveState state) : base(p, state)
        {
        }

        public override void DoState()
        {
            police.source.PlayOneShot(police.doorThumpSound, police.doorThumpVolume);
            police.currentDoorThumps++;
            police.state = new PoliceWaiting(police,chaseState);
            police.StartCoroutine(police.DealWithDoor());
        }
    }
}
