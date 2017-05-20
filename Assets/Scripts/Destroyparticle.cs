using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyparticle : MonoBehaviour {

    ParticleSystem particle;

    // Use this for initialization
    void Start () {

        particle = this.GetComponent<ParticleSystem>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!particle.isPlaying)
            Destroy(gameObject);
	}
}
