using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.CopStates
{
    class PoliceSmashingState : PoliceState
    {
        public PoliceSmashingState(Policeman p) : base(p)
        {

        }

        public override void DoState()
        {
            police.source.PlayOneShot(police.doorSmashSound, police.doorSmashVolume);
            police.state1 = new PoliceChasingDoor(police);
        }
    }
}
