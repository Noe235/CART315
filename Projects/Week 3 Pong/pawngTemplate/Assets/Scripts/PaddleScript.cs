using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaddleScript : MonoBehaviour {
    public float     xPos;
    public float      paddleSpeed = .02f;

    public KeyCode    leftKey,rightKey;

    public float      leftWall,rightWall;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(leftKey) && xPos >= leftWall) {
                xPos -= paddleSpeed;
        }

        if (Input.GetKey(rightKey) && xPos <= rightWall) {
                xPos += paddleSpeed;
        }

        transform.localPosition = new Vector3(xPos,transform.position.y,0);
    }
}

