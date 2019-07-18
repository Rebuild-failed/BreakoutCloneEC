using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameState == GameState.start)
        {
            rb2d.velocity = new Vector2(Mathf.Tan(10 * Mathf.Deg2Rad), 1) * speed;
            GameManager.instance.gameState = GameState.playing;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance.gameState == GameState.playing)
        {
            if(collision.gameObject.tag != "Indestructible")
            {
                Destroy(collision.gameObject);
            }
            //与竖直方向夹角
            float angleV = Vector2.Angle(rb2d.velocity, Vector2.down);
            //运动方向
            Vector2 moveNor = rb2d.velocity.normalized;
            //夹角过小修正，防止死循环
            if (angleV < 10f)
            {

                moveNor = new Vector2(Mathf.Tan(15 * Mathf.Deg2Rad), 1f).normalized;
            }
            else if (angleV > 80 && angleV <= 90f)
            {

                moveNor = new Vector2(Mathf.Tan(75 * Mathf.Deg2Rad), 1f).normalized;
            }
            else if (angleV < 100 && angleV > 90)
            {
                moveNor = new Vector2(Mathf.Tan(105 * Mathf.Deg2Rad), 1f).normalized;
            }
            else if (angleV > 170 && angleV <= 180)
            {
                moveNor = new Vector2(Mathf.Tan(165 * Mathf.Deg2Rad), 1f).normalized;
            }
            rb2d.velocity = moveNor * speed;
        }

    }
}
