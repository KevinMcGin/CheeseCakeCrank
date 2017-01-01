using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates
{
    public class PoliceChasingDoor : PoliceState
    {
        public PoliceChasingDoor(Policeman p, MoveState state) : base(p, state)
        {
            chaseState = new ChaseStates.ChaseRoom1(this);
        }

        public override void DoState()
        {
            chaseState.ToPlayer();
        }

        public override void StartStatement()
        {
            police.state = new PoliceRequestStatement(police, chaseState);
        }
    }
}
