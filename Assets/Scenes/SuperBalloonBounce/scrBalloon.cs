using UnityEngine;
using System.Collections;

public class scrBalloon : MonoBehaviour {

	float timer = 1f;
	bool started = false;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.isKinematic = true;
		transform.position = new Vector3 (Random.Range (-8, 8), Random.Range (1, 7), 0);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0 && !started) {
			started = true;
			rb.isKinematic = false;
			rb.velocity = new Vector3(Random.Range (-2, 2), Random.Range (1, 3), 0);
		}
	}
	
}
