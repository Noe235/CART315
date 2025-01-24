using System;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements; 

public class Collector : MonoBehaviour
{
    public float xLoc, yLoc;

    public float bedSpeed = 1.5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      xLoc = 0;
      yLoc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left");
            xLoc-= bedSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right");
            xLoc+= bedSpeed;
        }

        this.transform.position = new Vector3(
            xLoc, 
            yLoc, 
            0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Circle")
        {
            Destroy(other.gameObject);
        }
    }
}
