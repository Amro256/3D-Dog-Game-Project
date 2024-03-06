using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void playGame()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //When the player button is pressed it will load the level scene based on the index
   }

    public void QuitGame()
    {
        Application.Quit();
        print("Game Quit!");
    }
}
