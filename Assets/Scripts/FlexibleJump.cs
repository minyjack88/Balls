using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexibleJump : MonoBehaviour {

    public float jumpPower;

    public float lateJumpTime;
    public float earlyJumpTime;

    private float canJumpTimeRemaining;
    private float goingToJumpEarlyTime;

    private bool isGrounded;
    private float contactX;
    private float contactY;

    new private Rigidbody2D rigidbody;

    void Start () {

        rigidbody = this.GetComponent<Rigidbody2D>();

    }

    void FixedUpdate () {

        canJumpTimeRemaining -= Time.deltaTime;
        goingToJumpEarlyTime -= Time.deltaTime;

    }

    void Jump(){
        rigidbody.AddForce(new Vector2(contactX * jumpPower, contactY * jumpPower), ForceMode2D.Impulse);
        canJumpTimeRemaining = 0;

    }

    void AttemptJump(){
        if (canJumpTimeRemaining > 0)
        {
            Jump();
        }

        else
        {
            goingToJumpEarlyTime = earlyJumpTime;
        }
    }

    void OnCollisionStay2D(Collision2D collision){

        if (collision.collider.CompareTag("terrain"))
        {
            canJumpTimeRemaining = lateJumpTime;
            foreach (ContactPoint2D contact in collision.contacts)
            {
                contactX = contact.normal.x;
                contactY = contact.normal.y;
            }

        }

        if (goingToJumpEarlyTime > 0)
        {
            Jump();
            goingToJumpEarlyTime = 0;
        }
    }

    void LateUpdate(){

        isGrounded = false;

    }

}
