using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.JehovahStates
{
    class JehovahArriving : JehovahState
    {
        public JehovahArriving(JehovahsWitness j) : base(j)
        {
        }

        public override void DoState()
        {
            float step = jeh.speed * Time.deltaTime;
            jeh.transform.position = Vector3.MoveTowards(jeh.transform.position, jeh.doorstep.transform.position, step);
        }
    }
}
