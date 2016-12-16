using UnityEngine;
using System.Collections;

public class PlayerBorder : MonoBehaviour {
    public enum ePlayer
    {
        Left,
        Right
    }
    public AudioClip SE_wall;
    AudioSource playerAudio;
    public ePlayer player;
    public ScoreUi score;


    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision col)
    {
        Ball ball = col.gameObject.GetComponent<Ball>();
        if (ball != null)
        {

            ball.transform.position = new Vector3(0f, 1f, 0f);

            if (player == ePlayer.Right)
            {
                score.scorePlayerLeft++;
                playerAudio.Play();
            }
            else if (player == ePlayer.Left)
            { score.scorePlayerRight++;
                playerAudio.Play();
            }
        }
    }
}
