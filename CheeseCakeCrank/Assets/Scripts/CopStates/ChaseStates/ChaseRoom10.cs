using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates.ChaseStates
{
    class ChaseRoom10 : MoveState
    {
        public ChaseRoom10(PoliceState p) : base(p)
        {
        }
        public override void Leave()
        {
            GoTo(policeState.police.goToPostitions[11].position);
        }
        public override void ToPlayer()
        {
            if (policeState.police.roomOfPlayer.GetRoom() == 9 ||
                policeState.police.roomOfPlayer.GetRoom() == 10 ||
                policeState.police.roomOfPlayer.GetRoom() == 11)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() <= 5 ||
                policeState.police.roomOfPlayer.GetRoom() == 11)
            {
                GoTo(policeState.police.goToPostitions[11].position);
            }
            else
            {
                GoTo(policeState.police.goToPostitions[9].position);
            }
        }
    }
}
