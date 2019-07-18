using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed;
    public float xMin;
    public float xMax;

    public Transform ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if(x !=0)
        {
            transform.position += new Vector3(Mathf.Clamp(x * Time.deltaTime * speed, xMin, xMax),0,0);
            if(GameManager.instance.gameState==GameState.wait)
            {
                Vector3 bPos= ball.transform.position;
                ball.transform.position = new Vector3(this.transform.position.x, bPos.y, bPos.z);
            }
        }
    }
}
