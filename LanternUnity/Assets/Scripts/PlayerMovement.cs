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
        Vector3 touchpos;
        if (Input.touchCount > 0)
            touchpos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        else 
            touchpos = transform.position;
        Vector3 position = transform.position;
                
		if (Input.GetKey(KeyCode.W) || (((Mathf.Abs(touchpos.y - position.y) > Mathf.Abs(touchpos.x - position.x) && touchpos.y > position.y) && Vector3.Distance(touchpos, transform.position) > 15) && Input.touchCount > 0)) {
            string tempTag = map.getElementTag(position.x, position.y + 10);
			if (tempTag != "Wall" && tempTag != "WallBoundary" && tempTag != "Door1" && tempTag != "Door2" && tempTag != "Door3")
                position.y += 10;
		} else if (Input.GetKey(KeyCode.A) || (((Mathf.Abs(touchpos.x - position.x) > Mathf.Abs(touchpos.y - position.y) && touchpos.x < position.x) && Vector3.Distance(touchpos, transform.position) > 15) && Input.touchCount > 0)) {
            string tempTag = map.getElementTag(position.x - 10, position.y);
			if (tempTag != "Wall" && tempTag != "WallBoundary" && tempTag != "Door1" && tempTag != "Door2" && tempTag != "Door3")
                position.x -= 10;
		} else if (Input.GetKey(KeyCode.S) || (((Mathf.Abs(touchpos.y - position.y) > Mathf.Abs(touchpos.x - position.x) && touchpos.y < position.y) && Vector3.Distance(touchpos, transform.position) > 15) && Input.touchCount > 0)) {
            string tempTag = map.getElementTag(position.x, position.y - 10);
			if (tempTag != "Wall" && tempTag != "WallBoundary" && tempTag != "Door1" && tempTag != "Door2" && tempTag != "Door3")
                position.y -= 10;
		} else if (Input.GetKey(KeyCode.D) || (((Mathf.Abs(touchpos.x - position.x) > Mathf.Abs(touchpos.y - position.y) && touchpos.x > position.x) && Vector3.Distance(touchpos, transform.position) > 15) && Input.touchCount > 0)) {
            string tempTag = map.getElementTag(position.x + 10, position.y);
			if (tempTag != "Wall" && tempTag != "WallBoundary" && tempTag != "Door1" && tempTag != "Door2" && tempTag != "Door3") 
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
