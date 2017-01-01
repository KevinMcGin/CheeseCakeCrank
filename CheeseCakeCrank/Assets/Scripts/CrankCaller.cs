using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class CrankCaller : MonoBehaviour {

    // Public fields
    public float speed;
    public string spawnPointTag;
    public string doorstepTag;
    public AudioClip[] talkingSounds;
    public AudioSource source;
    public GameObject doorstep;
    public Vector3 spawnPoint;
    public GameObject dialogueText;
    

    void Awake()
    {
        source = GetComponent<AudioSource>();

        dialogueText = transform.FindChild("DialogueText").gameObject;
        dialogueText.transform.SetParent(GameObject.Find("Canvas").transform, false);
        dialogueText.transform.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0, 100 * (float)Screen.height / (float)768);
        dialogueText.SetActive(false);
        dialogueText.GetComponent<Text>().color = Color.white;
    }

    // Use this for initialization
    public virtual void Start ()
    {
        spawnPoint = GameObject.FindWithTag(spawnPointTag).transform.position;
        this.gameObject.transform.position = spawnPoint;
        if (doorstep == null)
            doorstep = GameObject.FindWithTag(doorstepTag);
    }

    public void setState(string state)
    {
        Debug.Log(Time.time + ": " + state);
    }
}