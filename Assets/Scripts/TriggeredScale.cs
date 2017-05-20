using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredScale : MonoBehaviour {


    private Vector3 originalScale;
    private Vector3 scaleDownTo;

    public float scaleRatio;
    public KeyCode key;

    // Use this for initialization
    void Start () {

        originalScale = this.transform.localScale;

        scaleDownTo = new Vector3(originalScale.x * scaleRatio, originalScale.x * scaleRatio, 1);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(key))
        {
            gameObject.transform.localScale = scaleDownTo;
        }
        else
        {
            gameObject.transform.localScale = originalScale;
        }

    }
}
