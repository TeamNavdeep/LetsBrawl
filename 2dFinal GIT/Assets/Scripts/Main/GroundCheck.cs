using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	public static Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Platform")
		{
			anim.SetBool("Grounded", true);
			PlayerController.isGrounded = true;
			PlayerController.doubleJump = true;
			Debug.Log("GROUNDED");
		}
	}

	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.tag == "Platform")
		{
			anim.SetBool("Grounded", true);
			PlayerController.isGrounded = true;
			PlayerController.doubleJump = true;
			Debug.Log("GROUNDED");
		}
	}

	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.tag == "Platform")
		{
			anim.SetBool("Grounded", false);
			PlayerController.isGrounded = false;
			PlayerController.doubleJump = true;
			Debug.Log("NOT GROUNDED");
		}
	}
}
