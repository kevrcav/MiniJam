using UnityEngine;
using System.Collections.Generic;

public class Bystanders : MonoBehaviour {
    List<GameObject> bystanders;

	// Use this for initialization
	void Start () {
	    if(bystanders == null || bystanders.Count == 0)
        {
            bystanders = new List<GameObject>();
            for(int i = 0; i < transform.childCount; i++)
            {
                bystanders.Add(transform.GetChild(i).gameObject);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    public bool allBystandersOffscreen()
    {
        bool rv = true;
        foreach(GameObject bystander in bystanders)
        {
            if (!bystander.GetComponent<Bystander>().isOffscreen())
                rv = false;
        }
        return rv;
    }
}
