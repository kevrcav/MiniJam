using UnityEngine;
using System.Collections;

public class towerfall_cannonball_launch : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Rigidbody r = this.GetComponent<Rigidbody>();
        r.AddForce(0, 0, 5000);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
