using UnityEngine;
using System.Collections;

public class PlayerMovement : Photon.MonoBehaviour {

	public float speed;
	public int health;
	public bool isAlive;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "Jasper") {
			health--;
			if (health <= 0) {
				isAlive = false;
			}
		}
        else if (coll.gameObject.tag == "Resources")
        {
            Destroy(coll.gameObject);
        }

	}



	// Update is called once per frame
    void Update()
    {
        if (photonView.isMine)
        {
            inputMovement();
        }

    }
        
    void inputMovement(){
	if (Input.GetKey (KeyCode.D)) {
		//			transform.Translate (Vector2.right * speed);
		if (isAlive == true) {
			transform.Rotate (Vector3.forward * -4);
		    }   
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (Vector3.forward * 4);
		}

		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector2.up * speed);
		}

		if (Input.GetKey (KeyCode.S)) {

			transform.Translate (Vector2.up * -speed);

		}

	}
}