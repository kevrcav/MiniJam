using UnityEngine;
using System.Collections.Generic;

public class Bystander : MonoBehaviour {

    float tick1;
    int tick2;
    float startX, startY;
    float xOffset;
    bool tickUp = false;

    public List<int> pauseTicks;
    public float moveSpeed = 0.5f, bounceSpeed = 3, bounceHeight = 1;

    bool gameOvered = false;

	// Use this for initialization
	void Start () {
        tick1 = 0;
        tick2 = 0;
        startX = transform.position.x;
        startY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        tick1 += Time.deltaTime;
        float sinVal = Mathf.Abs(Mathf.Sin(bounceSpeed*tick1));
        transform.position = new Vector3(startX + xOffset, startY + bounceHeight*sinVal, 0);
        if(sinVal < 0.05f && !tickUp)
        {
            tick2++;
            tickUp = true;
        }
        if(sinVal > 0.95f)
        {
            tickUp = false;
        }
        if(!pauseTicks.Contains(tick2) && !FallingTree.gameOver)
        {
            xOffset += moveSpeed * Time.deltaTime;
        }
        if(FallingTree.gameOver && !gameOvered)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, 1);
            gameOvered = true;
        }

	}

    public bool isOffscreen()
    {
        float edge = Camera.main.orthographicSize * 4f / 3f;
        float xExts = GetComponent<SpriteRenderer>().bounds.extents.x;
        float xPos = transform.position.x;
        return (xPos > edge + xExts || xPos < -(edge + xExts));
    }
}
