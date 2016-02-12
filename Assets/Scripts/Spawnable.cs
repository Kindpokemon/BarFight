using UnityEngine;
using System.Collections;

public class Spawnable {

	public string spawnedPrefab;
	public Vector3 position;
	public Vector3 rotation;

	public Spawnable(string theItem, float xPos, float yPos, float zPos, float xRotate, float yRotate, float zRotate){
		spawnedPrefab = theItem;
		position.x = xPos;
		position.y = yPos;
		position.z = zPos;
		rotation.x = xRotate;
		rotation.y = yRotate;
		rotation.z = zRotate;

	}

	public Spawnable(){
		
	}
}
