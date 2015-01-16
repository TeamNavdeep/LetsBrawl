using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour {

	public GameObject player;
	//buttons
	public GameObject leftBtn,rightBtn,jumpBtn;

	//movespeed
	private Vector3 movement = Vector3.left * 0.1f;

	//jump and ground check
	public static bool isGrounded = true;
	public static bool doubleJump = false;



	void Start () {

	
	}
	
	void Update () {

		// for single touch use this code 
		//Input.GetTouch (0).phase == TouchPhase.Began
		//for touch and hold 
		//Input.GetTouch (0).phase != TouchPhase.Ended && Input.GetTouch (0).phase != TouchPhase.Canceled
		// to check if ray cast is hitting an object via touch
		// if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject == GAMEOBJECT)



		if (Input.touchCount > 0 && Input.GetTouch (0).phase != TouchPhase.Ended && Input.GetTouch (0).phase != TouchPhase.Canceled) 
		{
			Ray ray = Camera.main.ScreenPointToRay( Input.GetTouch(0).position );
			RaycastHit hit;

			if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject == leftBtn)
			{
				Debug.Log("CLICK LEFT");
				movement = Vector3.left * 0.1f;
				player.transform.Translate(movement);
			}
			if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject == rightBtn)
			{
				Debug.Log("CLICK RIGHT");
				movement = Vector3.right * 0.1f;
				//				if(Input.GetTouch(0).phase != TouchPhase.Ended && Input.GetTouch(0).phase != TouchPhase.Canceled)
				player.transform.Translate(movement);
			}

			if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject == jumpBtn && isGrounded && !doubleJump)
			{
				isGrounded = false;
				doubleJump = true;
				Debug.Log("CLICK JUMP");
				player.rigidbody.AddForce(new Vector2(0,300f));

			}
//			if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject == jumpBtn && !isGrounded && doubleJump)
//			{
//				doubleJump = false;
//				Debug.Log("CLICK doubleJUMP");
//				player.rigidbody.AddForce(new Vector2(0,300f));
//				
//			}


		}
		
	}
	void FixedUpdate()
	{


	}


}

