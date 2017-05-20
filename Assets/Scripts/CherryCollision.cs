using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryCollision : MonoBehaviour {

    public ParticleSystem particle;
    public GameObject spawnPoint;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            particle.Play();
        }
    }

	// Use this for initialization
	void Start () {

        particle = Instantiate(particle, spawnPoint.transform.position, spawnPoint.transform.rotation);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
