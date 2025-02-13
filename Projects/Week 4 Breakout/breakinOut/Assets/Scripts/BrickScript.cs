using System.Xml.Linq;
using UnityEngine;

public class BrickScript : MonoBehaviour {

    public int pointValue = 1;

    private SpriteRenderer brick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        brick = GetComponent<SpriteRenderer>();
    brick.color = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
