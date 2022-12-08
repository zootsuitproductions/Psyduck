using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxSoundController : MonoBehaviour
{
    private AudioSource source;

    public AudioClip clip;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        source.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
