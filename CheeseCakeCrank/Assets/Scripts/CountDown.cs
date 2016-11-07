using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour
{

    float totalTime = 1;
    float startTime = 0;
    bool timing = false;


    public void StartTimer(float time)
    {
        totalTime = time;
        startTime = Time.time;
        timing = true;
    }

    public float GetFractionDone()
    {
        return Mathf.Min(1,(Time.time - startTime) / totalTime);
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
