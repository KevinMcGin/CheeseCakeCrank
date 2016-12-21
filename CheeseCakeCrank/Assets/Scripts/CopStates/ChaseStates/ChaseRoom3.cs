using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates.ChaseStates
{
    class ChaseRoom3 : MoveState


    {
        public ChaseRoom3(PoliceState p) : base(p)
        {
        }
        public override void Leave()
        {
            GoTo(policeState.police.goToPostitions[2].position);
        }
        public override void ToPlayer()
        {
            if (policeState.police.roomOfPlayer.GetRoom() == 3)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() == 2)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() == 1)
            {
                GoTo(policeState.police.goToPostitions[1].position);
            }
            else
            {
                GoTo(policeState.police.goToPostitions[4].position);
            }
        }
    }
}
