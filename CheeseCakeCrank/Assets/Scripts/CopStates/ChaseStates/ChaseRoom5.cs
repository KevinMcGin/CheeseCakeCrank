using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates.ChaseStates
{
    class ChaseRoom5 : MoveState
    {
        public ChaseRoom5(PoliceState p) : base(p)
        {
        }
        public override void Leave()
        {
            GoTo(policeState.police.goToPostitions[4].position);
        }
        public override void ToPlayer()
        {
            if (policeState.police.roomOfPlayer.GetRoom() == 5)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() == 4)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() == 6)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() <= 4 ||
                policeState.police.roomOfPlayer.GetRoom() == 10 ||
                policeState.police.roomOfPlayer.GetRoom() == 11)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else
            {
                GoTo(policeState.police.goToPostitions[6].position);
            }
        }
    }
}
