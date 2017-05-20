using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ballscript : MonoBehaviour
{

    public float spinPower;
    public float maxSpinSpeed;
    public float hardHitSpeed;

    public SpriteRenderer RotationGlow;
    public ParticleSystem hitParticle;

    public Vector3 scaleTowards;
    public float scaleSpeed;

    private Vector3 originalScale;
    private Color currentColor = Color.white;
    new private Rigidbody2D rigidbody;

    public Text points;
    private int currentPoints;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {

        RotationGlow.color = currentColor;

        if (Input.GetKey("left") && !Input.GetKey("right"))
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (rigidbody.angularVelocity < maxSpinSpeed * 2)
                    rigidbody.AddTorque(spinPower * 2);
            }
            else if (rigidbody.angularVelocity < maxSpinSpeed)
                rigidbody.AddTorque(spinPower);

            currentColor.a = Mathf.MoveTowards(currentColor.a, 0.7f, Time.deltaTime * 5);
        }
        
        else if (Input.GetKey("right") && !Input.GetKey("left"))
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (rigidbody.angularVelocity > -maxSpinSpeed * 2)
                    rigidbody.AddTorque(-spinPower * 2);
            }
            else if (rigidbody.angularVelocity > -maxSpinSpeed)
                rigidbody.AddTorque(-spinPower);

            currentColor.a = Mathf.MoveTowards(currentColor.a, 0.7f, Time.deltaTime * 5);
        }

        else if (!Input.GetKey("right") && !Input.GetKey("left"))
        {
            if (rigidbody.angularVelocity < 50 && rigidbody.angularVelocity > 0)
                rigidbody.angularVelocity = 0;

            if (rigidbody.angularVelocity > -50 && rigidbody.angularVelocity < 0)
                rigidbody.angularVelocity = 0;

            currentColor.a = Mathf.MoveTowards(currentColor.a, 0, Time.deltaTime);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitParticle)
        {

            foreach (ContactPoint2D item in collision.contacts)
            {
                if (this.rigidbody.velocity.magnitude > hardHitSpeed)
                {
                    Instantiate(hitParticle, item.point, Quaternion.FromToRotation(item.point, item.normal));
                }

            }

        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Collectable"))
        {
            currentPoints ++;
            points.text = "nu har du " + currentPoints.ToString() + " points";

            Destroy(collider.gameObject);
        }
    }

}
