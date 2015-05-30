using UnityEngine;
using System.Collections;

public class ZombieBehavior : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.up * (speed/10));
	}

	void OnCollisionEnter2D(Collision2D coll) {

		speed = speed * -1;
		Vector3 temp = transform.localScale;
		temp.y = (transform.localScale.y * -1f);
		transform.localScale = temp;
	}
}
