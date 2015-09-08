using UnityEngine;
using System.Collections;

public class stairsgame : MonoBehaviour {

    float gameTimer = 0;
    bool won = false;
    bool pressed = false;

    public SpriteRenderer win;
    public SpriteRenderer lose;
    public SpriteRenderer falling;

    public AudioClip winSound;
    public AudioClip loseSound;

    AudioSource aSource;

    bool done = false;

	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
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

        if (gameTimer >= 4 && !done)
        {
            done = true;
            falling.enabled = false;
            if (won)
            {
                win.enabled = true;
                aSource.clip = winSound;
                aSource.Play();
                MiniGame.Instance.ReportWin();
            }
            else
            {
                lose.enabled = true;
                aSource.clip = loseSound;
                aSource.Play();
                MiniGame.Instance.ReportLose();
            }
        }
	}
}
