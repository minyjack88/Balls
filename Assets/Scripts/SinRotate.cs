using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinRotate : MonoBehaviour {

    public float angle;
    public float period;
    public float timeOffset;

    private float time;



    void Start()
    {
        time += timeOffset;
    }

    void Update()
    {
        time = time + Time.deltaTime;
        float phase = Mathf.Sin(time / period);
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, phase * angle));
    }
}
