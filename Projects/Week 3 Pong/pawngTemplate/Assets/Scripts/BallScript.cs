using System.Collections;
using UnityEngine;





public class BallScript : MonoBehaviour
{
    
   
    public int score = 0 ;
    public float ballSpeed = 10;

    private int[] direction ={-1, 1};
    private int hDir, vDir;
    private Rigidbody2D rb;
    public AudioSource BallSound;

    public float maxDist;
    public GameObject Player1;
    public GameObject Player2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine("launchBall");
        
    }

    // Update is called once per frame
    void Update()
    {
       checkDistance(); 
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
        
        if (wall.gameObject.name == "bottomWall")
        {
            
            Debug.Log("bang");
            //give point to play 2
            score--;
            resetBall();
        }
       
        if (wall.gameObject.name == "topWall" || wall.gameObject.name == "leftWall" || wall.gameObject.name =="rightWall")
        {
            BallSound.pitch = 0.75f;
            BallSound.Play();
        }

        if (wall.gameObject.name == "paddleLeft" || wall.gameObject.name == "paddleRight")
        {
            BallSound.pitch = 1f;
            BallSound.Play();
            score++;
        }
    }

    void checkDistance()
    {
        float currentDist = Vector2.Distance(Player1.transform.position, Player2.transform.position);

        if (currentDist > maxDist)
        {
            
        }
    }
}
