using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates
{
    class PoliceTakingStatement : PoliceState
    {
        public PoliceTakingStatement(Policeman p) : base(p)
        {
        }

        public override void DoState()
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().setInteracting(true);
        }
    }
}
