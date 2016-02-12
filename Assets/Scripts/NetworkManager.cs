using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public GameObject standByCamera;
	public SpawnSpot[] spawnSpots;

	// Use this for initialization
	void Start () {
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot> ();
		CloudConnect ();
	}

	void CloudConnect(){
		PhotonNetwork.ConnectUsingSettings( "v0.0.1");
		Debug.Log ("CloudConnect");
		//PhotonNetwork.offlineMode = true;
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());

	}

	void OnJoinedLobby() {
		PhotonNetwork.JoinRandomRoom ();
		Debug.Log ("Joined Lobby");
	}

	void OnPhotonRandomJoinFailed() {
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom() {
		Debug.Log ("Joined Room!");


		SpawnMyPlayer ();

	}

	public void SpawnMyPlayer(){
		if (spawnSpots == null) {
			Debug.Log("No Spawn Spots. Tell the server owner, he's using a custom map.");
			return;
		}
		SpawnSpot mySpawnSpot = spawnSpots[Random.Range (0, spawnSpots.Length)];
		GameObject myPlayerGameObject = (GameObject)PhotonNetwork.Instantiate ("PlayerController", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
		standByCamera.SetActive(false);

		((MonoBehaviour)myPlayerGameObject.GetComponent ("FirstPersonController")).enabled = true;
		myPlayerGameObject.GetComponent<CharacterController> ().enabled = true;
		myPlayerGameObject.GetComponent<GrabItem> ().enabled = true;
		myPlayerGameObject.GetComponent<EscMenu> ().enabled = true;
		Debug.Log (myPlayerGameObject.GetComponent<GrabItem> ());
		myPlayerGameObject.GetComponent<GrabItem> ().enabled = true;

		myPlayerGameObject.transform.GetChild(0).GetComponent<AudioListener>().enabled = true;
		myPlayerGameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).tag = "MyFist";
		myPlayerGameObject.tag = "Player";
		//((MonoBehaviour)myPlayerGameObject.GetComponent ("FirstPersonController")).enabled = true;
		myPlayerGameObject.transform.GetChild (0).GetComponent<Camera>().enabled = true;

	}
	
}
