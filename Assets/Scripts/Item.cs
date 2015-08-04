using UnityEngine;
using System.Collections;

public class Item {

	public enum ItemType{
		Weapon,
		PhysicsItem,
		Ammo,
		Immovable
	}

	public enum WeaponType{
		None,
		Melee,
		Throwable,
		Gun
	}

	public int itemId;
	public string itemName;
	public ItemType itemType;
	public WeaponType weaponType;
	public int hitDamage;
	public int throwDamage;
	public int defense;

	public Item(int id, string name, ItemType itype, WeaponType wtype, int hit, int damagethrow, int def){
		itemId = id;
		itemName = name;
		itemType = itype;
		weaponType = wtype;
		hitDamage = hit;
		throwDamage = damagethrow;
		defense = def;
	}

	//public Item(){

	//}
}
