using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EndScreen : MonoBehaviour
{
    public TMP_Text numCaught;
    public RawImage image;
    public AudioSource source;
    public AudioClip clip;

    private bool entered = false;

    // Start is called before the first frame update
    void Start()
    {
        numCaught.text = "You caught " + GameLogic.numCaught.ToString() + "/" + GameLogic.numCreatures.ToString() +
                         " creatures in " + GameLogic.time.ToString() + " seconds!";
    }

    public void MouseOnButton()
    {
        if (!entered)
        {
            image.enabled = true;
            source.clip = clip;
            source.time = 0.25f;
            source.Play();
            entered = true;
        }
    }
    
    public void MouseOffButton()
    {
        if (entered)
        {
            image.enabled = false;
            entered = false;
        }
    }

    public void PlayAgain()
    {
        
        SceneManager.LoadScene(0);
    }
}