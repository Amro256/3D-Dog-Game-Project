using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{

    public GameObject pausePanel; //Allows the pannel to be dropped in the inspector
    public GameObject gameOverPanel; //Allows the pannel to be dropped in the inspector

    public bool gamePaused;
    // Start is called before the first frame update
    void Start()
    {
        //Set both to false when the game starts so they dont pop up
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) //if the escape key is pressed then the pause pannel will pop up
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                GamePaused();
            }
        }
    }

    //Methods to deal with the different states
    public void GamePaused()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f; //This will freeze everything in game - Besides music/ambidence
        gamePaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f; //Will resume everything 
        gamePaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Game Quit!"); //Test to see if it work
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0); //Loads the main Menu scene
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene"); //Sample scene is the name of our level
        Time.timeScale = 1f;
        gamePaused = false;
    }

}
