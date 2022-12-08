using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    public ParticleSystem particles;
    public Rigidbody rigid;

    private int animationPhase = 0;

    private bool hit = false;

    private GameObject creature;
    // Start is called before the first frame update
    void Start()
    {
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
        animationPhase = 4;
    }

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
                    creature.SetActive(false);
                    animationPhase = 3;
                    break;
                case 3:
                    Invoke("goToPhase4", 0.5f);
                    break;
                case 4:
                    rigid.isKinematic = false;
                    break;
                    
            }
            
        }
    }
}
