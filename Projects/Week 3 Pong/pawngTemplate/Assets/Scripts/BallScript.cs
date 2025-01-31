using System.Collections;
using UnityEngine;
//using System;




public class BallScript : MonoBehaviour
{
    
   
    public int score1, score2 = 0;
    public float ballSpeed = 10;

    private int[] direction ={-1, 1};
    private int hDir, vDir;
    private Rigidbody2D rb;
    public AudioSource BallSound;
    
    
    
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
        //choose random X direction, Y
        hDir = direction[Random.Range(0, direction.Length)];
      
        vDir = direction[Random.Range(0, direction.Length)];
     
        
      
        
        //apply force
        rb.AddForce(transform.right * ballSpeed*hDir);
        rb.AddForce(transform.up * ballSpeed*vDir);
        
        //wait for X seconds
        
        yield return new WaitForSeconds(1f);

      
        
    }

    void resetBall()
    {
        //reset to 0,0
        rb.linearVelocity = Vector2.zero;
        //launch
        
        StartCoroutine("launchBall");
    }
    
    
    private void OnCollisionEnter2D(Collision2D wall)
    {
        Debug.Log(wall.gameObject.name);
        
        if (wall.gameObject.name == "leftWall")
        {
            
            Debug.Log("bang");
            //give point ot play 2
            score2++;
            resetBall();
        }
        if (wall.gameObject.name == "rightWall")
        {
            score1++;
            resetBall();
        }
        if (wall.gameObject.name == "topWall" || wall.gameObject.name == "bottomWall")
        {
            BallSound.pitch = 0.75f;
            BallSound.Play();
        }

        if (wall.gameObject.name == "paddleLeft" || wall.gameObject.name == "paddleRight")
        {
            BallSound.pitch = 1f;
            BallSound.Play();
        }
    }
}
