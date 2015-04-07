using UnityEngine;
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
	private float limit;
	private bool canshoot = false;
	private float speed = 10f;
	private WeaponManager wepManage;

	//jump and ground check
	public static bool isGrounded;
	public static bool doubleJump;
	public bool checkWalking;
	public bool checkJump;
	public bool checkDoubleJump;

	private bool isleft = false;
	private float xoffset = 0.7f;

	//multi touch support
	public static Touch[] touches;
	private int fingertouch= 0;
	//animation
	private Animator anim;
	private NetworkView netView;

    //Sound variables
    public AudioClip hgSound;
    public AudioClip arSound;
    public AudioClip sgSound;

	void shoot(){
		if (isleft) {
			xoffset = -0.7f;
		} else {
			xoffset = 0.7f;
		}
		Vector3 bulletspawnpos = new Vector3 (
			player.transform.position.x + xoffset,
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
		wepManage = GetComponent<WeaponManager> ();
	}
	
	void Update () 
	{
		timer += Time.deltaTime;
		switch (wepManage.GetSlotNum()) {
		case 0:
			limit = 1.0f;
			break;
		case 1:
			limit = 1.5f;
			break;
		case 2:
			limit = 0.3f;
			break;
		case 5:
			limit = 1.0f;
			break;
		}
		if (timer >= limit) {
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
							isleft = true;
							//Debug.Log("CLICK LEFT");
							anim.SetBool("Moving", true);
							checkWalking = true;
							player.transform.rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
							player.transform.Translate(movement);
							
						}
						else if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject == rightBtn)
						{
							isleft = false;
							//Debug.Log("CLICK RIGHT");
							anim.SetBool("Moving", true);
							checkWalking = true;
							player.transform.rotation = Quaternion.Euler(0.0f, -270.0f, 0.0f);
							player.transform.Translate(movement);
						}

                        //For Testing - START -
                        if (Input.GetKeyDown(KeyCode.F8))
                        {
                            {
                                anim.SetTrigger("Fire");
                                Debug.Log("SHOOTING");
                                if (wepManage.GetSlotNum() != 5)
                                {
                                    shoot();
                                    switch (wepManage.GetSlotNum())
                                    {
                                        case 0:
                                            audio.PlayOneShot(hgSound);
                                            break;
                                        case 1:
                                            audio.PlayOneShot(arSound);
                                            break;
                                        case 2:
                                            audio.PlayOneShot(sgSound);
                                            break;
                                    }
                                }
                                canshoot = false;
                                timer = 0.0f;
                            }
                        }

                        //For Testing - END -

						if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == shootBtn)
						{

							if(canshoot == true){
								anim.SetTrigger("Fire");
								Debug.Log("SHOOTING");
								if(wepManage.GetSlotNum() != 5){
									shoot ();
                                    switch (wepManage.GetSlotNum())
                                    {
                                        case 0:
                                            audio.PlayOneShot(hgSound);
                                            break;
                                        case 1:
                                            audio.PlayOneShot(arSound);
                                            break;
                                        case 2:
                                            audio.PlayOneShot(sgSound);
                                            break;
                                    }
								}
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

