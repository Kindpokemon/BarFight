using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item>();

	void Start () {

		//items.Add (new Item());
		items.Add (new Item(0, "The Stage", Item.ItemType.None, Item.WeaponType.None, 0, 0, 0, 0, 0, 0));
		items.Add (new Item(1, "Chair", Item.ItemType.Weapon, Item.WeaponType.Melee, 20, 5, 0, 0, 0, 0));
		items.Add (new Item(2, "Table", Item.ItemType.PhysicsItem, Item.WeaponType.Melee, 5, 0, 50, 270, 0, 0));
		items.Add (new Item(3, "Potted Plant", Item.ItemType.None, Item.WeaponType.None, 0, 0, 0, 0, 0, 0));
		items.Add (new Item(4, "Pool Cue", Item.ItemType.Weapon, Item.WeaponType.Throwable, 15, 25, 0, 90, 0, 0));
		items.Add (new Item(5, "Doritos", Item.ItemType.Ammo, Item.WeaponType.None, 0, 0, 0, 0, 0, 0));
		items.Add (new Item(6, "Bar Table", Item.ItemType.None, Item.WeaponType.None, 0, 0, 0, 0, 0, 0));
		items.Add (new Item(7, "Pool Triangle", Item.ItemType.Weapon, Item.WeaponType.Throwable, 10, 15, 0, 90, 0, 0));
		items.Add (new Item(8, "Pool Cue Rack", Item.ItemType.Weapon, Item.WeaponType.Melee, 20, 0, 10, 90, 0, 0));
		items.Add (new Item(9, "Pool Table", Item.ItemType.None, Item.WeaponType.None, 0, 0, 0, 0, 0, 0));
		items.Add (new Item(10, "Fist", Item.ItemType.None, Item.WeaponType.None, 5, 0, 0, 0, 0, 0));

		Debug.Log (items.Count + " Items Loaded");
	}

}
