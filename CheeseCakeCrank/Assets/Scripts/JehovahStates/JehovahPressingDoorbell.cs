using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.JehovahStates
{
    class JehovahPressingDoorbell : JehovahState
    {
        public JehovahPressingDoorbell(JehovahsWitness j) : base(j)
        {
        }

        public override void DoState()
        {
            Instruction.FindObjectOfType<Instruction>().GetDoor();
            jeh.source.PlayOneShot(jeh.doorbellSound, jeh.doorbellVolume);
            jeh.currentDoorbellPresses++;
            jeh.state1 = new JehovahWaiting(jeh);
            jeh.StartCoroutine(jeh.DealWithDoor());
        }
    }
}
