using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public  GameObject loading; //Will allow the loading screen canvas to be dropped into a box in the inspector
     public GameObject mainMenu; //Will allows the main menu canvas to be dropped into a box in the inspector

    public void LoadLevel(int sceneId) //Will allow the build index number to be set. This will let unity know which scene to load
    {
        mainMenu.SetActive(false); //Once the play button is clicked on, the main menu will be disabled
        loading.SetActive(true); //  and Loading screen canvas will be pop up instead

        StartCoroutine(LoadSceneAsync(sceneId)); // Calling the Coroutine below.
    }


    //Coroutine code - This allows a function to be pasued until a given condition occurs
    IEnumerator LoadSceneAsync(int sceneId) //This is used to load the next scene in the background, while the main menu scene is still running. Allowing eveything to load in before gameplay
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        while(!operation.isDone) //if the loading operation is not done then it will wait for the next frame before moving on
        {
            yield return null;
        }
    }
    
    
}
