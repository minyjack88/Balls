using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour {

    public float gravityModifier;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("right"))
        { Physics2D.gravity = new Vector2(gravityModifier, 0f); }

        if (Input.GetKeyDown("left"))
        { Physics2D.gravity = new Vector2(-gravityModifier, 0f); }

        if (Input.GetKeyDown("up"))
        { Physics2D.gravity = new Vector2(0, gravityModifier); }

        if (Input.GetKeyDown("down"))
        { Physics2D.gravity = new Vector2(0f, -gravityModifier); }

    }
}
