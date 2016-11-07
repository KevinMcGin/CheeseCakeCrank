using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MakeCake : MonoBehaviour {

    // Public fields
    public string cakeTag;
    public float preferredCakeMakingSeconds;
    public float maxCakeMakingSeconds;

    // Private fields
    private bool nearCake;
    private string state;
    private float cakeMakingSeconds;

    public Slider progress;

	// Use this for initialization
	void Start ()
    {
        nearCake = false;
        cakeMakingSeconds = 0;
        setState("not making cake");
    }

    // Update is called once per frame
    void Update()
    {
        progress.value = Mathf.Min(1, cakeMakingSeconds / preferredCakeMakingSeconds);

        if (Input.GetKeyDown("space"))
        {
            // Handle "Use" input
            if (!nearCake)
            {
                Debug.Log("Not near cake!");
            }
            else if (nearCake)
            {
                if (state.CompareTo("not making cake") == 0)
                    setState("making cake");
                else if (state.CompareTo("making cake") == 0)
                    setState("not making cake");
            }

            // Horrific else ifs: implement state pattern please
            if (state.CompareTo("making cake") == 0)
            {
                cakeMakingSeconds += Time.deltaTime;
            }
            else if(state.CompareTo("not making cake") == 0)
            {
                // Check if game won
                if (preferredCakeMakingSeconds <= cakeMakingSeconds && cakeMakingSeconds < maxCakeMakingSeconds)
                {
                    GameWon(1 - (cakeMakingSeconds - preferredCakeMakingSeconds));
                }
            }

            // Check if game lost yet
            if (maxCakeMakingSeconds < cakeMakingSeconds)
            {
                GameLost();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(cakeTag))
        {
            nearCake = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(cakeTag))
        {
            nearCake = false;
        }
    }

    void GameLost()
    {
        Debug.Log("Game over! Cake is inedible.");
    }

    void GameWon(float perfection)
    {
        Debug.Log("You win! Cake is " + perfection * 100 + "% perfect!");
    }

    public void setState(string state)
    {
        Debug.Log(Time.time + ", " + this.gameObject.ToString() + ": " + state);
        this.state = state;
    }
}