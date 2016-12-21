using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.JehovahStates
{
    abstract public class JehovahState
    {
        protected JehovahsWitness jeh;
        public JehovahState(JehovahsWitness j)
        {
            jeh = j;
        }

        public abstract void DoState();
        public virtual void FirstArriving() { }
        public virtual void Leave() { }
        public virtual bool isDoor() { return false; }
    }
}
