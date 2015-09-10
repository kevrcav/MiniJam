using UnityEngine;
using System.Collections;

public class BenjiNSBall : MonoBehaviour {

	public float xBounds = 5.0f;
	public float yBounds = 3.0f;

	// Update is called once per frame
	void Update () {
		if(transform.position.x > xBounds || transform.position.x < -xBounds
		|| transform.position.y > yBounds || transform.position.y < -yBounds){
			MiniGame.Instance.ReportLose();
		}
		else if(GetComponent<Rigidbody2D>().IsSleeping()){
			MiniGame.Instance.ReportLose();
		}
	}

}
