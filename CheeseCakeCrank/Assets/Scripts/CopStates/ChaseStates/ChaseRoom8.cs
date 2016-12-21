using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates.ChaseStates
{
    class ChaseRoom8 : MoveState
    {
        public ChaseRoom8(PoliceState p) : base(p)
        {
        }
        public override void Leave()
        {
            GoTo(policeState.police.goToPostitions[7].position);
        }
        public override void ToPlayer()
        {
            if (policeState.police.roomOfPlayer.GetRoom() == 8 ||
                policeState.police.roomOfPlayer.GetRoom() == 7 ||
                policeState.police.roomOfPlayer.GetRoom() == 9)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() <= 7)
            {
                GoTo(policeState.police.goToPostitions[7].position);
            }
            else
            {
                GoTo(policeState.police.goToPostitions[9].position);
            }
        }
    }
}
