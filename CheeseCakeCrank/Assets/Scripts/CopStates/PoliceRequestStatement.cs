using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.CopStates
{
    class PoliceRequestStatement : PoliceState
    {
        public PoliceRequestStatement(Policeman p, MoveState state) : base(p, state)
        {
        }

        public override void DoState()
        {
            police.state = new PoliceTakingStatement(police, chaseState);
            police.StartCoroutine(police.TakeStatement());
        }
    }
}
