using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour {

	public LevelItems levelitem;
	bool done = false;

	// Use this for initialization
	void Start(){

	}

	void Update () {
		//Debug.Log ("Levelitems: " + levelitem.levelItems.Count);
		if (levelitem.levelItems.Count > 0 && !done) {
			spawnPrefabs();
		}
		
	}

	void spawnPrefabs(){
		if (PhotonNetwork.isMasterClient) {
			for (int i = 0; i < levelitem.levelItems.Count; i++) {
				//Debug.Log("Created object" + 1);
				GameObject prefab = (GameObject)PhotonNetwork.Instantiate (levelitem.levelItems [i].spawnedPrefab, levelitem.levelItems [i].position, Quaternion.Euler (levelitem.levelItems [i].rotation), 0);
				prefab.transform.position = levelitem.levelItems[i].position;
				//Debug.Log(levelitem.levelItems[i].spawnedPrefab);
			}
			done = true;
		}
	}
}
