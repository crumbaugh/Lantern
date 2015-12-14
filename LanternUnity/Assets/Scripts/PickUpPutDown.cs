using UnityEngine;
using System.Collections;

public class PickUpPutDown : MonoBehaviour {
	public GameObject player;
	public Color downColor;
	public Color heldColor;
	public Color eligibleColor;
	private bool IsHeld;
	
	// Use this for initialization
	void Start () {
		if ((Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag ("Lantern").transform.position)) == 0) {
			IsHeld = true;
			GetComponent<SpriteRenderer>().color = heldColor;
		} else {
			IsHeld = false;
			GetComponent<SpriteRenderer>().color = downColor;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (IsHeld) {
			transform.position = player.transform.position;
		}
	}

	
	public void SetIsHeld(bool b) {
		IsHeld = b;
		if (!IsHeld) {
			Vector3 temp = transform.position;
			temp.x = (int)temp.x / 10;
			temp.x = temp.x * 10;
			temp.y = (int)temp.y / 10;
			temp.y = temp.y * 10;
			transform.position = temp;
			SetColor("holding");
		} else {
			SetColor("ineligible");
		}
	}
	
	public bool GetIsHeld() {
		return IsHeld;
	}
	
	public void SetColor(string status) {
		if (status == "holding") {
			GetComponent<SpriteRenderer>().color = heldColor;
			return;
		}
		if (status == "eligible") {
			GetComponent<SpriteRenderer>().color = eligibleColor;
			return;
		}
		GetComponent<SpriteRenderer>().color = downColor;
	}
}
