using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.CopStates
{
    class PoliceRequestStatement : PoliceState
    {
        public PoliceRequestStatement(Policeman p) : base(p)
        {
        }

        public override void DoState()
        {
            police.state1 = new PoliceTakingStatement(police);
            police.StartCoroutine(police.TakeStatement());
        }
    }
}
