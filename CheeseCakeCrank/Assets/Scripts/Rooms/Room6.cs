using UnityEngine;
using System.Collections;
using Assets.Scripts.CopStates.ChaseStates;

namespace Assets.Scripts.Rooms
{
    class Room6 : MonoBehaviour
    {
        void OnTriggerEnter(Collider col)
        {
            if(col.tag == "Police")
            {
                col.GetComponent<Policeman>().state.chaseState = new ChaseRoom6(col.GetComponent<Policeman>().state);
            }   
        }
    }
}
