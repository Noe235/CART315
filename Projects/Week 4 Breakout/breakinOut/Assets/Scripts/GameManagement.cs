using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagement : MonoBehaviour
{

    public GameObject paddle;
    public TextMeshProUGUI livesText;

    public int points = 0;
    public int lives = 3;

    public static GameManagement S;

    void Awake()
    {
        S = this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoseLife()
    {
        lives -= 1;
        livesText.text = "Lives: " + lives;

        if (lives <= 0) GameOver();
    }
    

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void AddPoints(int pointValue) {
        points += pointValue;
    }
    
   // public void AddPoints(int pointValue) {
 //  points += 1;
//} 
    
}
