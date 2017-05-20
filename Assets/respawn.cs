using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{

    public GameObject currentCheckpoint;

    private Rigidbody2D rigidbody;

    // Use this for initialization
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>(); 
        transform.position = currentCheckpoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            RespawnAtLastCheckpoint();
        }

    }

    public void RespawnAtLastCheckpoint()
    {
        transform.position = currentCheckpoint.transform.position;
        rigidbody.velocity = new Vector3(0, 0, 0);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Badstuff"))
        {
            RespawnAtLastCheckpoint();
        }

        if (collider.CompareTag("Checkpoint"))
        {
            collider.enabled = false;
            currentCheckpoint = collider.gameObject;

        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Badstuff"))
        {
            RespawnAtLastCheckpoint();
        }
    }
}
