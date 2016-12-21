using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.JehovahStates
{
    class JehovahWorry : JehovahState
    {
        public JehovahWorry(JehovahsWitness j) : base(j)
        {
        }

        public override void DoState()
        {
            jeh.state1 = new JehovahCallingPolice(jeh);
            jeh.StartCoroutine(jeh.CallPolice());
        }
    }
}
