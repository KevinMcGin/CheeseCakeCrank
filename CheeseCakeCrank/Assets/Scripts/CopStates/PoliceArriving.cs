using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates
{
    class PoliceArriving : PoliceState
    {
        public PoliceArriving(Policeman p) : base(p)
        {
        }

        public override void DoState()
        {
            float step = police.speed * Time.deltaTime;
            police.transform.position = Vector3.MoveTowards(police.transform.position, police.doorstep.transform.position, step);
        }

        public override void FirstArriving()
        {
            police.state1 = new PoliceThumpingDoor(police);
        }
    }
}
