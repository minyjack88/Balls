using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAdjust : MonoBehaviour {

    public GameObject targetToCenter;

    private float interpVelocity;
    private Vector3 targetPos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 posNoZ = transform.position;
        posNoZ.z = targetToCenter.transform.position.z;
        Vector3 targetDirection = (targetToCenter.transform.position - posNoZ);
        interpVelocity = targetDirection.magnitude * 5f;
        targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime * 4);
        transform.position = Vector3.Lerp(transform.position, targetPos, Vector3.Distance(transform.position, targetPos));
    }

    public void CameraShake(Vector3 direction, float force)
    {
        transform.position = new Vector3(direction.x * force, direction.y * force, -10);
    }
}
