using UnityEngine;
using System.Collections;

[System.Serializable]
public class NetworkPlayerCharacter : Photon.MonoBehaviour {
	
	public Vector3 itemRealPosition = Vector3.zero;
	public Quaternion itemRealRotation = Quaternion.identity;
	public Quaternion itemRealHeadRotation;
	public Vector3 myItemPosition;
	public Quaternion myItemRotation;
	public Quaternion myHeadRotation;
	public Vector3 lastPosition;
	public Quaternion lastRotation;
	public Quaternion lastHeadRotation;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( photonView.isMine ) {
			myItemPosition = this.transform.position;
			myItemRotation = this.transform.rotation;
			myHeadRotation = this.transform.GetChild(0).rotation;
		}
		else {
			//Debug.Log(this.transform.position);
			//Debug.Log(realPosition);
			myItemPosition = itemRealPosition;
			myItemRotation = itemRealRotation;
			this.transform.position = Vector3.Lerp(this.lastPosition, this.itemRealPosition, Time.deltaTime * 10F);
			this.transform.rotation = Quaternion.Lerp(this.lastRotation, this.itemRealRotation, Time.deltaTime * 10F);
			this.transform.GetChild(0).rotation = Quaternion.Lerp(this.lastHeadRotation, this.itemRealHeadRotation, Time.deltaTime * 10F);
		}
	}
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{

		if (stream.isWriting) {
			//We own this player: send the others our data
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
			stream.SendNext (this.transform.GetChild(0).rotation);
		} else {
			//Network player, receive data
			this.lastPosition = this.transform.position;
			this.lastRotation = this.transform.rotation;
			this.itemRealHeadRotation = this.transform.GetChild(0).rotation;
			this.itemRealPosition = (Vector3)stream.ReceiveNext ();
			this.itemRealRotation = (Quaternion)stream.ReceiveNext ();
			this.itemRealHeadRotation = (Quaternion)stream.ReceiveNext();
		}
	}
}