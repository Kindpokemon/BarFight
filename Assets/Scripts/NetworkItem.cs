using UnityEngine;
using System.Collections;

[System.Serializable]
public class NetworkItem : Photon.MonoBehaviour {

	public Vector3 realPosition = Vector3.zero;
	public Quaternion realRotation = Quaternion.identity;
	public Vector3 myPosition;
	public Quaternion myRotation;
	public GrabItem grabItem;

	public bool realHolding;
	public int realHoldingWhat;
	public string realParent;
	public bool myHolding;
	public int myHoldingWhat;
	public string myParent;
	public Vector3 lastPosition;
	public Quaternion lastRotation;

	public int holdingWhat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (grabItem == null) {

			grabItem = GameObject.FindGameObjectWithTag("Player").GetComponent<GrabItem>();

		}
		//Debug.Log ("Owner Id of " + transform.name + " : " + photonView.ownerId);
		if( photonView.isMine ) {
			myPosition = this.transform.position;
			myRotation = this.transform.rotation;
			if(this.transform.parent != null){

				holdingWhat = grabItem.gameObject.GetComponent<PhotonView>().viewID;
				//Debug.Log(holdingWhat + " and " + grabItem.gameObject.GetComponent<PhotonView>());
				myHolding = true;

			} else {


				myHolding = false;

			}

		}
		else {
			//Debug.Log(this.transform.position);
			//Debug.Log(realPosition);
			myPosition = realPosition;
			myRotation = realRotation;
			myHoldingWhat = realHoldingWhat;
			myHolding = realHolding;
			this.transform.position = Vector3.Lerp(this.lastPosition, this.realPosition, Time.deltaTime * 10F);
			this.transform.rotation = Quaternion.Slerp(this.lastRotation, this.realRotation, Time.deltaTime * 10F);

			if(realHolding == true && realHoldingWhat != PhotonNetwork.masterClient.ID){
				this.transform.parent = PhotonView.Find(realHoldingWhat).gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform;
				this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

				PhotonView.Find(realHoldingWhat).gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
				PhotonView.Find(realHoldingWhat).gameObject.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);

				while(this.transform.localPosition != Vector3.zero && this.transform.localEulerAngles != this.GetComponent<ItemInfo>().item.rotation){
					
					this.transform.localPosition = Vector3.zero;
					this.transform.localEulerAngles = this.transform.GetComponent<ItemInfo>().item.rotation;
				}
			} else {
				//Debug.Log("Disabled");
				while(this.realHolding == false){
					//Debug.Log("Disabled 1");
					this.transform.parent = null;
					//Debug.Log("Disabled 2");
					PhotonView.Find(realHoldingWhat).gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
					//Debug.Log("Disabled 3");
					PhotonView.Find(realHoldingWhat).gameObject.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
					//Debug.Log("Disabled 4");
					this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
					//Debug.Log("Disabled 5");
					//Debug.Log("Rigidbodied");
					//Debug.Log("Hiding");
				}
			}
		}
	}
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {

		if (stream.isWriting) {
			stream.SendNext (this.transform.position);
			stream.SendNext (this.transform.rotation);
			stream.SendNext(grabItem.holdingItem);
			stream.SendNext(holdingWhat);
			
		} else {
			this.lastPosition = this.transform.position;
			this.lastRotation = this.transform.rotation;
			this.realPosition = (Vector3)stream.ReceiveNext ();
			this.realRotation = (Quaternion)stream.ReceiveNext ();
			this.realHolding = (bool)stream.ReceiveNext();
			this.realHoldingWhat = (int)stream.ReceiveNext();
		}
	}
}
