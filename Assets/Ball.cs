using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public Vector3 initialImpulse;
    public float speed;
    public AudioClip BackMusic;
    AudioSource playerAudio;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity=Vector3.right*speed;
	}

    void Awake ()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAudio.Play();

    } 


    float hitFactor(Vector3 ballPos, Vector3 racketPos,
                float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.z - racketPos.z) / racketHeight;
    }

    void OnCollisionEnter3D(Collision col)
    {


        // Hit the left Racket?
        if (col.gameObject.name == "PlayerL")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector3 dir = new Vector3(1, 0 , y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody>().velocity = dir * speed;
            
        }

        // Hit the right Racket?
        if (col.gameObject.name == "PlayerR")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector3 dir = new Vector3(-1, 0,  y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody>().velocity = dir * speed;
            
        }
    }
    // Update is called once per frame
    void Update () {
       
    }
}
