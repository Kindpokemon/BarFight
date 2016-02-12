using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EscMenu : MonoBehaviour {

	CursorLockMode wantedMode = CursorLockMode.Confined;
	public GUIStyle boxStyle;
	public Texture2D buttonTexture;
	public Texture2D buttonHover;
	public Texture2D buttonPress;
	const int buttonWidth = 140;
	const int buttonHeight = 60;
	public bool activeEsc;
	public GameObject player;
	public PhotonPlayer newMaster;
	public HealthController hController;

	void Start(){
		hController = gameObject.GetComponent<HealthController> ();
	}

	// Apply requested cursor state
	void SetCursorState ()
	{
		Cursor.lockState = wantedMode;
		// Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != wantedMode);

	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			activeEsc = !activeEsc;
		}
		if (activeEsc) {
			wantedMode = CursorLockMode.None;
			((MonoBehaviour)player.GetComponent ("FirstPersonController")).enabled = false;
			((MonoBehaviour)player.GetComponent ("GrabItem")).enabled = false;

		} else {
			wantedMode = CursorLockMode.Locked;
			((MonoBehaviour)player.GetComponent ("FirstPersonController")).enabled = true;
			((MonoBehaviour)player.GetComponent ("GrabItem")).enabled = true;

		}

		SetCursorState();
	}
	
	void OnGUI ()
	{

		if (activeEsc) {
			GUI.skin.button.normal.background = buttonTexture;
			GUI.skin.button.hover.background = buttonHover;
			GUI.skin.button.active.background = buttonPress;
			GUI.skin.box = boxStyle;
			GUI.skin.button = boxStyle;
		
			GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height));
			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
			GUILayout.BeginVertical ();
			GUILayout.FlexibleSpace ();

			
			if (GUILayout.Button ("Respawn", new GUILayoutOption[] {
				GUILayout.Width (buttonWidth),
				GUILayout.Height (buttonHeight)
			})) {
				StartCoroutine(hController.KillMe());
			}

			GUILayout.Space (20);
			
			if (GUILayout.Button ("Options", new GUILayoutOption[] {
				GUILayout.Width (buttonWidth),
				GUILayout.Height (buttonHeight)
			})) {
				
			}
			
			GUILayout.Space (20);
			
			if (GUILayout.Button ("Quit to Menu", new GUILayoutOption[] {
				GUILayout.Width (buttonWidth),
				GUILayout.Height (buttonHeight)
			})) {
				if(PhotonNetwork.player.isMasterClient){
					for(int l = 0; l < 100; l++){
						if(PhotonPlayer.Find(l) != null && PhotonPlayer.Find(l) != PhotonNetwork.player){
							newMaster = PhotonPlayer.Find(l);
							PhotonNetwork.SetMasterClient(newMaster);
							break;
						}

					}
				}
				PhotonNetwork.Disconnect();
				Application.LoadLevel (0);
			}
		
			GUILayout.FlexibleSpace ();
			GUILayout.EndVertical ();
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			GUILayout.EndArea ();
		}
	}
}