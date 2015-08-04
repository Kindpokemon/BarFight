using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item>();

	void Start () {

		//items.Add (new Item());
		items.Add (new Item (0, "The Stage", Item.ItemType.Immovable, Item.WeaponType.None, 0, 0, 0));
		items.Add (new Item(1, "Chair", Item.ItemType.Weapon, Item.WeaponType.Melee, 10, 0, 0));
		items.Add (new Item(2, "Table", Item.ItemType.PhysicsItem, Item.WeaponType.None, 0, 0, 0));
		items.Add (new Item(3, "Potted Plant", Item.ItemType.PhysicsItem, Item.WeaponType.None, 0, 0, 0));
		Debug.Log (items.Count + " Items Loaded");
	}

}
