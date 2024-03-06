using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public static Vector3 lastCheckPoint;
    public static int lives, bones;
    static UI gameUI; //Reference to UI script
    static PauseUI pauseUI; //Reference to the PauseUI Script
     private void Awake() {
        if(instance == null) //if there is one instance/copy of the manager then dont destroy 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject); //else destroy
        }
        gameUI = FindObjectOfType<UI>(); //Finds the UI
        bones = 0; //Hard code value for bones
        lives = 4; //Hard code values for lives
        gameUI.UpdateLivesCounter();
        gameUI.UpdateBoneCounter();
        
    }

    public static void AddingBones(int boneValue) //Method to add the bones and update the UI for it
    {
        bones += boneValue;

        gameUI.UpdateBoneCounter();

    }
    

    public static void AddLives(int LifePoints) //Method that deals with the lives
    {
        lives += LifePoints;
        if(lives <0)
        {
            FindObjectOfType<PauseUI>().GameOver(); //calls the game over pannel.
             //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        else
        {
            gameUI.UpdateLivesCounter(); //Update the live counter 
        }
        
    }

    public static void UpdateCheckPoints(GameObject Checkpoint) //Method to deal with the Checkpoints
    {
        lastCheckPoint = Checkpoint.transform.position;
        //Need array fo checkpoints then use a loop to change the colour of the flags for other checkpoints
        CheckPoint[] allPoints = FindObjectsOfType<CheckPoint>(); //array that will check every object with the Checkpoint Script attached to it
        foreach(CheckPoint cp in allPoints)
        {
           if(cp != Checkpoint.GetComponent<CheckPoint>())
           {
                cp.disableCheckpoint(); //Changes the flag colour to red 
           }
        }
    }

    public static void resetBones() //Method to rest bone counter when player dies 
    {
        bones = 0;
        gameUI.UpdateBoneCounter();
    }


}
