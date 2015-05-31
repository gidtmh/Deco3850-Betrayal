using UnityEngine;
using System.Collections;

public class NetworkCharacter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);

            myThirdPersonController myC = GetComponent<myThirdPersonController>();
            stream.SendNext((int)myC._characterState);
        }
        else
        {
            // Network player, receive data
            this.correctPlayerPos = (Vector3)stream.ReceiveNext();
            this.correctPlayerRot = (Quaternion)stream.ReceiveNext();

            //myThirdPersonController myC = GetComponent<myThirdPersonController>();
            myC._characterState = (CharacterState)stream.ReceiveNext();
        }
    }
}
