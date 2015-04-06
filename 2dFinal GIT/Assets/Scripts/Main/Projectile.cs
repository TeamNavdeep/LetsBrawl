using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private float speed = 10f;
	private float timer = 0.0f;
	private float timerlimit = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.velocity = transform.forward * speed;
		if (!renderer.isVisible) {
			Debug.Log ("Destroying bullet");
			Destroy (this.gameObject);
		}
	}
}
