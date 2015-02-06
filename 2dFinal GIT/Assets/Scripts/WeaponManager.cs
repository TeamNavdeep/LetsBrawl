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

	public void SwitchWeapon(int slotNum)
	{
		slot_HG.SetActive (false);
		slot_SG.SetActive (false);
		slot_AR.SetActive (false);
		slot_ME01.SetActive (false);

		switch(slotNum)
		{
		case 0:
			slot_HG.SetActive (true);
			anim.SetFloat("CurStyle", slotNum);
			break;
		case 1:
			slot_SG.SetActive (true);
			anim.SetFloat("CurStyle", slotNum);
			break;
		case 2:
			slot_AR.SetActive (true);
			anim.SetFloat("CurStyle", slotNum);
			break;
		case 5:
			slot_ME01.SetActive (true);
			anim.SetFloat("CurStyle", slotNum);
			break;
		}
	}
}
