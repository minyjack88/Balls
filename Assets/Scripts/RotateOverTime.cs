using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour {

    public float rotationSpeed;

	void FixedUpdate () {

        this.transform.Rotate(new Vector3(0, 0, 1), rotationSpeed);

    }
}
