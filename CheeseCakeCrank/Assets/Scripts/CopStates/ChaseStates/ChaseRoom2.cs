using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates.ChaseStates
{
    class ChaseRoom2 : MoveState


    {
        public ChaseRoom2(PoliceState p) : base(p)
        {
        }
        public override void Leave()
        {
            GoTo(policeState.police.goToPostitions[1].position);
        }
        public override void ToPlayer()
        {
            if (policeState.police.roomOfPlayer.GetRoom() == 2)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() == 1)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() == 3)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else
            {
                GoTo(policeState.police.goToPostitions[3].position);
            }
        }
    }
}
