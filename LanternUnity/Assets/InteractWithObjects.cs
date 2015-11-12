using UnityEngine;
using System.Collections;

public class InteractWithObjects : MonoBehaviour {
	public GameObject TileMap;

	private GameObject lantern;
	private TileMap map;
	
	// Use this for initialization
	void Start () {
		map = TileMap.GetComponent<TileMap>();
		lantern = GameObject.FindGameObjectWithTag ("Lantern");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space) && transform.position.x % 10 == 0 && transform.position.y % 10 == 0) {
			if (lantern.GetComponent<PickUpPutDown>().GetIsHeld()) {
				lantern.GetComponent<PickUpPutDown>().SetIsHeld(false);
			} else {
				if (lantern.transform.position == transform.position)
					lantern.GetComponent<PickUpPutDown>().SetIsHeld(true);
			}
		} 
	}
}
