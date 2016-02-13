using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour {

	public LevelItems levelitem;
	public bool done = false;

	// Use this for initialization
	void Start(){

	}

	void Update () {
		//Debug.Log ("Levelitems: " + levelitem.levelItems.Count);
		
	}

	public void spawnPrefabs(){
			for (int i = 0; i < levelitem.levelItems.Count; i++) {
				//Debug.Log("Created object" + 1);
				//Debug.Log(levelitem.levelItems[i].spawnedPrefab);
			}
			done = true;
	}
}
