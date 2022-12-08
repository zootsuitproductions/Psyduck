using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public TMP_Text numCaught;

    public TMP_Text time;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Screen.lockCursor = false;
        
        numCaught.text = "You caught " + GameLogic.numCaught.ToString() + "/" + GameLogic.numCreatures.ToString() +
                         " creatures in " + GameLogic.time.ToString() + " seconds!";
    }


    public void PlayAgain()
    {
        Debug.Log("play again");
        SceneManager.LoadScene(1);
    }
}