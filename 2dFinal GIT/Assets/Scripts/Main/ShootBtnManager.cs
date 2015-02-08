using UnityEngine;
using System.Collections;

public class ShootBtnManager : MonoBehaviour {

	private int curWep; 
	private WeaponManager wepManage;
	public Texture HG_TEX;
	public Texture SG_TEX;
	public Texture AR_TEX;
	public Texture ME_TEX;

	// Use this for initialization
	void Start () {

		wepManage = GameObject.FindWithTag ("Player").GetComponent<WeaponManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		curWep = wepManage.GetSlotNum ();

		switch(curWep)
		{
		case 0:
			this.renderer.material.mainTexture = HG_TEX;
			break;
		case 1:
			this.renderer.material.mainTexture = SG_TEX;
			break;
		case 2:
			this.renderer.material.mainTexture = AR_TEX;
			break;
		case 5:
			this.renderer.material.mainTexture = ME_TEX;
			break;
		}
	}
}
