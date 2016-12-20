using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class CookingProp : MonoBehaviour {
    
    public float timer;
    protected CountDown count;

    public AudioClip interactSound;
    protected AudioSource source;

    public string[] itemsNeeded;

    public string[] itemsReturn;

    protected bool used = false;

    protected PlayerController playerController;

    protected GameObject timerText;

    protected enum state
    {
        idle, cooking, cooked, burnt, cookingPause
    }
    protected state stateThis;

	// Use this for initialization
	protected virtual void Start ()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = interactSound;
        source.loop = true;
        count = new CountDown();
        stateThis = state.idle;
        playerController = FindObjectOfType<PlayerController>();

        timerText = Resources.Load<GameObject>("TimerText");
        timerText = Instantiate(timerText, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        timerText.transform.SetParent(GameObject.Find("Canvas").transform, false);
        timerText.transform.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0, 40 * (float)Screen.height / (float)768);
        timerText.SetActive(false);
        timerText.GetComponent<Text>().color = Color.green;
    }
	
	// Update is called once per frame
	protected virtual void Update()
    {
        timerText.GetComponent<Text>().text = System.String.Format("{0:0.00}",timer - count.GetFractionDone() * timer) + 's';
    }

    public float GetTimer()
    {
        return timer;
    }

    public virtual bool Interact(ref List<string> items)
    {        
        if(used || stateThis != state.idle)
        {
            return false;
        }
        if(itemsNeeded.Length == 0 && items.Count != 0)
        {
            return false;
        }
        for(int i = 0; i < itemsNeeded.Length; i++)
        {
            if(!items.Contains(itemsNeeded[i]))
            {
                return false;
            }
        }
        for (int i = 0; i < itemsNeeded.Length; i++)
        {
            items.Remove(itemsNeeded[i]);
        }
        count = new CountDown();
        count.StartTimer(timer);
        stateThis = state.cooking;
        timerText.SetActive(true);

        if(interactSound)
        {
            source.Play();
        }

        ChildStart();
        return true;
    }

    public void FinishInteracting()
    {
        for (int i = 0; i < itemsReturn.Length; i++)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().PickUpItem(itemsReturn[i]);
        }
        used = true;
        stateThis = state.idle;
        playerController.setInteracting(false);
        timerText.SetActive(false);
        source.Stop();
        ChildFinish();
    }

    protected virtual void ChildFinish() { }
    protected virtual void ChildStart() { }

    public virtual void TakeCake() { }

}
