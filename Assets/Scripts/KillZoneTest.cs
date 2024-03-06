using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneTest : MonoBehaviour
{
   [SerializeField] private AudioSource deathSound; //Sounds for when the player dies
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            deathSound.Play(); //Sounds plays when player hits the kill zone
            collision.gameObject.transform.position = Manager.lastCheckPoint; //Resets the player back to the last checkpoint they activated 
            Manager.AddLives(-1); //Remove a live if player dies
           //Manager.resetBones();
            
        }
    }
}
