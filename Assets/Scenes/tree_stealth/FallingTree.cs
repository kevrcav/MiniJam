using UnityEngine;
using System.Collections;

public class FallingTree : MonoBehaviour {

    Bystanders bys;
    public static bool gameOver;

    public float fallSpeed = 3f, pushForce = 3f;
    public SpriteRenderer face;
    public Sprite smug, spooked, dizzy;

	// Use this for initialization
	void Start () {
        bys = FindObjectOfType<Bystanders>();
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        float zAngle = transform.eulerAngles.z;
        if (zAngle > 180) zAngle = zAngle - 360;
        if(zAngle < 30 && zAngle > -30)
        {
            face.sprite = smug;
        }
        else if ((zAngle > 0 && zAngle < 270) || zAngle < -90)
        {
            if (gameOver) return;
            if (bys.allBystandersOffscreen())
            {
                transform.parent.GetComponent<MiniGame>().ReportWin();
                FindObjectOfType<AudioManager>().playWinSound();
                Debug.Log("win");
            }
            else
            {
                transform.parent.GetComponent<MiniGame>().ReportLose();
                FindObjectOfType<AudioManager>().playLoseSound();
                Debug.Log("lose");
            }
            face.sprite = dizzy;
            gameOver = true;
            return;
        }
        else
        {
            face.sprite = spooked;
        }
        float hInput = Input.GetAxis("Horizontal");
        transform.eulerAngles = new Vector3(0, 0, zAngle + Time.deltaTime*(fallSpeed * zForce(zAngle) + pushForce*-100*hInput));
	}

    float zForce(float zAngle)
    {
        return (zAngle > 0) ? Mathf.Max(zAngle, 20) : Mathf.Min(zAngle, -20);
    }
}
