using UnityEngine;
using System.Collections;

public class ThisISMYMINIGAMETHEREAREMANYLIKEITBUTTHISONEISMINEBatmove: MonoBehaviour {
	public GameObject handle;
	public GameObject pumpkin;
	private int Balls;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Balls == 5) {
			MiniGame.Instance.ReportWin();		
		}
	    if (Input.GetKey (KeyCode.Z)) {
			this.transform.RotateAround(handle.transform.position, Vector3.back, 5);
		}
		if (Input.GetKey (KeyCode.X)) {
			this.transform.RotateAround(handle.transform.position, Vector3.back, -5);
		}
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Ball") {
			Balls++;
		}
	}
}
