using UnityEngine;
using System.Collections;

public class lightSource : MonoBehaviour {
	public GameObject shadow;
	public GameObject TileMap;
	private TileMap map;
	
	// Use this for initialization
	void Start () {
		map = TileMap.GetComponent<TileMap>();
	}
	
	// Update is called once per frame
	void Update () {
		cleanseShadows();
		revertSortingOrders();
		GameObject [] goArray = FindObjectsOfType(typeof(GameObject)) as GameObject [];
		for (int i = 0; i < goArray.Length; i++) {
			Vector3 [] vertices = new Vector3[4];

			if (goArray[i].layer == 8 && Vector3.Distance(transform.position, goArray[i].transform.position) < 45) {
				vertices = getVertices(goArray[i]);

				Mesh mesh = new Mesh();
				mesh.vertices = vertices;
				mesh.triangles = new int[] {0,1,2, 1,2,3, 0,2,3};
		
				GameObject tempShadow = Instantiate(shadow, Vector3.zero, Quaternion.identity) as GameObject;
				tempShadow.GetComponent<MeshFilter>().mesh = mesh;
				tempShadow.GetComponent<MeshCollider>().sharedMesh = mesh;

				float distance = Vector3.Distance(transform.position, goArray[i].transform.position);
				tempShadow.GetComponent<MeshRenderer>().sortingOrder = -(int)Mathf.Floor(distance) - 1;

				if (-(int)Mathf.Floor(distance) > goArray[i].GetComponentInChildren<SpriteRenderer>().sortingOrder) {
					goArray[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = -(int)Mathf.Floor(distance);
					UpdateNeighbors(goArray[i]);
				}
			}
		}
	}

	void UpdateNeighbors(GameObject go){
		GameObject rightNeighbor = map.getElement (go.transform.position.x + 10, go.transform.position.y);
		if (rightNeighbor.tag == "Wall" || rightNeighbor.tag == "WallPassBehind" || rightNeighbor.tag == "WallBoundary") {
			if (rightNeighbor.GetComponentInChildren<SpriteRenderer>().sortingOrder < go.GetComponentInChildren<SpriteRenderer>().sortingOrder) {
				rightNeighbor.GetComponentInChildren<SpriteRenderer>().sortingOrder = go.GetComponentInChildren<SpriteRenderer>().sortingOrder;
				UpdateNeighbors (rightNeighbor);
			}
		}
		GameObject leftNeighbor = map.getElement (go.transform.position.x - 10, go.transform.position.y);
		if (leftNeighbor.tag == "Wall" || leftNeighbor.tag == "WallPassBehind" || leftNeighbor.tag == "WallBoundary") {
			if (leftNeighbor.GetComponentInChildren<SpriteRenderer>().sortingOrder < go.GetComponentInChildren<SpriteRenderer>().sortingOrder) {
				leftNeighbor.GetComponentInChildren<SpriteRenderer>().sortingOrder = go.GetComponentInChildren<SpriteRenderer>().sortingOrder;
				UpdateNeighbors (leftNeighbor);
			}
		}
		GameObject aboveNeighbor = map.getElement (go.transform.position.x, go.transform.position.y + 10);
		if (aboveNeighbor.tag == "Wall" || aboveNeighbor.tag == "WallPassBehind" || aboveNeighbor.tag == "WallBoundary") {
			if (aboveNeighbor.GetComponentInChildren<SpriteRenderer>().sortingOrder < go.GetComponentInChildren<SpriteRenderer>().sortingOrder) {
				aboveNeighbor.GetComponentInChildren<SpriteRenderer>().sortingOrder = go.GetComponentInChildren<SpriteRenderer>().sortingOrder;
				UpdateNeighbors (aboveNeighbor);
			}
		}
		GameObject belowNeighbor = map.getElement (go.transform.position.x, go.transform.position.y - 10);
		if (belowNeighbor.tag == "Wall" || belowNeighbor.tag == "WallPassBehind" || belowNeighbor.tag == "WallBoundary") {
			if (belowNeighbor.GetComponentInChildren<SpriteRenderer>().sortingOrder < go.GetComponentInChildren<SpriteRenderer>().sortingOrder) {
				belowNeighbor.GetComponentInChildren<SpriteRenderer>().sortingOrder = go.GetComponentInChildren<SpriteRenderer>().sortingOrder;
				UpdateNeighbors (belowNeighbor);
			}
		}

		return;
	}

	Vector3 [] getVertices(GameObject go) {
		Vector3 [] vertices = new Vector3[4];
		Vector3 goPosition  = go.transform.position;

		Vector3 [] goVertices = new Vector3[4];
		goVertices [0] = new Vector3 (goPosition.x - 5f, goPosition.y - 5f); //bottom left corner
		goVertices [1] = new Vector3 (goPosition.x + 5f, goPosition.y - 5f); //bottom right corner
		goVertices [2] = new Vector3 (goPosition.x - 5f, goPosition.y + 5f); //top left corner
		goVertices [3] = new Vector3 (goPosition.x + 5f, goPosition.y + 5f); //top right corner*/

		Vector3 direction = goPosition - transform.position;

		float largest  = -400;
		float smallest =  400;
		for (int i = 0; i < 4; i++) {
			float angle = Vector3.Angle(goVertices[i] - transform.position, Quaternion.Euler(0,0,90) * (direction));
			if (angle < smallest) {
				smallest = angle;
				vertices[0] = goVertices[i];
			}
			if (angle > largest) {
				largest = angle;
				vertices[1] = goVertices[i];
			}
		}

		Vector3 dir1 = (vertices [0] - transform.position);
		Vector3 dir2 = (vertices [1] - transform.position);
		dir1.Normalize ();
		dir2.Normalize ();
		vertices[2] = vertices[0] + 200*dir1;
		vertices[3] = vertices[1] + 200*dir2;


		return vertices;
	}
	
	void cleanseShadows() {
		GameObject [] shadows = GameObject.FindGameObjectsWithTag("Shadow");
		for (int i = 0; i < shadows.Length; i++)
			Destroy (shadows [i]);
	}

	void revertSortingOrders() {
		GameObject [] goArray = FindObjectsOfType(typeof(GameObject)) as GameObject [];
		for (int i = 0; i < goArray.Length; i++) {
			if (goArray[i].tag == "Wall" || goArray[i].tag == "WallPassBehind" || goArray[i].tag == "WallBoundary" ) 
				goArray[i].GetComponent<SpriteRenderer>().sortingOrder = -50;
		}
	}
}
