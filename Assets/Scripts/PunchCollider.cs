using UnityEngine;
using System.Collections;

public class PunchCollider : MonoBehaviour {

	public bool punchCollide;
	public GameObject colliding;

	public void OnCollisionEnter(Collision collision){
		Debug.Log("Yaaay");
		punchCollide = true;
		colliding = collision.gameObject;
	}

	public void OnCollisionExit(Collision other){
		punchCollide = false;
		colliding = null;
	}
}
