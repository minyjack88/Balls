using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritPosition : MonoBehaviour {

    public GameObject target;
    public Vector3 offset = new Vector3(-0.1f, 0.1f);

    void LateUpdate ()
    {
        this.transform.position = target.transform.position + offset;
    }
}
