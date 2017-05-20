using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    public int lives;
    public GameObject startPoint;




	// Use this for initialization
	void Start () {
		
	}
	


	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Badstuff"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPoint.transform.position;
    }
}
