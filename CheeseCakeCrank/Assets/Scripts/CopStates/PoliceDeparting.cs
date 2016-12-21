using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CopStates
{
    class PoliceDeparting : PoliceState
    {
        public PoliceDeparting(Policeman p) : base(p)
        {
        }

        public override void DoState()
        {
            float step = police.speed * Time.deltaTime;
            police.transform.position = Vector3.MoveTowards(police.transform.position, police.spawnPoint, step);
        }

        public override void Leave()
        {
            GameObject.Destroy(police.gameObject);
        }
    }
}
