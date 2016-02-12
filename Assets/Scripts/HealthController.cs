using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

	public RectTransform healthTransform;
	private float cachedY;
	private float minXValue;
	private float maxXValue;
	public Text healthText;
	public float coolDown;
	public bool onCD;
	public bool healthShowing;
	public GameObject theWholeThing;
	public int myHealth;
	public int maxHealth;
	public EscMenu escMenu;
	public GameObject canvas;
	public NetworkManager networkManager;
	public bool overRide;

	public int CurrentHealth
	{
		get { return myHealth;}
		set {
			myHealth = value;
			HandleHealth();
		}
		
	}
	
	// Use this for initialization
	void Start () {
		canvas = GameObject.FindGameObjectWithTag ("HealthCanvas");
		networkManager = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<NetworkManager>();



		//Debug.Log (canvas);
		theWholeThing = canvas.transform.GetChild(0).gameObject;
		healthText = canvas.transform.GetChild(0).GetChild(0).GetComponent<Text>();
		//Debug.Log (healthText);
		healthTransform = canvas.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<RectTransform>();
		maxHealth = 100;
		myHealth = 100;

		cachedY = healthTransform.position.y;
		maxXValue = healthTransform.position.x;
		minXValue = healthTransform.position.x - healthTransform.rect.width;
		coolDown = 3;
		HandleHealth ();
		healthShowing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (escMenu.activeEsc == true || overRide == true) {
			theWholeThing.SetActive(false);
		} else {
			theWholeThing.SetActive(true);
		}
	}
	
	IEnumerator CoolDownDmg()
	{
		onCD = true;
		yield return new WaitForSeconds (coolDown);
		onCD = false;
	}
	
	
	
	private void HandleHealth()
	{
		healthText.text = "Health: " + myHealth;
		
		float currentXValue = MapValues (myHealth, 0, maxHealth, minXValue, maxXValue);
		
		healthTransform.position = new Vector2 (currentXValue, cachedY);
	}
	
	private float MapValues(float x, int inMin, int inMax, float outMin, float outMax)
	{
		return((x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin);
	}
	
	public void DamageHandle(int damageDealt)
	{
		if (!onCD && myHealth > 0) {
			StartCoroutine (CoolDownDmg ());
			CurrentHealth -= damageDealt;
		}
		
	}

	public IEnumerator KillMe(){

		GameObject.FindGameObjectWithTag ("Player").GetComponent<GrabItem> ().shutDown = true;
		GameObject.FindGameObjectWithTag ("Player").transform.GetChild(0).gameObject.SetActive(false);
		GameObject.FindGameObjectWithTag ("Player").transform.GetChild(1).gameObject.SetActive(false);
		escMenu.activeEsc = false;
		overRide = true;
		networkManager.standByCamera.SetActive (true);
		Debug.Log("Beginning Wait");
		yield return new WaitForSeconds (3);
		Debug.Log("Fixing Health");
		CurrentHealth = maxHealth;
		Debug.Log("Respawning");
		SpawnSpot spawnspot = networkManager.spawnSpots [Random.Range (0, networkManager.spawnSpots.Length)];
		GameObject.FindGameObjectWithTag ("Player").transform.position = spawnspot.transform.position;
		GameObject.FindGameObjectWithTag ("Player").transform.rotation = spawnspot.transform.rotation;
		networkManager.standByCamera.SetActive (false);
		overRide = false;

		GameObject.FindGameObjectWithTag ("Player").transform.GetChild(0).gameObject.SetActive(true);
		GameObject.FindGameObjectWithTag ("Player").transform.GetChild(1).gameObject.SetActive(true);
		GameObject.FindGameObjectWithTag ("Player").GetComponent<GrabItem> ().shutDown = false;
	}
}
