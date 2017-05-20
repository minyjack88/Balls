using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleGlow : MonoBehaviour {

    public float maxFlickerTime;
    public float minFlickerTime;
    public float maxOffTime;
    public float minOffTime;
    public float offTime;
    public float lowGlow;

    private float f_glow;
    private SpriteRenderer spr;
    private Color currentGlow = Color.white;
    private float timeUntilNextFlicker;
    private float timeUntilRelight = 0;
    private bool on;
    private float glowAlpha;


    // Use this for initialization
    void Start () {

        spr = this.GetComponent<SpriteRenderer>();
        currentGlow = spr.color;

    }

    // Update is called once per frame
    void FixedUpdate () {

        if (on)
        {
            glowAlpha = Mathf.MoveTowards(glowAlpha, 1, Time.deltaTime / 2);
            if (timeUntilNextFlicker < 0)
            {
                timeUntilRelight = Random.Range(minOffTime, maxOffTime);
                on = false;
            }
        }

        if (!on)
        {
            glowAlpha = Mathf.MoveTowards(glowAlpha, lowGlow, Time.deltaTime / 2);

            if (timeUntilRelight < 0)
            {
                timeUntilNextFlicker = Random.Range(minFlickerTime, maxFlickerTime);
                on = true;
            }
        }

        currentGlow.a = glowAlpha;
        spr.color = currentGlow;

        timeUntilRelight -= Time.deltaTime;
        timeUntilNextFlicker -= Time.deltaTime;

	}
}
