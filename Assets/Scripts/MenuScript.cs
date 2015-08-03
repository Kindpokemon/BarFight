using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public enum Menu {
		Menu,
		Local,
		Cloud
	}

	public Menu currentMenu = Menu.Menu;
	const int buttonWidth = 140;
	const int buttonHeight = 60;
	const int smallButtonWidth = 60;
	const int smallButtonHeight = 30;
	public Texture2D buttonTexture;
	public Texture2D buttonHover;
	public Texture2D buttonPress;
	public int sceneNumber = 1;
	public GUIStyle boxStyle;
	public string gdChooser;
	public int totalScenes = 1;


	void Start() {

	}

	void Update() {

	}


	void OnGUI()
	{
		GUI.skin.button.normal.background = buttonTexture;
		GUI.skin.button.hover.background = buttonHover;
		GUI.skin.button.active.background = buttonPress;
		GUI.skin.box = boxStyle;
		GUI.skin.button = boxStyle;

		GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();

		if(currentMenu == Menu.Menu) {

			if(GUILayout.Button("Join Local", new GUILayoutOption[] {GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)})) {
				Application.LoadLevel(1);
			}
			GUILayout.Space(20);

			if(GUILayout.Button("Join the Cloud", new GUILayoutOption[] {GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)})) {
				Application.LoadLevel(1);
			}

			GUILayout.Space(20);

			if(GUILayout.Button("Quit", new GUILayoutOption[] {GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)})) {
				Application.Quit();
			}
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}

}
