using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine;
using TMPro;




public class BallScript : MonoBehaviour
{
    
   
    public float ballSpeed = 10;

    private int[] direction ={-1, 1};
    private int hDir, vDir;
    private Rigidbody2D rb;
    public AudioSource BallSound;

    public float startPos;

    public int score1, score2;

    public GameObject scoring;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine("launchBall");

        
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private IEnumerator launchBall()
    {
        yield return new WaitForSeconds(1f);
        //choose random X direction, Y
        hDir = direction[Random.Range(0, direction.Length)];
      
        vDir = direction[Random.Range(0, direction.Length)];
     
        
      
        
        //apply force
        rb.AddForce(transform.right * ballSpeed*hDir);
        rb.AddForce(transform.up * ballSpeed*vDir);
        
        //wait for X seconds
        
        
    }

    void resetBall()
    {
        //reset to 0,0
        rb.linearVelocity = Vector2.zero;
        transform.position = new Vector2(startPos, 0);
        //launch
        
        StartCoroutine("launchBall");
    }

    private void OnCollisionEnter2D(Collision2D wall)
    {
        
        if (wall.gameObject.name == "bottom1Wall")
        {
            
            //give point to play 2
            score2++;
            scoring.GetComponent<ScoreScript>().updateScore();
            resetBall();
          
        }

        if (wall.gameObject.name == "bottom2Wall")
        {
          score1++;
          scoring.GetComponent<ScoreScript>().updateScore();
            resetBall();
            
        }

        if (wall.gameObject.name == "topWall" || wall.gameObject.name == "leftWall" || wall.gameObject.name == "rightWall" || wall.gameObject.name == "middleWall") 
        {
            BallSound.pitch = 0.75f;
            BallSound.Play();
        }

        if (wall.gameObject.name == "paddleLeft")
        {
            BallSound.pitch = 1f;
            BallSound.Play();
            score1++;
            scoring.GetComponent<ScoreScript>().updateScore();
        }
        
        if (wall.gameObject.name == "paddleRight")
        {
            BallSound.pitch = 1f;
            BallSound.Play();
            score2++;
            scoring.GetComponent<ScoreScript>().updateScore();
        }
    }

   
}
