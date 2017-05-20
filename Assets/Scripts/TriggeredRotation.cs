using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredRotation : MonoBehaviour {

    private bool hit = false;

    public float rotationSpeed;

    void FixedUpdate()
    {
        if (hit)
        {
            this.transform.Rotate(new Vector3(0, 0, 1), rotationSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hit = true;
        }
    }


}
