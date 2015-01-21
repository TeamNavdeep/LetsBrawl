using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MoveRight : MonoBehaviour {
	Touch touch;
	public GameObject cube;
	private Vector3 movement = Vector3.left * 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {


		if (Input.touchCount > 0 && Input.GetTouch (0).phase != TouchPhase.Ended && Input.GetTouch (0).phase != TouchPhase.Canceled) 
		{
			Ray ray = Camera.main.ScreenPointToRay( Input.GetTouch(0).position );
			RaycastHit hit;

			if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject == cube)
			{
				Debug.Log("CLICK RIGHT");
				movement = Vector3.right * 0.1f;
//				if(Input.GetTouch(0).phase != TouchPhase.Ended && Input.GetTouch(0).phase != TouchPhase.Canceled)
					cube.transform.Translate(movement);
			}
		}

	}
	
}