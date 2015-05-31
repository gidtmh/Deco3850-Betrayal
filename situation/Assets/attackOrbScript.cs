using UnityEngine;
using System.Collections;

public class attackOrbScript : MonoBehaviour {

	public float speed = 1f;
//	public Transform Jasper;
	private float range;
	private float range1;
	private float range2;
	private Transform target;
	private Transform target1;
	private Transform target2;
	private Transform mainTarget;
	private float counter;

	// Use this for initialization
	void Start () {
	
		Physics2D.IgnoreLayerCollision (9,10);
		transform.Translate (Vector2.up * (speed / 10)); 
		target = GameObject.Find("Jasper").transform;
		target1 = GameObject.Find("Jasper 1").transform;
		target2 = GameObject.Find("Jasper 2").transform;
		counter = 0;

	}
	
	// Update is called once per frame
	void Update () {
		counter++;

		if (counter > 550) {
			Destroy (gameObject);
		}

		range = Vector2.Distance(transform.position, target.position);
		range1 = Vector2.Distance(transform.position, target1.position);
		range2 = Vector2.Distance(transform.position, target2.position);

		if (range < range1 && range < range2) {
			mainTarget = target;
		} else if (range1 < range && range1 < range2) {
			mainTarget = target1;
		} else {
			mainTarget = target2;
		}

		if (range < 10f || range1 < 10 || range2 < 10) {
			
			Vector3 vectorToTarget = mainTarget.position - transform.position;
			float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) -90;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 0.9f);
			Debug.Log (range);
			transform.position = Vector2.MoveTowards (transform.position, mainTarget.position, speed * 0.2f);
		}

		transform.Translate (Vector2.up * (speed / 5));
	}


	void OnCollisionEnter2D(Collision2D coll) {



		Destroy(gameObject);
	}

	void onBecameInvisible() {
		Destroy (gameObject);
	}
}
