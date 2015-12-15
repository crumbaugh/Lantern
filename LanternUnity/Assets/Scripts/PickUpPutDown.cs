﻿using UnityEngine;
using System.Collections;

public class PickUpPutDown : MonoBehaviour {
	public GameObject player;
	public Color downColor;
	public Color eligibleColor;
	public Color heldColor;
	private bool IsHeld;
	private GameObject door;
	private bool isKey;

	// Use this for initialization
	void Start () {
		if ((Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag ("Lantern").transform.position)) == 0) {
			IsHeld = true;
			isKey = false;
			GetComponent<SpriteRenderer>().color = heldColor;
		} else {
			if ((Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag ("key1").transform.position)) == 0) {
				door = GameObject.FindGameObjectWithTag("Door1");
			}
			if ((Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag ("key2").transform.position)) == 0) {
				door = GameObject.FindGameObjectWithTag("Door2");
			}
			if ((Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag ("key3").transform.position)) == 0) {
				door = GameObject.FindGameObjectWithTag("Door3");
			}
			IsHeld = false;
			isKey = true;
			GetComponent<SpriteRenderer>().color = downColor;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (IsHeld) {
			transform.position = player.transform.position;
			if (isKey) {
				openDoor();
			}
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
	
	public void openDoor() {
		if ((Vector2.Distance(transform.position, door.transform.position)) < 10) {
			Color newcolor = door.GetComponent<Renderer>().material.color;
			newcolor.a = 0;
			door.GetComponent<Renderer>().material.color = newcolor;
			transform.GetComponent<Renderer>().material.color= newcolor;
		}
	}
}
