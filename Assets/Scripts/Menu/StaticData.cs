using UnityEngine;
using System.Collections;

public class StaticData : MonoBehaviour {

	public int players;
	public int stageNumber;
	public int[] playerColors;
	public string[] playerNames;
	public string[] colorNames;
	/////////Settings//////////
	public float glare;

	void Start(){
		GameObject.DontDestroyOnLoad(this);
	}
}
