using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	private Vector3 destination;
	public GameObject TileMap;
	private TileMap map;

	// Use this for initialization
	void Start () {
		destination = transform.position;
		map = TileMap.GetComponent<TileMap>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((transform.position.x) % 10 == 0 && (transform.position.y) % 10 == 0) 
			getDestination();
		if (destination != transform.position)
			move();
	}

	void getDestination() {
		Vector3 position = transform.position;

		if (Input.GetKey(KeyCode.W)) {
			if (map.getElement(position.x, position.y + 10).tag != "Wall")
				position.y += 10;
		} else if (Input.GetKey(KeyCode.A)) {
			if (map.getElement(position.x - 10, position.y).tag != "Wall")
				position.x -= 10;
		} else if (Input.GetKey(KeyCode.S)) {
			if (map.getElement(position.x, position.y - 10).tag != "Wall")
				position.y -= 10;
		} else if (Input.GetKey(KeyCode.D)) {
			if (map.getElement(position.x + 10, position.y).tag != "Wall") 
				position.x += 10;
		}

		destination = position;
	}

	void move() {
		Vector3 newPosition = transform.position;
		if (Mathf.Abs (destination.x - transform.position.x) > Mathf.Abs (destination.y - transform.position.y)) { //move horizontal first
			if (destination.x - transform.position.x > 0) { //move right
				newPosition.x += .5f;
			} else if (destination.x - transform.position.x < 0) { //move left
				newPosition.x -= .5f;
			}
		} else if (Mathf.Abs (destination.x - transform.position.x) < Mathf.Abs (destination.y - transform.position.y)) { //move vertical
			if (destination.y - transform.position.y > 0) { //move up
				newPosition.y += .5f;
			} else if (destination.y - transform.position.y < 0) { //move down
				newPosition.y -= .5f;
			}
		}

		transform.position = newPosition;
	}
}
