using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public GameObject pause;
    bool paused = false;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown("escape"))
        {
            if(!paused)
            {
                PauseGame();
            }
            else
            {
                UnPauseGame();
            }
        }
	}

    void PauseGame()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
        paused = true;
        foreach (AudioSource a in FindObjectsOfType<AudioSource>())
        {
            a.Pause();
        }
    }
    public void UnPauseGame()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
        paused = false;
        foreach (AudioSource a in FindObjectsOfType<AudioSource>())
        {
            a.UnPause();
        }
    }
    public void Retry()
    {
        UnPauseGame();
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
