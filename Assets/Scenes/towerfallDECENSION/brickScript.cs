using UnityEngine;
using System.Collections;

public class brickScript : MonoBehaviour {
    public AudioClip yas;
    bool hasPlayed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y < -1 || this.transform.position.z > 6)
        {
            MiniGame.Instance.ReportWin();
            Debug.Log("Nice meme!");
            if (!this.hasPlayed)
            {
                AudioSource.PlayClipAtPoint(yas, this.transform.position);
                hasPlayed = true;
            }
        }
	
	}
}
