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
			GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
			Debug.Log (doors.Length);
			foreach (GameObject door in doors) {
				Color color = door.GetComponent<Renderer>().material.color;
				color.a = 1;
				door.GetComponent<Renderer>().material.color = color;
			}
			Color newcolor = Door.GetComponent<Renderer>().material.color;
			newcolor.a = 0;
			Door.GetComponent<Renderer>().material.color = newcolor;
			GetComponent<SpriteRenderer>().color = Pressed;
		}
		if (Player.transform.position != transform.position && !permanentActivation) {
			Color color = Door.GetComponent<Renderer>().material.color;
			color.a = 1;
			Door.GetComponent<Renderer>().material.color = color;
			GetComponent<SpriteRenderer>().color = Unpressed;
		}
	}
}
