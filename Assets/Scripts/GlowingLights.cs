using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingLights : MonoBehaviour {

    private bool on;

    private float timeUntilOn;
    private float timeUntilOff;

    private Color targetColor = Color.white;
    private Color currentColor = Color.white;

    public float offTime;
    public float onTime;
    public float lowLightLevel;

    new private SpriteRenderer light;

   

	// Use this for initialization
	void Start () {



        light = this.GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

    
        if (on)
        {
            currentColor.a = Mathf.MoveTowards(currentColor.a, targetColor.a, Time.deltaTime);

            if (timeUntilOff < 0)
            {
                timeUntilOn = offTime;
                targetColor.a = lowLightLevel;
                on = false;
            }
        }

        if (!on)
        {

            currentColor.a = Mathf.MoveTowards(currentColor.a, targetColor.a, Time.deltaTime);

            if (timeUntilOn < 0)
            {
                timeUntilOff = onTime;
                targetColor.a = 1;
                on = true;
            }
        }

        light.color = currentColor;

        timeUntilOff -= Time.deltaTime;
        timeUntilOn -= Time.deltaTime;

    }
}
