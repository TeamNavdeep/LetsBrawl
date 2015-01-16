using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Platform")
		{
			PlayerController.isGrounded = true;
			PlayerController.doubleJump = false;
			Debug.Log("GROUND");
		}

	}
}
