using UnityEngine;
using System.Collections;
using Assets.Scripts.CopStates.ChaseStates;

namespace Assets.Scripts.Rooms
{
    class Room1 : MonoBehaviour
    {
        void OnTriggerEnter(Collider col)
        {
            if(col.tag == "Police")
            {
                col.GetComponent<Policeman>().state.chaseState = new ChaseRoom1(col.GetComponent<Policeman>().state);
            }   
        }
    }
}
