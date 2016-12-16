using UnityEngine;
using System.Collections;

public class MoveRacket : MonoBehaviour
{

    public enum ePlayer
    {
        L,
        R
    }
    public float speed;
    public AudioClip SE_Atack;
    AudioSource playerAudio;
    public ePlayer player1;

    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody>().velocity = new Vector3(0 ,0, v) * speed;
    }


    void OnCollisionEnter(Collision col)
    {
        Ball ball = col.gameObject.GetComponent<Ball>();
        if (ball != null)
        {

            
            if (player1 == ePlayer.R)
            {
            
                playerAudio.Play();
            }
            else if (player1 == ePlayer.L)
            {
              
                playerAudio.Play();
            }
        }
    }
}

