using UnityEngine;
using System.Collections;

public class InteractWithObjects : MonoBehaviour {
	public GameObject TileMap;
	
	private GameObject lantern;
	private GameObject key1;
	private GameObject key2;
	private GameObject key3;
	private TileMap map;
	
	// Use this for initialization
	void Start () {
		map = TileMap.GetComponent<TileMap>();
		lantern = GameObject.FindGameObjectWithTag ("Lantern");
		key1 = GameObject.FindGameObjectWithTag ("key1");
		key2 = GameObject.FindGameObjectWithTag ("key2");
		key3 = GameObject.FindGameObjectWithTag ("key3");
	}
	
	// Update is called once per frame
	void Update () {
		handleColor(lantern);
		handleColor(key1);
		handleColor(key2);
		handleColor(key3);

		bool touchPickup = false;
		Vector3 touchpos;
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			touchpos = Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position);
			if (Vector3.Distance (touchpos, transform.position) < 15)
				touchPickup = true; 
		}

		if (touchPickup || (Input.GetKeyDown(KeyCode.Space) && transform.position.x % 10 == 0 && transform.position.y % 10 == 0)) {
			handlePickUpPutDown(lantern);
			handlePickUpPutDown(key1);
			handlePickUpPutDown(key2);
			handlePickUpPutDown(key3);
		}
	}
	
	private void handleColor(GameObject obj) {
		if (obj.GetComponent<PickUpPutDown>().GetIsHeld()) {
			obj.GetComponent<PickUpPutDown>().SetColor("holding");
		} else if (Vector2.Distance(transform.position,obj.transform.position) <= 5) {
			obj.GetComponent<PickUpPutDown>().SetColor("eligible");
		} else {
			obj.GetComponent<PickUpPutDown>().SetColor("ineligible");			
		}
	}
	
	private void handlePickUpPutDown(GameObject obj) {
		if (obj.GetComponent<PickUpPutDown>().GetIsHeld()) {
			obj.GetComponent<PickUpPutDown>().SetIsHeld(false);
		} else {
			if (obj.transform.position == transform.position) {
				obj.GetComponent<PickUpPutDown>().SetIsHeld(true);
			}
		}
	}
	
}
