using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody rigid;

    Animator anim;

    float accel = 10;
    float maxSpeed = 8;
    float damp = .9f * 60f;

    bool interacting;

	// Use this for initialization
	void Start ()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        anim.SetBool("Left", false);
        anim.SetBool("Right", false);
        anim.SetBool("Back", false);
        anim.SetBool("Front", true);
        anim.SetBool("Walking", false);
        anim.SetBool("Holding", false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(interacting)
        {
            rigid.velocity = Vector3.zero;
            return;
        }

        if(!Move())
        {
            Damp();
        }
        if(rigid.velocity.magnitude > maxSpeed)
        {
            rigid.velocity = rigid.velocity.normalized * maxSpeed;
        }
	}

    bool Move()
    {
        anim.SetTrigger(Animator.StringToHash("StandingFront"));
        if (Input.GetAxis("Horizontal") > 0)
        {
            rigid.AddForce(Vector3.right * accel);
            rigid.velocity = new Vector3(rigid.velocity.x,0,0);
            anim.SetBool("Left", false);
            anim.SetBool("Right", true);
            anim.SetBool("Back", false);
            anim.SetBool("Front", false);
            anim.SetBool("Walking", true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigid.AddForce(Vector3.left * accel);
            rigid.velocity = new Vector3(rigid.velocity.x, 0, 0);
            anim.SetBool("Left", true);
            anim.SetBool("Right", false);
            anim.SetBool("Back", false);
            anim.SetBool("Front", false);
            anim.SetBool("Walking", true);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rigid.AddForce(Vector3.up * accel);
            rigid.velocity = new Vector3(0, rigid.velocity.y, 0);
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
            anim.SetBool("Back", true);
            anim.SetBool("Front", false);
            anim.SetBool("Walking", true);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rigid.AddForce(Vector3.down * accel);
            rigid.velocity = new Vector3(0, rigid.velocity.y, 0);
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
            anim.SetBool("Back", false);
            anim.SetBool("Front", true);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
            return false;
        }
        return true;
    }

    void Damp()
    {
        rigid.velocity *= damp * Time.deltaTime;
    }

    public void setInteracting(bool i)
    {
        interacting = i;
    }

    public void SetHolding(bool holding)
    {
        anim.SetBool("Holding", holding);
    }

}
