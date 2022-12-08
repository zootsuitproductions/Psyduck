using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoxSoundController : MonoBehaviour
{
    private AudioSource source;

    public AudioClip clip;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0.5f;
    }

    private void Start()
    {
        Invoke("playSound", Random.Range(10f, 30f));
    }

    void playSound()
    {
        source.clip = clip;
        source.Play();
        
        Invoke("playSound", Random.Range(10f, 30f));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
