using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates.ChaseStates
{
    class ChaseRoom1 : MoveState

    {
        public ChaseRoom1(PoliceState p) : base(p)
        {
        }
        public override void Leave()
        {
            policeState.police.state = new PoliceDeparting(policeState.police, policeState.chaseState);
        }
        public override void ToPlayer()
        {
            if(policeState.police.roomOfPlayer.GetRoom() == 1)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else
            {
                GoTo(policeState.police.goToPostitions[2].position);
            }
        }
    }
}
