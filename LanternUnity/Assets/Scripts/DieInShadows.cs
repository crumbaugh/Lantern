using UnityEngine;
using System.Collections;

public class DieInShadows : MonoBehaviour {
	private GameObject lantern;

	//private Vector3 [] corners = new Vector3[4];

	// Use this for initialization
	void Start () {
		lantern = GameObject.FindGameObjectWithTag ("Lantern");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position, lantern.transform.position) > 45)
			Application.LoadLevel ("test");
		/*
		corners[0].x = transform.position.x - 5;
		corners[0].y = transform.position.y - 5;
		corners[0].z = -5;

		corners[1].x = transform.position.x + 5;
		corners[1].y = transform.position.y - 5;
		corners[1].z = -5;

		corners[2].x = transform.position.x - 5;
		corners[2].y = transform.position.y + 5;
		corners[2].z = -5;

		corners[3].x = transform.position.x + 5;
		corners[3].y = transform.position.y + 5;
		corners[3].z = -5;
		*/
		//int layerMask = 50 << 8; //only collide rays with shadow layer
		bool die = true;
		//for (int i = 0; i < 4; i++) {
			Vector3 up = new Vector3(0, 0, 1);
		Vector3 loc = transform.position;
		loc.z -= 5;
			die &= Physics.Raycast(loc, up, 10);
		//}
		if (die)
			Application.LoadLevel ("test");
	}
}
