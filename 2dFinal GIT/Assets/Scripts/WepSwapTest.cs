using UnityEngine;
using System.Collections;

public class WepSwapTest : MonoBehaviour {

	private Animator anim;
	public GameObject slot_HG;
	public GameObject slot_SG;
	public GameObject slot_AR;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Switches to Handgun
		if(Input.GetKeyDown(KeyCode.F1))
		{
			DeactivateAll();
			slot_HG.SetActive (true);
			anim.SetFloat("CurStyle", 0);
		}
		//Switches to Shotgun
		if(Input.GetKeyDown(KeyCode.F2))
		{
			DeactivateAll();
			slot_SG.SetActive (true);
			anim.SetFloat("CurStyle", 1);
		}
		//Switches to Assault Rifle
		if(Input.GetKeyDown(KeyCode.F3))
		{
			DeactivateAll();
			slot_AR.SetActive (true);
			anim.SetFloat("CurStyle", 2);
		}
	}

	//Deactivates all the slots
	void DeactivateAll()
	{
		slot_HG.SetActive (false);
		slot_SG.SetActive (false);
		slot_AR.SetActive (false);
	}
}
