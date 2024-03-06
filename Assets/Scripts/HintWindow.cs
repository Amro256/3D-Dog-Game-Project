using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HintWindow : MonoBehaviour
{
    [SerializeField] private AudioSource popSound;

    [SerializeField] private Button gotIt; //Refernece to button and is able to be dropped into a box in the inspector
    public GameObject hintWindow; //Reference to the Hint window UI that can be dropped into a box in the inspector
    PlayerMovement pm;
    
    void Start()
    {
        hintWindow.SetActive(false); //The Hint window is set to false to start
        gotIt.onClick.AddListener(ButtonClick); //When the button is clicked it will listen for an event and actives the code set to it
        pm = GetComponent<PlayerMovement>();
    }
    public void showMessage() //Methods that activates the UI and everything in the game stops
    {
        hintWindow.SetActive(true);
        Time.timeScale = 0f; 
    }


    void ButtonClick() //method to deal with disabling the UI and resuming the game
    {
        hintWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    void OnTriggerEnter(Collider other) //The showMessage function is then called when the player touches the question mark
    {
        if(other.gameObject.CompareTag("Player"))
        {
            popSound.Play();
            showMessage();
        }
    }

    

   
}
