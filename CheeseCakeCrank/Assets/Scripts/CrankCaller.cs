using UnityEngine;
using System.Collections;

public abstract class CrankCaller : MonoBehaviour {

    // Public fields
    public float speed;
    public string spawnPointTag;
    public string doorstepTag;

    // Protected fields
    protected AudioSource source;
    protected GameObject doorstep;
    protected Vector3 spawnPoint;

    // FIXME! Hacky solution on a hacky day. Do states properly with State Pattern another time
    protected string state;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        setState("arriving");
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
        this.state = state;
    }
}