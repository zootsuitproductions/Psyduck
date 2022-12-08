using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallThrower : MonoBehaviour
{
    public GameObject pokeball;
    public Transform ballholder;
    public Animator animator;
    public Transform camera;

    public AudioSource source;
    public AudioClip throwSound;
    public float throwStrength;
    
    private GameObject instantiatedPokeball;

    private bool throwing = false;

    public void ThrowRelease()
    {
        if (instantiatedPokeball != null)
        {
            source.clip = throwSound;
            source.Play();
            instantiatedPokeball.transform.parent = null;
            instantiatedPokeball.GetComponent<SphereCollider>().enabled = true;
            instantiatedPokeball.GetComponent<Rigidbody>().useGravity = true;

            Vector3 throwVector = camera.forward * throwStrength;
            instantiatedPokeball.GetComponent<Rigidbody>().AddForce(throwVector, ForceMode.Impulse);

            instantiatedPokeball = null;

            throwing = false;

        }
    }
    
    public void ThrowEnded()
    {
        // throwing = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (instantiatedPokeball != null)
            {
                Destroy(instantiatedPokeball);
                instantiatedPokeball = null;
            }
            throwing = true;
            instantiatedPokeball = Instantiate(pokeball, ballholder, false);
            instantiatedPokeball.transform.position = ballholder.position;
            animator.SetTrigger("Throw");
        }
       
    }
}
