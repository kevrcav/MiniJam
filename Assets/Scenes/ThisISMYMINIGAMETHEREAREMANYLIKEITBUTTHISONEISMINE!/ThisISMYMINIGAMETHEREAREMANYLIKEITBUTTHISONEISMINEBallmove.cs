using UnityEngine;
using System.Collections;

public class ThisISMYMINIGAMETHEREAREMANYLIKEITBUTTHISONEISMINEBallmove : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (new Vector3 (0, -.33f, 0));
	}
	void OnCollisionEnter(Collision col)
	{
		Destroy (this.gameObject);
	}
}
