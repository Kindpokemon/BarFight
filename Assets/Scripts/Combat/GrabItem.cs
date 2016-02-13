using UnityEngine;
using System.Collections;

public class GrabItem : MonoBehaviour {
	public Ray ray;
	public RaycastHit hit;
	public GameObject hand;
	public GameObject arm;
	public GameObject oldArm;
	GameObject itemInHand;
	public GameObject currentlyHolding;
	public bool holdingItem;
	GameObject staticObjects;
	public GameObject playerCamera;
	public float thrust;
	public Rigidbody rb;
	public GameObject fist;
	public bool attacking = false;
	public PunchCollider punchCollider;
	public bool waiting;
	public bool shutDown = false;

	//Tab + e is pick up as physics object
	
	// Use this for initialization
	void Start () {
		staticObjects = GameObject.FindGameObjectWithTag("StaticObjects");

		fist = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject;
		//Debug.Log (transform.GetChild (0).GetChild (0).GetChild (0).GetChild (1).gameObject);
	}
	
	void  Update (){
		if (!shutDown) {
			// Get the ray going through the GUI position
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			// Do a raycast
			if (Physics.Raycast (ray, out hit, 500.0f)) {
			
				//print ("I'm looking at " + hit.transform.name);
				itemInHand = hit.transform.gameObject;
				//Debug.Log(itemInHand.GetComponent<ItemInfo>().item.itemName);
				testForGrab (itemInHand);
			
			} else {
			
			}
		
			if (Input.GetKeyDown (KeyCode.Q) && holdingItem && currentlyHolding != null) {
				dropShit (currentlyHolding, staticObjects);
			
			}
		
			if (currentlyHolding != null) {
			
				currentlyHolding.GetComponent<Rigidbody> ().AddForce (transform.forward * thrust);
			}

			if (Input.GetMouseButtonDown (0) && attacking == false) {
				//Debug.Log ("Punching");
				//Debug.Log ("Attacking: " + attacking);
				if (holdingItem == true) {
					bash (currentlyHolding);
				} else {
					StartCoroutine (Punch ());
				}
			}
		}
	}
	
	public void testForGrab(GameObject hitThing){
		if (Input.GetKeyDown (KeyCode.E) && hitThing.transform.GetComponent<ItemInfo> ().item.itemType != Item.ItemType.None && !holdingItem && currentlyHolding == null && !attacking && hitThing.GetComponent<ItemInfo> ().canPickUp == true
		    ) {
			grabShit (hitThing);
		}
	}
	
	public void grabShit(GameObject handItem){
		
		holdingItem = true;
		handItem.GetComponent<ItemInfo> ().canPickUp = false;
		currentlyHolding = handItem;
		arm.SetActive (true);
		oldArm.SetActive (false);
		handItem.transform.SetParent (hand.transform);
		handItem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

		if(handItem.transform.parent == hand){
			arm.transform.rotation = Quaternion.AngleAxis(50, Vector3.up);
			hand.transform.rotation = Quaternion.AngleAxis(50, Vector3.up);
		}
		while(handItem.transform.localPosition != Vector3.zero && handItem.transform.localEulerAngles != handItem.GetComponent<ItemInfo>().item.rotation){
			
			handItem.transform.localPosition = Vector3.zero;
			handItem.transform.localEulerAngles = handItem.transform.GetComponent<ItemInfo>().item.rotation;
		}
		
	}
	
	public void dropShit(GameObject heldItem, GameObject stage){
		heldItem.transform.SetParent (null);
		heldItem.transform.GetComponent<Rigidbody>().useGravity = true;
		heldItem.transform.GetComponent<MeshCollider>().enabled = true;
		heldItem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		heldItem.GetComponent<ItemInfo> ().canPickUp = true;

		arm.SetActive (true);
		oldArm.SetActive (false);
		holdingItem = false;
		currentlyHolding = null;
	}

	IEnumerator Punch(){
		return null;
	}

	public void bash(GameObject bashItem){

	}
	
}
