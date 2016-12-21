using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates.ChaseStates
{
    class ChaseRoom7 : MoveState
    {
        public ChaseRoom7(PoliceState p) : base(p)
        {
        }
        public override void Leave()
        {
            GoTo(policeState.police.goToPostitions[6].position);
        }
        public override void ToPlayer()
        {
            if (policeState.police.roomOfPlayer.GetRoom() == 7 ||
                policeState.police.roomOfPlayer.GetRoom() == 6 ||
                policeState.police.roomOfPlayer.GetRoom() == 8)
            {
                GoTo(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else if (policeState.police.roomOfPlayer.GetRoom() <= 6)
            {
                GoTo(policeState.police.goToPostitions[6].position);
            }
            else
            {
                GoTo(policeState.police.goToPostitions[8].position);
            }
        }
    }
}
