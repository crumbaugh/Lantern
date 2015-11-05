using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	private Vector3 destination;

	// Use this for initialization
	void Start () {
		destination = transform.position;
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
		if (Input.GetKeyDown(KeyCode.W)) {
			position.y += 10;
			destination = position;
		}
		if (Input.GetKeyDown(KeyCode.A)) {
			position.x -= 10;
			destination = position;
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			position.y -= 10;
			destination = position;
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			position.x += 10;
			destination = position;
		}
	}

	void move() {
		Vector3 newPosition = transform.position;
		if (Mathf.Abs (destination.x - transform.position.x) > Mathf.Abs (destination.y - transform.position.y)) { //move horizontal first
			if (destination.x - transform.position.x > 0) { //move right
				newPosition.x += 1f;
			} else if (destination.x - transform.position.x < 0) { //move left
				newPosition.x -= 1f;
			}
		} else if (Mathf.Abs (destination.x - transform.position.x) < Mathf.Abs (destination.y - transform.position.y)) { //move vertical
			if (destination.y - transform.position.y > 0) { //move up
				newPosition.y += 1f;
			} else if (destination.y - transform.position.y < 0) { //move down
				newPosition.y -= 1f;
			}
		}
		//newPosition.x = newPosition.x % 1f;
		//newPosition.y = newPosition.y % 1f;
		//newPosition.z = 0f;
		transform.position = newPosition;
	}
}
