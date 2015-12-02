using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	public GameObject Door;
	public Color Unpressed;
	public Color Pressed;
	public bool permanentActivation;

	private GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		GetComponent<SpriteRenderer>().color = Unpressed;
		//Door.AddComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.transform.position == transform.position) {
			Door.SetActive(false);
			GetComponent<SpriteRenderer>().color = Pressed;
		}
		if (Player.transform.position != transform.position && !permanentActivation) {
			Door.SetActive(true);
			GetComponent<SpriteRenderer>().color = Unpressed;
		}
	}
}
