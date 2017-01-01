using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.CopStates;
using UnityEngine;

namespace Assets.Scripts.CopStates
{
    abstract public class MoveState
    {
        protected PoliceState policeState;

        public abstract void ToPlayer();

        public abstract void Leave();

        public MoveState(PoliceState p)
        {
            policeState = p;
        }

        public void GoTo(Vector3 playerPos)
        {
            float step = policeState.police.speed * Time.deltaTime;
            policeState.police.transform.position = Vector3.MoveTowards(policeState.police.transform.position, playerPos+new Vector3(0,1), step);
        }
    }
}
