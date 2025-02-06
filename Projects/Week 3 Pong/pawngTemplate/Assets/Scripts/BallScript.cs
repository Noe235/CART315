using System.Collections;
using UnityEngine;
using TMPro;




public class BallScript : MonoBehaviour
{
    
    public TMP_Text player1Score, player2Score;
    public int score1,score2 = 0 ;
    public float ballSpeed = 10;

    private int[] direction ={-1, 1};
    private int hDir, vDir;
    private Rigidbody2D rb;
    public AudioSource BallSound;

    public float startPos;
   
    
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

    private void updateScore()
    {
        player1Score.text ="Player 1 Score: " + score1.ToString();
        player2Score.text ="Player 2 Score: " + score2.ToString();
    }
    
    private void OnCollisionEnter2D(Collision2D wall)
    {
        Debug.Log(wall.gameObject.name);
        
        if (wall.gameObject.name == "bottom1Wall")
        {
            
            //give point to play 2
            score2++;
            updateScore();
            resetBall();
        }

        if (wall.gameObject.name == "bottom2Wall")
        {
            score1++;
            updateScore();
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
            updateScore();
        }
        
        if (wall.gameObject.name == "paddleRight")
        {
            BallSound.pitch = 1f;
            BallSound.Play();
            score2++;
            updateScore();
        }
    }

   
}
