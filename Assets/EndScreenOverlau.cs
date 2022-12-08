using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenOverlau : MonoBehaviour
{
    
    public void ReturnToStart()
    {    
        Debug.Log("return");
        SceneManager.LoadScene(0);
    }
}
