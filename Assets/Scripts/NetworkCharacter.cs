using UnityEngine;
using System.Collections;


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
			this.transform.position = Vector3.Lerp(this.transform.position, realPosition, 0.1f);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, realRotation, 0.1f);
		}
	}
	
	public void onPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {

		if(stream.isWriting) {
			// This is OUR player. We need to send our actual position to the network.
			
			stream.SendNext(myPosition);
			stream.SendNext(myRotation);

			Debug.Log("Sent position: " + myPosition);
			Debug.Log("Sent rotation: " + myRotation);

		}
		else {
			// This is someone else's player. We need to receive their position (as of a few
			// millisecond ago, and update our version of that player.
			
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();

			Debug.Log("Got position: " + realPosition);
			Debug.Log("Got rotation: " + realRotation);

		}
		
	}
}