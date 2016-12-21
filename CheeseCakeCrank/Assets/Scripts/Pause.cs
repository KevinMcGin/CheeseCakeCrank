using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public GameObject pause;
    public GameObject won;
    public GameObject lost;
    public GameObject resumeButton;
    bool paused = false;
    bool endGame = false;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
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
        if(endGame)
        {
            return;
        }

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
        endGame = false;
        UnPauseGame();
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Won()
    {
        endGame = true;
        won.SetActive(true);
        resumeButton.SetActive(false);
        PauseGame();
    }
    public void Lost()
    {
        endGame = true;
        lost.SetActive(true);
        resumeButton.SetActive(false);
        PauseGame();
    }
}
