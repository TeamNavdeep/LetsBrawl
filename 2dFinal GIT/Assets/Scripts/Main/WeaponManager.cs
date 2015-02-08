using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

	private Animator anim;
	private int slotNum;
	public GameObject slot_HG;
	public GameObject slot_SG;
	public GameObject slot_AR;
	public GameObject slot_ME01;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		slotNum = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void SwitchWeapon(int newSlot)
	{
		slotNum = newSlot;

		slot_HG.SetActive (false);
		slot_SG.SetActive (false);
		slot_AR.SetActive (false);
		slot_ME01.SetActive (false);

		switch(slotNum)
		{
		case 0:
			slot_HG.SetActive (true);
			anim.SetFloat("CurStyle", slotNum);
			Debug.Log("HG equipped!");
			break;
		case 1:
			slot_SG.SetActive (true);
			anim.SetFloat("CurStyle", slotNum);
			Debug.Log("SG equipped!");
			break;
		case 2:
			slot_AR.SetActive (true);
			anim.SetFloat("CurStyle", slotNum);
			Debug.Log("AR equipped!");
			break;
		case 5:
			slot_ME01.SetActive (true);
			anim.SetFloat("CurStyle", slotNum);
			Debug.Log("ME equipped!");
			break;
		}
	}

	public int GetSlotNum()
	{
		return slotNum;
	}
}
