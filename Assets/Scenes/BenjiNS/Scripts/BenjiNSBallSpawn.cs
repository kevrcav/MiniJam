using UnityEngine;
using System.Collections;

public class BenjiNSBallSpawn : MonoBehaviour {

	public GameObject ballPrefab;

	// Use this for initialization
	void Start () {
		GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity) as GameObject;
		ball.transform.SetParent(transform.parent);
	}
}
