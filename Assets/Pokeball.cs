using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    public ParticleSystem particles;
    public Rigidbody rigid;

    public GameLogic logic;

    public AudioClip zap;
    public AudioClip hitSound;
    public AudioSource source;

    private int animationPhase = 0;

    private bool hit = false;

    private GameObject creature;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        
        particles.Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == 3) //hit creature
        {
            hit = true;
            
            creature = collision.collider.gameObject.GetComponent<NPCStateManager>().gameObject;
            // particles.Play();

            // particles.Play();
            // rigid.isKinematic = true;
            // collision.collider.gameObject.GetComponent<NPCStateManager>().gameObject.SetActive(false);

        }
    }

    private void goToPhase4()
    {
        rigid.isKinematic = false;
        animationPhase = 4;
    }
    private void goToPhase5()
    {
        animationPhase = 5;
        rigid.isKinematic = true;
        source.clip = hitSound;
        source.Play();
        logic.handlePokemonCaught();
    }
    
    private float stage3Timer = 0f;
    private float stage4Timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            switch (animationPhase)
            {
                case 0:
                    rigid.velocity = Vector3.zero;
                    rigid.AddForce(Vector3.up * 3, ForceMode.Impulse);
                    animationPhase = 1;
                    break;
                case 1:
                    if (rigid.velocity.y < 0)
                    {
                        animationPhase = 2;
                    }
                    break;
                case 2:
                    rigid.isKinematic = true;
                    particles.Play();
                    source.clip = zap;
                    source.Play();
                    creature.SetActive(false);
                    animationPhase = 3;
                    break;
                case 3:
                    if (stage3Timer >= 0.5f)
                    {
                        rigid.isKinematic = false;
                        animationPhase = 4;
                    }
                    stage3Timer += Time.deltaTime;
                    // Invoke("goToPhase4", 0.5f);
                    break;
                case 4:
                    if (stage4Timer >= 1f)
                    {
                        animationPhase = 5;
                        rigid.isKinematic = true;
                        source.clip = hitSound;
                        source.Play();
                        logic.handlePokemonCaught();
                    }
                    stage4Timer += Time.deltaTime;
                    // Invoke("goToPhase5", 1f);
                    break;
                case 5:
                    
                    break;


            }
            
        }
    }
}
