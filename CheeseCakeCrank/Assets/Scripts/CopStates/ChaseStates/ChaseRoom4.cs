using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates.ChaseStates
{
    class ChaseRoom4 : MoveState

    {
        public ChaseRoom4(PoliceState p) : base(p)
        {
        }
        public override void Leave()
        {
            GoTo(policeState.police.goToPostitions[3].position);
        }
        public override void ToPlayer()
        {
            if (policeState.police.roomOfPlayer.GetRoom() == 4)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() == 3)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() == 5)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() == 11)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() == 2 ||
                     policeState.police.roomOfPlayer.GetRoom() == 1)
            {
                GoTo(policeState.police.goToPostitions[3].position);
            }
            else if(policeState.police.roomOfPlayer.GetRoom() == 6 ||
                     policeState.police.roomOfPlayer.GetRoom() == 7)
            {
                GoTo(policeState.police.goToPostitions[5].position);
            }
            else
            {
                GoTo(policeState.police.goToPostitions[11].position);
            }
        }
    }
}
