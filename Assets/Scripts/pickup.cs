using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour {

    private bool collected;
    private bool hasEffect;
    private bool played;

    public float fadeSpeed;

    private SpriteRenderer sprite;

    public ParticleSystem pickupEffect;
    public ParticleSystem[] passiveEffects;

    private Color fade = Color.white;
    private AudioSource audio;


    // Use this for initialization
    void Start () {

        sprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

        if (collected)
        {

            fade.a = Mathf.MoveTowards(fade.a, 0, Time.deltaTime * fadeSpeed);

            if (pickupEffect && !played)
            {
                hasEffect = true;
                pickupEffect.Play();
                played = true;

                if (audio)
                {
                    audio.Play();
                }

            }

            if (passiveEffects[0])
            {
                if (collected)
                {
                    foreach (ParticleSystem item in passiveEffects)
                    {
                        item.Stop();
                    }
                }
            }

            if (!hasEffect || !pickupEffect.isPlaying)
            {
                if (sprite.color.a <= 0 && !audio.isPlaying)
                {
                    Destroy(transform.parent.gameObject, 3);
                }
            }

            sprite.color = fade;
            
        }

		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collected = true;
        }
    }
}
