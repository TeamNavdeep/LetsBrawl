﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour {

	public GameObject player;
	//buttons
	public GameObject leftBtn,rightBtn,jumpBtn, shootBtn;

	//projectiles
	public GameObject pistolprojectile;

	//movespeed
	private Vector3 movement = Vector3.forward * 0.1f;

	//shooting variables
	private float timer = 0f;
	private bool canshoot = false;
	private float speed = 10f;

	//jump and ground check
	public static bool isGrounded;
	public static bool doubleJump;
	public bool checkWalking;
	public bool checkJump;
	public bool checkDoubleJump;

	//multi touch support
	public static Touch[] touches;
	private int fingertouch= 0;
	//animation
	private Animator anim;
	private NetworkView netView;

	void shootPistol(){
		Vector3 bulletspawnpos = new Vector3 (
			player.transform.position.x,
			player.transform.position.y + 0.7f,
			player.transform.position.z
			);
		GameObject bullet = 
			(GameObject) Network.Instantiate(pistolprojectile, bulletspawnpos, player.transform.rotation, 0);
	}

	void Start () 
	{
		anim = this.GetComponent<Animator> ();
		netView = this.GetComponent<NetworkView> ();
		leftBtn = GameObject.Find ("Left_Btn");
		rightBtn = GameObject.Find ("Right_Btn");
		jumpBtn = GameObject.Find ("Jump_Btn");
		shootBtn = GameObject.Find ("Shoot_Btn");
	}
	
	void Update () 
	{
		timer += Time.deltaTime;
		if (timer >= 1f) {
			canshoot = true;
		}
		// for single touch use this code 
		//Input.GetTouch (0).phase == TouchPhase.Began
		//for touch and hold 
		//Input.GetTouch (0).phase != TouchPhase.Ended && Input.GetTouch (0).phase != TouchPhase.Canceled
		// to check if ray cast is hitting an object via touch
		// if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject == GAMEOBJECT)
		if (netView.isMine){

			if (Input.touchCount > 0 ) 
			{
				foreach(Touch t in Input.touches)
				{
					Ray ray = Camera.main.ScreenPointToRay( t.position );
					RaycastHit hit;
					if(t.phase != TouchPhase.Ended && t.phase != TouchPhase.Canceled)
					{
						if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject == leftBtn)
						{
							//Debug.Log("CLICK LEFT");
							anim.SetBool("Moving", true);
							checkWalking = true;
							player.transform.rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
							player.transform.Translate(movement);
							
						}
						else if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject == rightBtn)
						{
							//Debug.Log("CLICK RIGHT");
							anim.SetBool("Moving", true);
							checkWalking = true;
							player.transform.rotation = Quaternion.Euler(0.0f, -270.0f, 0.0f);
							player.transform.Translate(movement);
						}

						if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == shootBtn)
						{
							if(canshoot == true){
								Debug.Log("SHOOTING");
								shootPistol();
								anim.SetTrigger("Fire");
								canshoot = false;
								timer = 0.0f;
							}
						}
					}
					else
					{
						anim.SetBool("Moving", false);
						checkWalking = false;
					}
					if(t.phase == TouchPhase.Began)
					{

						if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == jumpBtn && isGrounded)
						{
							anim.SetTrigger("Jump");
							checkJump = true;
							isGrounded = false;
							//Debug.Log("CLICK JUMP");
							player.rigidbody.AddForce(new Vector2(0,1000f));
							
						}
						else if(Physics.Raycast(ray, out hit) && hit.transform.gameObject == jumpBtn && !isGrounded && doubleJump)
						{
							anim.SetTrigger("Double Jump");
							checkDoubleJump = true;
							player.rigidbody.AddForce(new Vector2(0,750f));
							doubleJump=false;
						}
					}
				}
			}
		}
		else{
			if (checkJump){
				anim.SetTrigger("Jump");
				checkJump = false;
			}
			if (checkDoubleJump){
				anim.SetTrigger("Double Jump");
				checkDoubleJump = false;
			}
			if (checkWalking){
				anim.SetBool("Moving", true);
			}
			else{
				anim.SetBool("Moving", false);
			}
		}
	}
}

