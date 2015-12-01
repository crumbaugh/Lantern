using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	public GameObject Door;
	public Color Pressed;

	private GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.transform.position == transform.position) {
			Destroy(Door);
			GetComponent<SpriteRenderer>().color = Pressed;
		}
	}
}
