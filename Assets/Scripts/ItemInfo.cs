using UnityEngine;
using System.Collections;

public class ItemInfo : MonoBehaviour {

	public Item item;
	public int myId;
	ItemDatabase database;

	void Start(){
		database = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDatabase> ();
		Debug.Log (database);
		Debug.Log (database.items.Count);
		AssignItem ();
	}

	public void AssignItem(){

		for(int i = 0; i < 4; i++){
			if(database.items[i].itemId == myId){
				item = database.items[i];
			}
		}
	}
	
}
