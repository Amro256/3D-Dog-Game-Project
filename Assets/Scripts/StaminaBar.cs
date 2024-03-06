using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour
{
    public float stamina;
    public float maxStamina;

    public Slider stamBar;
    public float decValue = 1;
    // Start is called before the first frame update
    void Start()
    {
        maxStamina = stamina; //When the game starts the max stamina will be set to the stamina that has been set in the inspector
        stamBar.value = maxStamina; //the stamina bar value will then match the max stamin value
    }



    public void DecreaseStam() //Method to decrease stamina. Will be used when the player sprints 
    {
        if(stamina !=0)
        stamina -= decValue * Time.deltaTime; 
        
    }

    public void IncreaseStam() //Method to increase stamina. THis will mainly be used when colllecting the bones
    {
        stamina += decValue + 1 * Time.deltaTime;
    }
}


