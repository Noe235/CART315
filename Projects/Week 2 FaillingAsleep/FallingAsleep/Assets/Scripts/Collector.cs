using System;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;


public class Collector : MonoBehaviour
{
    public TMP_Text scoreText;
    public float xLoc = 0;
    public int score = 0;
    
    
    readonly float[] allPositions = new float[] { -7.2f, -3.6f,0f, 3.6f, 
        7.2f };
    public int myPos = 2; //correspond to the array position 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow)&& myPos > 0)
        {
            
           myPos -= 1;
         UpdatePositions();
        } 
        else if (Input.GetKeyDown(KeyCode.RightArrow)&& myPos < 4)
        {
            
            myPos += 1;
        UpdatePositions();
        }

       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Circle")
        {
            Destroy(other.gameObject);
            score += 1;
            UpdateScore();
            
        }
    }

    private void UpdatePositions()
    {
        this.xLoc = allPositions[myPos];
        // Update the position
        this.transform.position = new Vector3(xLoc, this.transform.position.y, this.transform.position.z);
    }

    private void UpdateScore()
    {
        scoreText.text ="Score: " + score.ToString();
        GetComponent<TextMeshProUGUI>().SetText(scoreText.text);
      
    }
}
