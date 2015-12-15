using UnityEngine;
using System.Collections;

public class TileMap : MonoBehaviour {
	private GameObject [,] map = new GameObject[100,100];

	// Use this for initialization
	void Start () {
		//Initialize map
		for (int i = 0; i < 100; i++) {
			for (int j = 0; j < 100; j++) {
				map [i, j] = new GameObject();
			}
		}
		//Set starting map
		GameObject [] goArray = FindObjectsOfType(typeof(GameObject)) as GameObject [];
		for (int i = 0; i < goArray.Length; i++) {
			Vector3 pos = goArray[i].transform.position;
			if (goArray[i].tag == "Wall" || goArray[i].tag == "WallPassBehind" || goArray[i].tag == "WallBoundary" || goArray[i].tag == "Door1" || goArray[i].tag == "Door2" || goArray[i].tag == "Door3" )
				map[(int)pos.x / 10, (int)pos.y / 10] = goArray[i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject getElement(float x, float y) {
		if (x >= 0 && y >= 0) 
			return map [(int)x / 10, (int)y / 10];
		else 
			return new GameObject();
	}

	public string getElementTag(float x, float y) {
		if (x >= 0 && y >= 0) 
			return map[(int)x / 10, (int)y / 10].tag;
		else 
			return "";
	}
	
	public void setElement(float x, float y, GameObject GO) {
		if (x >= 0 && y >= 0) 
			map[(int)x / 10,(int)y / 10] = GO;
	}
}
