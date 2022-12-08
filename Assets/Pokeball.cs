using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    public ParticleSystem particles;
    public Rigidbody rigid;

    private bool hit = false;
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
            particles.Play();
            
            // particles.Play();
            rigid.isKinematic = true;
            // collision.collider.gameObject.GetComponent<NPCStateManager>().gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
