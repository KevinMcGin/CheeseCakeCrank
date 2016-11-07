using UnityEngine;
using System.Collections;

public class ExitOnClick : MonoBehaviour
{

    public void Exit()
    {
        Debug.Log("Exiting!");
        Application.Quit();
    }
}