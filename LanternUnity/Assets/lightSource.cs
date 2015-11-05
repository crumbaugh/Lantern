using UnityEngine;
using System.Collections;

public class lightSource : MonoBehaviour {
	public GameObject shadow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		cleanseShadows();
		GameObject [] goArray = FindObjectsOfType(typeof(GameObject)) as GameObject [];
		for (var i = 0; i < goArray.Length; i++) {
			Vector3 [] vertices = new Vector3[4];
			vertices[0] = transform.position;

			if (goArray[i].layer == 8) {
				vertices = getVertices(goArray[i].transform.position);

				Mesh mesh = new Mesh();
				mesh.vertices = vertices;
				mesh.triangles = new int[] {0,2,3, 1,2,3, 0,1,2};

				GameObject tempShadow = Instantiate(shadow, Vector3.zero, Quaternion.identity) as GameObject;
				tempShadow.GetComponent<MeshFilter>().mesh = mesh;
			}

		}
	}

	Vector3 [] getVertices(Vector3 goPosition) {
		Vector3 [] vertices = new Vector3[4];
		Vector3 direction =  goPosition - transform.position;
	
		Vector3 [] goVertices = new Vector3[4];
		goVertices [0] = new Vector3 (goPosition.x - .5f, goPosition.y - .5f); //bottom left corner
		goVertices [1] = new Vector3 (goPosition.x + .5f, goPosition.y - .5f); //bottom right corner
		goVertices [2] = new Vector3 (goPosition.x - .5f, goPosition.y + .5f); //top left corner
		goVertices [3] = new Vector3 (goPosition.x + .5f, goPosition.y + .5f); //top right corner

		float largest  = -200;
		float smallest =  200;
		for (int i = 0; i < 4; i++) {
			float angle = Vector3.Angle(goVertices[i] - transform.position, Quaternion.Euler(0,0,90) * (goPosition - transform.position));
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
		vertices[2] = vertices[0] + 15*dir1;
		vertices[3] = vertices[1] + 15*dir2;

		return vertices;
	}

	void cleanseShadows() {
		GameObject [] shadows = GameObject.FindGameObjectsWithTag("Shadow");
		for (int i = 0; i < shadows.Length; i++)
			Destroy (shadows [i]);
	}
}
