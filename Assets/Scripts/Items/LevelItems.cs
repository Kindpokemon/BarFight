using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelItems : MonoBehaviour {

	public List<Spawnable> levelItems = new List<Spawnable>();

	// Use this for initialization
	void Start () {

		levelItems.Add (new Spawnable("Barstool",25.25F, -9F, 0.48F, 270, 90, 0 ));
		levelItems.Add (new Spawnable("BarTable",11.3F, -8F, 4.6F, 270, 0, 0 ));
		levelItems.Add (new Spawnable("Table",24.8F, -9.76F, -0.48F, 270, 0, 0 ));
		levelItems.Add (new Spawnable("PoolTable",20.72F, -7F, 2.64F, 270, 0, 0 ));
		levelItems.Add (new Spawnable("Potted Plant",24.69F, -9.4F, -4.5F, 270, 0, 0 ));

	}

}