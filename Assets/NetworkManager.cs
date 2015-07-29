using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Connect ();	
	}

	void Connect(){
		PhotonNetwork.ConnectUsingSettings( "v0.0.1");
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());

	}

	void OnJoinedLobby() {
		PhotonNetwork.JoinRandomRoom ();
	}
}
