using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public enum Menu {
		Menu,
		LevelSel,
		PlayerSel,
		Options,
		Codes
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
	public List<string> scenes;
	public List<int> sceneNumbers;
	public int loadedScenes = 1;
	public StaticData staticData;
	public int playerCount;
	public int[] color;

	void Start() {
		staticData = GameObject.FindGameObjectWithTag ("Gamedata").GetComponent<StaticData>();
		playerCount = 1;
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

			if(GUILayout.Button("Start Match", new GUILayoutOption[] {GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)})) {
				currentMenu = Menu.LevelSel;
			}
			GUILayout.Space(20);

			if(GUILayout.Button("Options", new GUILayoutOption[] {GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)})) {
				
			}

			GUILayout.Space(20);

			if(GUILayout.Button("Quit", new GUILayoutOption[] {GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)})) {
				Application.Quit();
			}
		}

		if (currentMenu == Menu.LevelSel) {
			GUILayout.Box ("Select Level", new GUILayoutOption[] {GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)});
			GUILayout.Space (10);

			foreach (int sceneNum in sceneNumbers) {
				if (GUILayout.Button (scenes[sceneNum-1], new GUILayoutOption[] {
					GUILayout.Width (buttonWidth),
					GUILayout.Height (buttonHeight)
				})) {
					staticData.stageNumber = sceneNum;
					Debug.Log (staticData.stageNumber);
					currentMenu = Menu.PlayerSel;
				}
			}
		}

		if (currentMenu == Menu.PlayerSel) {
			
			if (GUILayout.Button ("Players: " + playerCount, new GUILayoutOption[] {
				GUILayout.Width (180),
				GUILayout.Height (30)
			})) {
				if (playerCount == 4) {
					playerCount = 1;
				} else {
					playerCount++;
				}
			}
			GUILayout.Space (10);

			for (int i = 0; i < playerCount; i++) {
				Debug.Log (i);
				int playerNum = i;
				GUILayout.Box ("Player 1 Name and Color", GUILayout.Width (180), GUILayout.Height(30));
				GUILayout.Space (5);
				staticData.playerNames[playerNum] = GUILayout.TextField (staticData.playerNames[playerNum], 20, GUILayout.Width (180), GUILayout.Height(30));
				GUILayout.Space (5);
				if (GUILayout.Button (staticData.colorNames[color[i]], new GUILayoutOption[] {
					GUILayout.Width (180),
					GUILayout.Height (30)
				})) {
					Debug.Log (staticData.colorNames.Length);
					if (color[i] == staticData.colorNames.Length-1) {
						color[i] = 0;
					} else {
						color[i]++;
					}
				}
				GUILayout.Space (10);
			}

			if (GUILayout.Button ("Begin Brawl", new GUILayoutOption[] {
				GUILayout.Width (180),
				GUILayout.Height (30)
			})) {
				staticData.players = playerCount;
				Debug.Log (staticData.players);
				SceneManager.LoadScene(staticData.stageNumber);

			}
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}

}
