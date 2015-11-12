using UnityEngine;
using System.Collections;

public class PickUpPutDown : MonoBehaviour {
	public GameObject player;
	private bool IsHeld;
	
	// Use this for initialization
	void Start () {
		IsHeld = true;
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
		}
	}

	public bool GetIsHeld() {
		return IsHeld;
	}
}
