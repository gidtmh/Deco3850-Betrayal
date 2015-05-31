using UnityEngine;
using System.Collections;

public class CollideScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {}
        void OnTriggerEnter(Collider player) {

		if(player.gameObject.tag == "player")
		{
			this.gameObject.SetActive(false);

		}
        }
	
	
	}

