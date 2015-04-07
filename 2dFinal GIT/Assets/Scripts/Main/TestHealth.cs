using UnityEngine;
using System.Collections;

public class TestHealth : MonoBehaviour {

	private float health;
	public GameObject healthbar;
	private GameObject healthbar2;
	private bool isAlive;

	// Use this for initialization
	void Start () {
		health = 100.0f;
		isAlive = true;
		healthbar2 = (GameObject)Instantiate (healthbar, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			isAlive =false;
		}
		healthbar2.transform.localScale = new Vector3 (health/100, 0.05f, 1);
		healthbar2.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+ 2.0f, this.transform.position.z);

        //For Testing
        if (Input.GetKeyDown(KeyCode.F5))
        {
            health -= 20;
        }
	}

	public bool getAliveStatus(){
		return isAlive;
	}

    public void setAliveStatus(bool status)
    {
        isAlive = status;
    }

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Projectile") {
			health -= 10.0f;
		}
	}
}
