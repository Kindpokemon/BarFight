using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public GameObject standByCamera;
	SpawnSpot[] spawnSpots;


	// Use this for initialization
	void Start () {
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot> ();
		CloudConnect ();
	}

	void CloudConnect(){
		PhotonNetwork.ConnectUsingSettings( "v0.0.1");
		//PhotonNetwork.offlineMode = true;
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());

	}

	void OnJoinedLobby() {
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed() {
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom() {


		SpawnMyPlayer ();
	}

	void SpawnMyPlayer(){
		if (spawnSpots == null) {
			Debug.Log("No Spawn Spots. Tell the server owner, he's using a custom map.");
			return;
		}
		SpawnSpot mySpawnSpot = spawnSpots[Random.Range (0, spawnSpots.Length)];
		GameObject myPlayerGameObject = (GameObject)PhotonNetwork.Instantiate ("PlayerController", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
		standByCamera.SetActive(false);

		((MonoBehaviour)myPlayerGameObject.GetComponent ("FirstPersonController")).enabled = true;
		myPlayerGameObject.GetComponent<AudioSource>().enabled = true;
		//((MonoBehaviour)myPlayerGameObject.GetComponent ("FirstPersonController")).enabled = true;
		myPlayerGameObject.transform.GetChild (3).gameObject.SetActive (true);

	}
}
