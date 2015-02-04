using UnityEngine;
using System.Collections;

public class DC_Test : MonoBehaviour {

	private Animator anim;
	public GameObject guiText;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Space))
		{
			guiText.SetActive(true);
			this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
			anim.SetTrigger("Disconnected");
		}
	}
}
