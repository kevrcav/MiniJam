using UnityEngine;
using System.Collections;

public class anvilgame : MonoBehaviour {

    public float speed = 100;

    bool onGround = false;
    public pianohit piano;

    float gameTimer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameTimer += Time.deltaTime;
        if (gameTimer >= 4 && !onGround)
        {
            onGround = true;
            if (piano.hit)
            {
                MiniGame.Instance.ReportWin();
            }
            else
            {
                MiniGame.Instance.ReportLose();
            }
        }

        if (!onGround)
        {
            transform.position += new Vector3(speed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
        }
	}
}
