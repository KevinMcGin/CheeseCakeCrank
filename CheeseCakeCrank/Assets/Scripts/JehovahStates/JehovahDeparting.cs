using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.JehovahStates
{
    class JehovahDeparting : JehovahState
    {
        public JehovahDeparting(JehovahsWitness j) : base(j)
        {

        }
        public override void DoState()
        {
            float step = jeh.speed * Time.deltaTime;
            jeh.transform.position = Vector3.MoveTowards(jeh.transform.position, jeh.spawnPoint, step);
        }

        public override void Leave()
        {
            GameObject.Destroy(jeh.dialogueText);
            GameObject.Destroy(jeh.gameObject);
        }
    }
}
