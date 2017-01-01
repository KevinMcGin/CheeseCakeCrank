using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates.ChaseStates
{
    class ChaseRoom9 : MoveState
    {
        public ChaseRoom9(PoliceState p) : base(p)
        {
        }
        public override void Leave()
        {
            GoTo(policeState.police.goToPostitions[10].position);
        }
        public override void ToPlayer()
        {
            if (policeState.police.roomOfPlayer.GetRoom() == 8 ||
                policeState.police.roomOfPlayer.GetRoom() == 9 ||
                policeState.police.roomOfPlayer.GetRoom() == 10)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() <= 4 ||
                policeState.police.roomOfPlayer.GetRoom() == 11)
            {
                GoTo(policeState.police.goToPostitions[10].position);
            }
            else
            {
                GoTo(policeState.police.goToPostitions[8].position);
            }
        }
    }
}
