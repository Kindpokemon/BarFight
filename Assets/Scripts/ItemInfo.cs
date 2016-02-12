using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemInfo : MonoBehaviour {

	public int myId;
	ItemDatabase database;
	public Item item;
	public bool canPickUp = true;

	void Start(){
		database = GameObject.FindGameObjectWithTag ("A").GetComponent<ItemDatabase> ();
		GetComponent<PhotonView> ().ownershipTransfer = OwnershipOption.Takeover;
	}
	void Update(){
		//database = GameObject.FindGameObjectWithTag ("A").GetComponent<ItemDatabase> ();
		//Debug.Log ("Is it active: "+database.isActiveAndEnabled);
		//Debug.Log ("Items in the database: "+database.items.Count);
		if (database.items.Count > 0) {
			AssignItem ();
		}

	}
	public void AssignItem(){
		for(int i = 0; i < database.items.Count; i++){
			//Debug.Log(i);
			if(database.items[i].itemId == myId){

				item = database.items[i];
				if(item.itemType == Item.ItemType.None){
					canPickUp = false;
				}
				//Debug.Log(item.itemType);
				//Debug.Log ("Loaded "+item.itemName);
				break;
			}
		}
	}
}
