using UnityEngine;
using System.Collections;

public class GrabItem : MonoBehaviour {
	public Ray ray;
	public RaycastHit hit;

	//Tab + e is pick up as physics object

	// Use this for initialization
	void Start () {
	
	}
	
	void  Update (){
		// Get the ray going through the GUI position
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		// Do a raycast
		if (Physics.Raycast (ray, out hit, 1000.0f)) {
			print ("I'm looking at " + hit.transform.name);
			if(hit.transform.GetComponent<ItemInfo>().item.itemId > 0){
				Debug.Log(hit.transform.GetComponent<ItemInfo>().item.itemId);
			}
		} else {
			print ("I'm looking at nothing!");
		}

	}
}
