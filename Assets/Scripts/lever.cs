using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : Triggerable {

    public Triggerable[] triggers_1;
    public Triggerable[] triggers_2;


    private HingeJoint2D hinge;
    private JointMotor2D motor;

    private bool pushedDown = false;
    private bool playerHit;

    private float motorForce;
    private float timeUntilLeverFix;

    // Use this for initialization
    void Start () {
        
        hinge = this.GetComponent<HingeJoint2D>();
        motor.maxMotorTorque = 100;
        motorForce = hinge.motor.motorSpeed;
        

    }

    // Update is called once per frame
    void Update () {

        if (playerHit)
        {
            hinge.useMotor = false;
        }
        else if (timeUntilLeverFix < 0)
        {
            hinge.useMotor = true;
        }

        if (hinge.jointAngle > hinge.limits.max - 20 && pushedDown)
        {
            motor.motorSpeed = +motorForce;
            pushedDown = false;
            hinge.motor = motor;
            TriggerOne();
        }

        if (hinge.jointAngle < hinge.limits.min + 20 && !pushedDown)
        {
            motor.motorSpeed = -motorForce;
            pushedDown = true;
            hinge.motor = motor;
            TriggerTwo();
        }

        timeUntilLeverFix -= Time.deltaTime;

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) 
        {
            playerHit = true;
            timeUntilLeverFix = 0.1f;
        }

    }

    void LateUpdate()
    {
        playerHit = false;
    }

    void TriggerOne()
    {
        foreach (Triggerable i in triggers_1)
        {
            if (i)
            {
                i.Trigger();
            }
        }

        Debug.Log(transform.parent.name + " triggered event one.");

    }

    void TriggerTwo()
    {

        foreach (Triggerable i in triggers_2)
        {
            if (i)
            {
                i.Trigger();
            }
        }

        Debug.Log(transform.parent.name + " triggered event two.");
    }

    public override void Trigger()
    {
        if (hinge.useMotor == false)
        {
            hinge.useMotor = true;
        }

        else if (hinge.useMotor == true)
        {
            hinge.useMotor = false;
        }
    }
}
