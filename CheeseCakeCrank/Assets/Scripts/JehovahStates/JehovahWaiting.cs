using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.JehovahStates
{
    class JehovahWaiting : JehovahState
    {
        public JehovahWaiting(JehovahsWitness j) : base(j)
        {
        }

        public override void DoState()
        {
            //nothing
        }

        public override void FirstArriving()
        {
            if (jeh.currentDoorbellPresses < jeh.numDoorbellPressesToAttempt)
            {
                jeh.state = new JehovahPressingDoorbell(jeh);
            }
            else
            {
                jeh.state = new JehovahWorry(jeh);
            }
        }

        public override bool isDoor()
        {
            return true;
        }
    }
}
