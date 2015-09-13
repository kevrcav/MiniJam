using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JeebusWorshipper : MonoBehaviour {

    public Sprite praisingSprite;
    public GameObject arrow;
    SpriteRenderer spriteRenderer;

    public enum Direction
    {
        kUp,
        kRight,
        kDown,
        kLeft
    }

    Direction direction;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        direction = (Direction)Random.Range(0, 4);
        arrow.transform.rotation = Quaternion.AngleAxis(90.0f * (int)direction, Vector3.back);
    }

	public bool CheckPrayer () {

        switch (direction)
        {
            case Direction.kUp:
                if (Input.GetAxis("Vertical") > 0)
                {
                    PrayerAnswered();
                    return true;
                }
                break;
            case Direction.kDown:
                if (Input.GetAxis("Vertical") < 0)
                {
                    PrayerAnswered();
                    return true;
                }
                break;
            case Direction.kLeft:
                if (Input.GetAxis("Horizontal") < 0)
                {
                    PrayerAnswered();
                    return true;
                }
                break;
            case Direction.kRight:
                if (Input.GetAxis("Horizontal") > 0)
                {
                    PrayerAnswered();
                    return true;
                }
                break;
        }

        return false;
    }

    void PrayerAnswered()
    {
        spriteRenderer.sprite = praisingSprite;
    }
}
