using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class TimerGame : MonoBehaviour {

    float time;
    Text timeText;

    bool inGame = true;

	// Use this for initialization
	void Start ()
    {
        time = 0;
        timeText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (inGame)
        {
            time += Time.deltaTime;
            timeText.text = System.String.Format("{0:0.00}", time) + 's';
        }
	}

    public void GameWon()
    {
        inGame = false;
    }

    public void GameLost()
    {
        inGame = false; 
    }
}
