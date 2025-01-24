using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public GameObject circle;
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
        Debug.Log("Drop");
        float rX = Random.Range(-6.0f, 6.0f);
        Vector3 Loc = new Vector3(rX, 6, 0);
        Instantiate(circle, Loc, transform.rotation);
        //wait
        float next = Random.Range(0.25f, 1.5f);
        yield return new WaitForSeconds(0.5f);
        //go again
        StartCoroutine(routineDrop());
        
    }
}
