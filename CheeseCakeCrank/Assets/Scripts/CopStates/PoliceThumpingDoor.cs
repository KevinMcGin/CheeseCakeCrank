using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates
{
    class PoliceThumpingDoor : PoliceState
    {
        public PoliceThumpingDoor(Policeman p) : base(p)
        {
        }

        public override void DoState()
        {
            police.source.PlayOneShot(police.doorThumpSound, police.doorThumpVolume);
            police.currentDoorThumps++;
            police.state1 = new PoliceWaiting(police);
            police.StartCoroutine(police.DealWithDoor());
        }
    }
}
