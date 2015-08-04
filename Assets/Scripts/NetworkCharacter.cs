using UnityEngine;
using System.Collections;

[System.Serializable]
public class NetworkCharacter : Photon.MonoBehaviour {
	
	public Vector3 realPosition = Vector3.zero;
	public Quaternion realRotation = Quaternion.identity;
	public Vector3 myPosition;
	public Quaternion myRotation;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( photonView.isMine ) {
			myPosition = this.transform.position;
			myRotation = this.transform.rotation;
		}
		else {
			//Debug.Log(this.transform.position);
			//Debug.Log(realPosition);
			myPosition = realPosition;
			myRotation = realRotation;
			this.transform.position = Vector3.Lerp(this.transform.position, this.realPosition, Time.deltaTime);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.realRotation, Time.deltaTime);
		}
	}
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		Debug.Log ("yes");

		if (stream.isWriting) {
			//We own this player: send the others our data
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
		} else {
			//Network player, receive data
			this.realPosition = (Vector3)stream.ReceiveNext ();
			this.realRotation = (Quaternion)stream.ReceiveNext ();
		}
	}
}