using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemt : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed = 6f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input*speed, rb.velocity.y);
        if(rb.velocity.x > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (rb.velocity.x < -0.01f)
        {
            transform.localScale = new Vector3(-1,1, 1);
        }
    }
}
