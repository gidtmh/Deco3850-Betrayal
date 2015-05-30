using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

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

	}



	// Update is called once per frame
	void Update () {


		if (Input.GetKey (KeyCode.D)) {
			//			transform.Translate (Vector2.right * speed);
			if (isAlive == true) {
				transform.Rotate (Vector3.forward * -4);
			}


		}

		if (Input.GetKey (KeyCode.A)) {
			//			transform.Translate (Vector2.right * -speed);

			transform.Rotate (Vector3.forward * 4);

			//			if (transform.localScale.x != -1) {
			//				Vector3 temp = transform.localScale;
			//				temp.x = (transform.localScale.x * -1f);
			//				transform.localScale = temp;
			//				
			//			}
		}

		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector2.up * speed);

			//			if (transform.localScale.y != 1) {
			//				Vector3 temp = transform.localScale;
			//				temp.y = (transform.localScale.y * -1f);
			//				transform.localScale = temp;
			//
			//			}
		}

		if (Input.GetKey (KeyCode.S)) {

			transform.Translate (Vector2.up * -speed);

			//			if (transform.localScale.y != -1) {
			//				Vector3 temp = transform.localScale;
			//				temp.y = (transform.localScale.y * -1f);
			//				transform.localScale = temp;
			//
			//			}

		}

	}
}
