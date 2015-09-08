using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public AudioClip crash, jump, lose, win;

    AudioSource player, jumpPlayer;

	// Use this for initialization
	void Start () {
        AudioSource[] players = GetComponents<AudioSource>();
        player = players[0];
        jumpPlayer = players[1];
        jumpPlayer.volume = 0.5f;
	}

    public void playWinSound()
    {
        player.PlayOneShot(win);
    }

    public void playLoseSound()
    {
        player.PlayOneShot(lose);
    }

    public void playCrashSound()
    {
        player.PlayOneShot(crash);
    }

    public void playJumpSound()
    {
        jumpPlayer.PlayOneShot(jump);
    }
	
    
}
