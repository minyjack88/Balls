using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFloat : MonoBehaviour {

    public float maxFloatTime;
    public float gravityMod;
    public SpriteRenderer floatGlow;

    private float currentFloatTime;
    new private Rigidbody2D rigidbody;
    private float normalGravity;
    private Color fade = Color.white;
    public float maxUpwardsSpeed;

    private Vector2 upwards;

    void Start()
    {
        upwards.y = maxUpwardsSpeed;
        fade.a = 0;
        rigidbody = GetComponent<Rigidbody2D>();
        normalGravity = rigidbody.gravityScale;
    }

    void FixedUpdate()
    {

        if (Input.GetKey("right") && Input.GetKey("left"))
        {
            Float();
        }
        else
        {
            fade.a = Mathf.MoveTowards(fade.a, 0, Time.deltaTime);
            rigidbody.gravityScale = normalGravity;
        }


        floatGlow.color = fade;

    }

    void Float()
    {
        if (currentFloatTime > 0)
        {
            fade.a = Mathf.MoveTowards(fade.a, 1, Time.deltaTime);
            rigidbody.gravityScale = gravityMod;
            currentFloatTime -= Time.deltaTime;

        }
        else
        {
            rigidbody.gravityScale = normalGravity;
            fade.a = Mathf.MoveTowards(fade.a, 0, Time.deltaTime);
        }
        if (rigidbody.velocity.y > maxUpwardsSpeed)
        {
            upwards.x = rigidbody.velocity.x;
            rigidbody.velocity = upwards;
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("terrain"))
        {
            currentFloatTime = maxFloatTime;
        }
    }
}
