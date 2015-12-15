using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	public GameObject Door;
	public Sprite sprite1;
	public Sprite sprite2;
	public bool permanentActivation;

	private SpriteRenderer spriteRenderer;

	private GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = sprite1;
		//Door.AddComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.transform.position == transform.position) {
			GameObject[] doors = GameObject.FindGameObjectsWithTag("Door2");
			foreach (GameObject door in doors) {
				Color color = door.GetComponent<Renderer>().material.color;
				color.a = 1;
				door.GetComponent<Renderer>().material.color = color;
			}
			Color newcolor = Door.GetComponent<Renderer>().material.color;
			newcolor.a = 0;
			Door.GetComponent<Renderer>().material.color = newcolor;

			spriteRenderer.sprite = sprite2;
			Door.tag = "Door";

		}
		if (Player.transform.position != transform.position && !permanentActivation) {
			Color color = Door.GetComponent<Renderer>().material.color;
			color.a = 1;
			Door.GetComponent<Renderer>().material.color = color;
			spriteRenderer.sprite = sprite1;
		}
	}
}
