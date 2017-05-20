using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombe : MonoBehaviour {

    public Sprite explosionSprite;

    private SpriteRenderer sprite;

    //lyd
    //timer

	// Use this for initialization
	void Start () {

        sprite = GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Explode();
        }
    }

    void Explode()
    {

        sprite.sprite = explosionSprite;
        
    }

}
