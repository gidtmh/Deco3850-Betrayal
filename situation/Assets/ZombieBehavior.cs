using UnityEngine;
using System.Collections;

public class ZombieBehavior : Photon.MonoBehaviour {

	public Transform player;
	public float speed;
	public int health;
	private float range;
	private bool isAlive;

	private Vector3 targetPos;


	void start() {
		isAlive = true;
		targetPos = NetworkCharacter.getJamesPlayerPos ();
	}

	// Update is called once per frame
	void Update () {

		targetPos = NetworkCharacter.getJamesPlayerPos ();
//		print (targetPos);

		if (health < 1) {
			isAlive = false;
			speed = 0;
		}

		range = Vector2.Distance(transform.position, targetPos);
		if (range < 10f && health > 0) {

			if (speed < 0) {
				speed = speed * -1;
				if (transform.localScale.y < 0) {
					Vector3 temp = transform.localScale;
					temp.y = transform.localScale.y * -1f;
					transform.localScale = temp;
				}
			}


			Vector3 vectorToTarget = targetPos - transform.position;
			float angle = (Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
			Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * 0.9f);
			Debug.Log (range);
			transform.position = Vector2.MoveTowards (transform.position, targetPos, speed * 0.1f);

		} else if (health < 1) {
			speed = 0f;
		
		} else {
			transform.Translate (Vector2.up * (speed / 10));
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "Orb") {
			health--;
			if (health <= 0) {
				isAlive = false;
				health = -1;
			}
		} else {

			speed = speed * -1;
			Vector3 temp = transform.localScale;
			temp.y = (transform.localScale.y * -1f);
			transform.localScale = temp;
		}
	}
}