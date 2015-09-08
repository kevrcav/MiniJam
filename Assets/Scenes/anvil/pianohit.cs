using UnityEngine;
using System.Collections;

public class pianohit : MonoBehaviour {

    public bool hit = false;
    public SpriteRenderer crush;

	// Use this for initialization
	void Start () {
        if (Random.value < .5f)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!hit)
        {
            hit = true;
            GetComponent<SpriteRenderer>().enabled = false;
            crush.enabled = true;
            GetComponent<AudioSource>().Play();
        }
    }
}
