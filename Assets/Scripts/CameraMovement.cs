using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Camera cam;
    public Vector3 OOBOffset;

    private float interpVelocity;
    private float followSpeed;

    private Vector3 zOffset = new Vector3(0,0,-10);
    private Vector3 targetPos;
    private float interpVel;
    private GameObject target;
    private float timeUntilOOB;
    private bool goingOOB = true;
    private bool outOfBounds = true;

    // Use this for initialization
    void Start () {

        if (!cam)
        {
            cam = FindObjectOfType<Camera>();
        }
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (!outOfBounds && !goingOOB)
        {
            timeUntilOOB = 2;
        }

        if (timeUntilOOB < 0)
        {
            Vector3 posNoZ = cam.transform.position;
            posNoZ.z = transform.position.z;
            Vector3 targetDirection = (transform.position - posNoZ);
            interpVelocity = targetDirection.magnitude * 5f;
            targetPos = cam.transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime * 4);
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetPos + OOBOffset, Vector3.Distance(transform.position, targetPos));
        }
        timeUntilOOB -= Time.deltaTime;
    }


    void OnTriggerStay2D(Collider2D collider)
    {
       
        if (collider.CompareTag("CamZone"))
        {
            cam.transform.position = collider.transform.position + zOffset;
            outOfBounds = false;
            goingOOB = false;
        }
    }

    void OnTriggerExit2D(Collider2D collidor)
    {
        if (collidor.CompareTag("CamZone"))
        {
            goingOOB = true;
        }
 

    }

}
