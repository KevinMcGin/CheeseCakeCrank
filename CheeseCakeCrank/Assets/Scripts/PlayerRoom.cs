using UnityEngine;
using System.Collections;

public class PlayerRoom : MonoBehaviour {

    public GameObject[] Rooms;
    int room;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        for(int i = 0; i < Rooms.Length;i++)
        {
            if(Rooms[i] == col.gameObject)
            {
                room = i;
                print("Room: " + i.ToString());
                return;
            }
        }
    }

    public int GetRoom()
    {
        return room;
    }
}
