using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : Triggerable
{

    public Triggerable[] triggers_1;
    public Triggerable[] triggers_2;

    public bool stayPressed;


    private SliderJoint2D slider;
    private bool pushedDown = false;

    // Use this for initialization
    void Start()
    {

        slider = this.GetComponent<SliderJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (slider.jointTranslation < slider.limits.min + 0.05f && !pushedDown)
        {
            pushedDown = true;
            TriggerOne();
        }
        else if (slider.jointTranslation > slider.limits.min + 0.05f && pushedDown)
        {
            pushedDown = false;
            TriggerTwo();
        }
            

        if (stayPressed)
        {
            slider.useMotor = false;
        }

        else
            slider.useMotor = true;
    }

    void OnCollisionStay2D(Collision2D collision)
    {

    }

    void TriggerOne()
    {
        foreach (Triggerable i in triggers_1)
        {
            i.Trigger();
        }

        Debug.Log(transform.parent.name + " triggered event one.");

    }

    void TriggerTwo()
    {

        foreach (Triggerable i in triggers_2)
        {
            i.Trigger();
        }

        Debug.Log(transform.parent.name + " triggered event two.");
    }



    public override void Trigger()
    {
        if (stayPressed)
        {
            stayPressed = false;
        }
        else if (!stayPressed)
        {
            stayPressed = true;
        }
    }

}
