using UnityEngine;

public class BrickLayer : MonoBehaviour
{
    public GameObject brick;
    public int row,column;
    public int nbbrick;

    public float bs_h,bs_v;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setBrick();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setBrick() {
        for (int i = 0; i < column; i++) {
            for (int j = 0; j <= row; j++) {
                float xPos = -column + (i * bs_h);
                float yPos = row - (j * bs_v);
                
                Instantiate(brick, new Vector3(xPos, yPos, 0), transform.rotation,this.transform);
                
                
                nbbrick++;
            }
        }
    }
}
