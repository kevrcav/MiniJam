using UnityEngine;
using System.Collections;

public class stairsgame : MonoBehaviour {

    float gameTimer = 0;
    bool won = false;
    bool pressed = false;

    public SpriteRenderer win;
    public SpriteRenderer lose;
    public SpriteRenderer falling;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameTimer += Time.deltaTime;

        if (Input.GetButtonDown("Button 1") && !pressed)
        {
            pressed = true;
            if (gameTimer < 4 && gameTimer > 3.75f)
            {
                won = true;
            }
        }

        if (gameTimer >= 4)
        {
            falling.enabled = false;
            if (won)
            {
                win.enabled = true;
                MiniGame.Instance.ReportWin();
            }
            else
            {
                lose.enabled = true;
                MiniGame.Instance.ReportLose();
            }
        }
	}
}
