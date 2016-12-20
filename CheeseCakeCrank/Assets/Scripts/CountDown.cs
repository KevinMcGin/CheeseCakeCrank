using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour
{
    float totalTime = 1;
    float startTime = 0;
    bool timing = false;
    bool paused = false;
    float fraction = 0;

    public void StartTimer(float time)
    {
        totalTime = time;
        startTime = Time.time;
        timing = true;
    }
    public void Pause()
    {
        fraction = GetFractionDone();
        paused = true;
    }
    public void Continue()
    {
        paused = false;
        startTime = Time.time - fraction*totalTime;
    }

    public float GetFractionDone()
    {
        if (!paused)
        {
            return Mathf.Min(1, (Time.time - startTime) / totalTime);
        }
        else
        {
            return fraction;
        }
    }
    public bool timerDone()
    {
        if(GetFractionDone() == 1 && timing)
        {
            timing = false;
            return true;
        }
        return false;
    }
}
