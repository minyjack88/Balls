using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheck : MonoBehaviour {

    public bool pressedLeftOrRight = false;
    public bool tutReady = false;
    public ParticleSystem particle;

    public float timeUntilTutReady;

    public SpriteRenderer fadeBackground;
    public SpriteRenderer fadeInstructions;
    public SpriteRenderer fadeText;
    public GameObject colliders;
    public float countdown;

    private Color fade1 = Color.white;
    private Color fade2 = Color.white;
    // Use this for initialization
    void Start () {

        fade2.a = 0;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (timeUntilTutReady < 3)
        {
            fade2.a = Mathf.MoveTowards(fade2.a, 1, Time.deltaTime / 3);
        }

        if (timeUntilTutReady < 0)
        {

            if (Input.GetKey("left") || Input.GetKey("right"))
            {
                pressedLeftOrRight = true;
            }

            if (pressedLeftOrRight && countdown < 0)
            {
                fade1.a = Mathf.MoveTowards(fade1.a, 0, Time.deltaTime);
                fade2.a = Mathf.MoveTowards(fade2.a, 0, Time.deltaTime);
                particle.Stop();
                Destroy(colliders);

                if (fade1.a == 0 && fade2.a == 0)
                {
                    Destroy(fadeBackground.gameObject);
                    Destroy(fadeInstructions.gameObject);
                    Destroy(fadeText.gameObject);
                    Destroy(gameObject);
                }
            }

        }

        if (!pressedLeftOrRight)
        {
            fade1.a = Mathf.MoveTowards(fade1.a, 0, Time.deltaTime / 10);
        }

        if (pressedLeftOrRight)
        {
            countdown -= Time.deltaTime;
        }

        timeUntilTutReady -= Time.deltaTime;

        fadeInstructions.color = fade2;
        fadeText.color = fade2;
        fadeBackground.color = fade1;
    }
}
