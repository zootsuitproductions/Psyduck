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

    public float throwStrength;
    
    private GameObject instantiatedPokeball;

    private bool throwing = false;

    public void ThrowRelease()
    {
        Debug.Log("Hello");
        if (instantiatedPokeball != null)
        {
            Debug.Log("Hello");
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
            throwing = true;
            instantiatedPokeball = Instantiate(pokeball, ballholder, false);
            instantiatedPokeball.transform.position = ballholder.position;
            animator.SetTrigger("Throw");
        }
       
    }
}
