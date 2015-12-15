using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		transform.localScale = new Vector3 (17.5f, 17.5f, 0);
	}

	void OnMouseExit() {
		transform.localScale = new Vector3 (15, 15, 0);
	}

	void OnMouseDown() {
		Application.LoadLevel ("Level2");
	}
}
