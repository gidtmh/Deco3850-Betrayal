using UnityEngine;

public class NetworkCharacter : Photon.MonoBehaviour
{
    private Vector3 correctPlayerPos = Vector3.zero; // We lerp towards this
    private Quaternion correctPlayerRot = Quaternion.identity; // We lerp towards this
    // Update is called once per frame

	private static Vector3 jamesPlayerPos;

    void Update()
    {
        if (!photonView.isMine)
        {
            transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
        }
		if (transform.name.Contains("player")){
//			print (transform.position);
			jamesPlayerPos = transform.position;
		}
    }

	public static Vector3 getJamesPlayerPos() {
		return jamesPlayerPos;
	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);

            PlayerMovement myC = GetComponent<PlayerMovement>();
            stream.SendNext((int)myC.speed);

        }
        else
        {
            // Network player, receive data
            this.correctPlayerPos = (Vector3)stream.ReceiveNext();
            this.correctPlayerRot = (Quaternion)stream.ReceiveNext();

            PlayerMovement myC = GetComponent<PlayerMovement>();
            myC.speed= (int)stream.ReceiveNext();

        }
    }
}
