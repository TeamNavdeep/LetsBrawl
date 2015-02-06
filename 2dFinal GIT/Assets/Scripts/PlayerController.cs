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
	public static bool isGrounded;
	public static bool doubleJump;

	//multi touch support
	public static Touch[] touches;
	private int fingertouch= 0;
	//animation
	private Animator anim;

	void Start () 
	{
		anim = this.GetComponent<Animator> ();
	}
	
	void Update () 
	{

		// for single touch use this code 
		//Input.GetTouch (0).phase == TouchPhase.Began
		//for touch and hold 
		//Input.GetTouch (0).phase != TouchPhase.Ended && Input.GetTouch (0).phase != TouchPhase.Canceled
		// to check if ray cast is hitting an object via touch
		// if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject == GAMEOBJECT)
		if (Input.touchCount > 0 ) 
		{
			foreach(Touch t in Input.touches)
			{
				Ray ray = Camera.main.ScreenPointToRay( t.position );
				RaycastHit hit;
				if(t.phase != TouchPhase.Ended || t.phase != TouchPhase.Canceled)
				{
					if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject == leftBtn)
					{
						Debug.Log("CLICK LEFT");
						anim.SetBool("Moving", true);
						movement = Vector3.forward * 0.1f;
						player.transform.rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
						player.transform.Translate(movement);

					}
					if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject == rightBtn)
					{
						Debug.Log("CLICK RIGHT");
						anim.SetBool("Moving", true);
						movement = Vector3.forward * 0.1f;
						//				if(Input.GetTouch(0).phase != TouchPhase.Ended && Input.GetTouch(0).phase != TouchPhase.Canceled)
						player.transform.rotation = Quaternion.Euler(0.0f, -270.0f, 0.0f);
						player.transform.Translate(movement);
					}

				}
				if(t.phase == TouchPhase.Began)
				{
					if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == jumpBtn && isGrounded)
					{
						anim.SetBool("Jump",true);//HERERERERE
						isGrounded = false;
						Debug.Log("CLICK JUMP");

						player.rigidbody.AddForce(new Vector2(0,300f));

					}
					else if(Physics.Raycast(ray, out hit) && hit.transform.gameObject == jumpBtn && !isGrounded && doubleJump)
					{
						anim.SetTrigger("Double Jump");
						player.rigidbody.AddForce(new Vector2(0,150f));
						doubleJump=false;
					}
				}
				else
				{
					anim.SetBool("Moving", false);
					anim.SetBool("Grounded", true);

				}

			}


		}

	}
}

