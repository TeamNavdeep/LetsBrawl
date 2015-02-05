using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

	private Animator anim;
	public GameObject slot_HG;
	public GameObject slot_SG;
	public GameObject slot_AR;
	public GameObject slot_ME01;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	//Switches to Handgun
	public void SwitchToHG()
	{
		slot_HG.SetActive (false);
		slot_SG.SetActive (false);
		slot_AR.SetActive (false);
		slot_ME01.SetActive (false);
		slot_HG.SetActive (true);
		anim.SetFloat("CurStyle", 0);
	}

	//Switches to Shotgun
	public void SwitchToSG()
	{
		slot_HG.SetActive (false);
		slot_SG.SetActive (false);
		slot_AR.SetActive (false);
		slot_ME01.SetActive (false);
		slot_SG.SetActive (true);
		anim.SetFloat("CurStyle", 1);
	}

	//Switches to Assault Rifle
	void SwitchToAR()
	{
		slot_HG.SetActive (false);
		slot_SG.SetActive (false);
		slot_AR.SetActive (false);
		slot_ME01.SetActive (false);
		slot_AR.SetActive (true);
		anim.SetFloat("CurStyle", 2);
	}

	//Switches to Combat Knife
	public void SwitchToME01()
	{
		slot_HG.SetActive (false);
		slot_SG.SetActive (false);
		slot_AR.SetActive (false);
		slot_ME01.SetActive (false);
		slot_ME01.SetActive (true);
		anim.SetFloat("CurStyle", 5);
	}
}
