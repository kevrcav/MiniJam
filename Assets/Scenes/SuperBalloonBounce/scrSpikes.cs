using UnityEngine;
using System.Collections;

public class scrSpikes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log ("HIT SPIKES");
			Destroy (other.gameObject);
			MiniGame.Instance.ReportLose ();
		}
	}
}
