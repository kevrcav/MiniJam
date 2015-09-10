using UnityEngine;
using System.Collections;

public class towerfall_crosshairs_launch : MonoBehaviour {
    public GameObject daddy;
    public GameObject cannonball;
    private bool hasLaunched = false;
    // when you hit a button, launch the fronk
    // then disappear


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !hasLaunched) {
            GameObject cb = GameObject.Instantiate(cannonball, this.transform.position,  cannonball.transform.rotation) as GameObject;
            cb.transform.parent = daddy.transform;
            hasLaunched = true;
            this.gameObject.SetActive(false);
        }
	}
}
