using UnityEngine;
using System.Collections;

public class towerfall_crosshairs_move : MonoBehaviour {
    public float xmin;
    public float xmax;
    public float ymin;
    public float ymax;
    public float z;
    private Vector3 cur;
    private Vector3 dest;
    private float t;
    public float speed = .1f;

	// Use this for initialization
	void Start () {
        cur = this.transform.position;
        dest = pickSpot();
        t = 0;

	}
	
    // pick a spot on screen
    // if spot has been picked
    // lerp towards it
    // if done lerping
    // pick a new spot on screen 


	// Update is called once per frame
	void Update () {
        this.transform.position = Vector3.Lerp(cur, dest, t);
        t += speed;
        if (t >= 1)
        {
            cur = this.transform.position;
            dest = pickSpot();
            t = 0;
        }
	}

    // add a little vector to our current position
    Vector3 pickSpot() {
        float x = Random.Range(xmin, xmax);
        float y = Random.Range(ymin, ymax);
        return new Vector3(x, y, z);
    }
}
