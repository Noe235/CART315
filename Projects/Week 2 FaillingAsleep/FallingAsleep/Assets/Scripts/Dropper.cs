using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public GameObject Circle;
    readonly float[] allPositions = new float[] { -7.2f, -3.6f,0f, 3.6f, 
        7.2f };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(routineDrop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private IEnumerator routineDrop()
    {
        //do somehting
        int rX = Random.Range(0,4);
        float xPosition = allPositions[rX];
        
        Vector3 Loc = new Vector3(xPosition, 6, 0);
        Instantiate(Circle, Loc, transform.rotation);
        //wait
        float next = Random.Range(0.25f, 1.5f);
        yield return new WaitForSeconds(0.5f);
        //go again
        StartCoroutine(routineDrop());
        
    }
}
