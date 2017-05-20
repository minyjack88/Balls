using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFloat : MonoBehaviour {

    public float waveSpeed;
    public float waveSize;
    public Vector3 waveAxis;

    private Vector3 currentPos;

	// Use this for initialization
	void Start () {


        currentPos = transform.position;


    }

    // Update is called once per frame
    void Update () {
        
        transform.position = currentPos + waveAxis * Mathf.Sin(Time.time * waveSpeed) * waveSize;
        
    }
}
