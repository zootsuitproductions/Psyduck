using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public GameObject fox;

    public static int numCreatures;

    public static int numCreaturesRemaining;

    public static int numCaught;

    public Transform corner1;
    public Transform corner2;

    public static float time;

    public TMP_Text timer;
    public TMP_Text updateText;
    
    // Start is called before the first frame update
    void Start()
    {
        
        updateText.enabled = false;
        numCaught = 0;
        
        for (int i = 0; i < numCreatures; i++)
        {
            Instantiate(fox, findDestination(corner1.position, corner2.position), Quaternion.identity);
        }

        numCreatures += 1; //to account for the prefab in the scene already
        numCreaturesRemaining = numCreatures;
        
    }


    public void handlePokemonCaught()
    {
        numCreaturesRemaining -= 1;
        numCaught += 1;

        updateText.text = numCreaturesRemaining.ToString() + " foxes remain!";
        updateText.enabled = true;
        Invoke("hideUpdate", 2f);
    }

    private void hideUpdate()
    {
        updateText.enabled = false;
    }
    
    private Vector3 findDestination(Vector3 p1, Vector3 p2)
    {
        float x = Random.Range(p1.x, p2.x);
        float z = Random.Range(p1.z, p2.z);
        
        return new Vector3(x, Terrain.activeTerrain.SampleHeight(new Vector3(x, 0f, z)), z);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timer.text = ((int) time).ToString();
        if (numCreaturesRemaining <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
