using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates
{
    class PoliceChasingDoor : PoliceState
    {
        public PoliceChasingDoor(Policeman p) : base(p)
        {

        }

        public override void DoState()
        {
            float step = police.speed * Time.deltaTime;
            // To Do: set this to actual player position
            Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            police.transform.position = Vector3.MoveTowards(police.transform.position, playerPos, step);
        }

        public override void StartStatement()
        {
            police.state1 = new PoliceRequestStatement(police);
        }
    }
}
