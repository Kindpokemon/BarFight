using UnityEngine;
using System.Collections;

public class Item {

	public enum ItemType{
		Weapon,
		PhysicsItem,
		Ammo,
		None
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
	public Vector3 rotation;

	public Item(int id, string name, ItemType itype, WeaponType wtype, int hit, int damagethrow, int def, float xRotate, float yRotate, float zRotate){
		itemId = id;
		itemName = name;
		itemType = itype;
		weaponType = wtype;
		hitDamage = hit;
		throwDamage = damagethrow;
		defense = def;
		rotation.x = xRotate;
		rotation.y = yRotate;
		rotation.z = zRotate;
	}

	//public Item(){

	//}
}
