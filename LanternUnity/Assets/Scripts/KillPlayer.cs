using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {
	private GameObject Player;
	private GameObject Lantern;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Lantern = GameObject.FindGameObjectWithTag ("Lantern");
	}
	
	// Update is called once per frame
	void Update () {
		if (Lantern.transform.position == transform.position) {
			Application.LoadLevel(Application.loadedLevelName);
		}
	}
}
