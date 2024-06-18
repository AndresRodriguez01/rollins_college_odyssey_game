using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float speed;
    public Vector2 direction;
    public scoreScript score;
    public Vector2 newPosition;
    public static AudioClip bounce;
    static AudioSource audioSrc;
    int p1Score;
    int p2Score;
    int lastScoringPlayer = 0;
    bool isPointDelayActive = false;
    float pointDelayTimer = 3.0f;
    
    Rigidbody2D p1;
    Vector2 initial;
        void Start()
    {
        p1 = GetComponent<Rigidbody2D>();
	    initial = p1.transform.localPosition;
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.one.normalized;
        score = GameObject.FindGameObjectWithTag("logic").GetComponent<scoreScript>();
        audioSrc = GetComponent<AudioSource>();
        //audioSrc.volume = 0.5f;
        bounce = Resources.Load<AudioClip>("bounce");

        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPointDelayActive)
        {
            pointDelayTimer -= Time.deltaTime;
            if (pointDelayTimer <= 0)
            {
                // Reset the timer and start the next point
                isPointDelayActive = false;
                pointDelayTimer = 3.0f;
                

                // Place your logic for starting the next point here
                // For example, resetting the ball's position
                if (lastScoringPlayer == 1){
                    newPosition = new Vector2(-10, 0);
                    rb.transform.position = newPosition;
                    //rb.transform.position = new Vector2(initial.x, 0); // Adjust xPositionOfPlayer1 accordingly
                }
                else if (lastScoringPlayer == 2) {
                    newPosition = new Vector2(10, 0);
                    rb.transform.position = newPosition; // Adjust xPositionOfPlayer2 accordingly
                }
                speed = 10f;
            }
        }
        else
        {
            rb.velocity = direction * speed;
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("p1") || collision.gameObject.CompareTag("p2")){
            direction.x = -direction.x;
            audioSrc.PlayOneShot(bounce);
            speed *= 1.05f;
        }
        else if (collision.gameObject.CompareTag("wall"))
            direction.y = -direction.y;
        else if (collision.gameObject.CompareTag("goalp1")){
            
            score.addScore(1);
            p1Score ++;
            if (p1Score == 5)
                gameObject.SetActive(false);
                else
            {
                // Store which player scored
                lastScoringPlayer = 1;
                // Start the delay timer for the next point
                isPointDelayActive = true;
            }
            //rb.transform.position = newPosition;
        }
        else if (collision.gameObject.CompareTag("goalp2")){
            
            score.addScore(2);
            p2Score ++;
            if (p2Score == 5)
                gameObject.SetActive(false);
            else
            {
                // Store which player scored
                lastScoringPlayer = 2;
                // Start the delay timer for the next point
                isPointDelayActive = true;
            }
            //rb.transform.position = newPosition;
        }
        
    }
}
