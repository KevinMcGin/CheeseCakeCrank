using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.CopStates
{
    class PoliceLeaveHouse : PoliceState
    {
        public PoliceLeaveHouse(Policeman p, MoveState state) : base(p, state)
        {

        }

        public override void DoState()
        {
            chaseState.Leave();
        }
    }
}
