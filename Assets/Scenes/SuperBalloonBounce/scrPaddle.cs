using UnityEngine;
using System.Collections;

public class scrPaddle : MonoBehaviour {

	Vector3 lastMove = new Vector3(0, 0, 0);
	Rigidbody rb;
	public GameObject ourCam;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = Vector3.zero;
		Vector3 mousePos = ourCam.GetComponent<Camera>().ScreenToWorldPoint (Input.mousePosition);
		mousePos = new Vector3 (Mathf.Max (Mathf.Min (10, mousePos.x), -10), Mathf.Max (Mathf.Min (-2, mousePos.y), -6), 0);
		lastMove = mousePos - transform.position;
		rb.velocity = lastMove * 20;
		//transform.position = new Vector3 (mousePos.x, mousePos.y, 0);

		//left mouse button
		if (Input.GetMouseButton (0)) {
			transform.Rotate(new Vector3 (0, 0, 2));
		} 
		//right mouse button
		else if (Input.GetMouseButton (1)) {
			transform.Rotate(new Vector3 (0, 0, -2));
		}
	}

	public Vector3 getLastMove() { return lastMove;}
}
