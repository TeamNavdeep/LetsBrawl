using UnityEngine;
using System.Collections;

public class WeaponChange_Test : MonoBehaviour {

	private WeaponManager wepManage;

	// Use this for initialization
	void Start () {
		wepManage = GetComponent<WeaponManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.F1))
		{
			wepManage.SwitchWeapon(0);
		}

		if(Input.GetKeyDown(KeyCode.F2))
		{
			wepManage.SwitchWeapon(1);
		}

		if(Input.GetKeyDown(KeyCode.F3))
		{
			wepManage.SwitchWeapon(2);
		}

		if(Input.GetKeyDown(KeyCode.F4))
		{
			wepManage.SwitchWeapon(5);
		}
	}
}
