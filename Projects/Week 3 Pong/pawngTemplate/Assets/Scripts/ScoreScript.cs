using UnityEngine;
using TMPro;
public class ScoreScript : MonoBehaviour
{
    
    public TMP_Text player1Score, player2Score;
    public int lScore1, lScore2;
    public int rScore1, rScore2;
  
    public GameObject player1, player2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    
    public void updateScore()
    {
        
        // side of the screen for score
        // player is the same
        // score need to whihc player 1 or 2
        lScore1 = player1.GetComponent<BallScript>().score1;
        lScore2 = player2.GetComponent<BallScript>().score1;
        rScore1 = player1.GetComponent<BallScript>().score2;
        rScore2 = player2.GetComponent<BallScript>().score2;
        
        int tScore1 = lScore1 + lScore2;
        int tScore2 = rScore1 + rScore2;
        player1Score.text ="Player 1 Score: " + tScore1.ToString();
        player2Score.text ="Player 2 Score: " + tScore2.ToString();
    }
}
