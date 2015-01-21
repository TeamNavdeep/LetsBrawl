using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	public static Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Platform")
		{
			PlayerController.isGrounded = true;
			PlayerController.doubleJump = true;;
			Debug.Log("GROUND");
		}

	}
}
