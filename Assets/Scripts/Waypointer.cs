using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypointer : Triggerable {

    public GameObject[] positions;
    public float moveSpeed;
    public bool reachedTarget;

    private Vector3 currentPosition;
    private Vector3 target;

    private float moveTime;
    private int index = 0;
    private int currentTarget;
    private bool moveTowards;

    void Start () {

        transform.position = positions[0].transform.position;
		
	}
	
	void FixedUpdate () {

        if (moveTowards)
        {
            currentPosition = transform.position;

            transform.position = Vector3.Lerp(transform.position, target, (moveSpeed * Time.deltaTime) + 0.01f);

            if (transform.position == target)
            {
                moveTowards = false;
            }
        }

    }

    public override void Trigger()
        {
        index += 1; 
        if (index > positions.Length - 1)
            index = 0;
        currentTarget = index;
        target = positions[currentTarget].transform.position;
        moveTowards = true;
    }
}
