using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
     void OnTriggerEnter(Collider other) 
    {

        if(other.gameObject.CompareTag("Player") && Manager.bones >= 20) // the player will need to have more than 1 bone to end the level
        {
            SceneManager.LoadScene(2); //Loads to game end scene
        }  
    }
}
