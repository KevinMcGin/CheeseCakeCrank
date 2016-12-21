using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.CopStates
{
    class PoliceWaiting : PoliceState
    {
        public PoliceWaiting(Policeman p,MoveState state) : base(p, state)
        {

        }

        public override void DoState()
        {
            //nothing
        }
    }
}
