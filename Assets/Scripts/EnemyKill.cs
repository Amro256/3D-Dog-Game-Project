using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    PlayerMovement pm;
    [SerializeField] private AudioSource killSound;

    void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other) 
    {
       if(other.gameObject.CompareTag("Spider") && pm.movSpeed == 7.5) //if the player collides with an object with the tag "Spider"  and move speed is equal to 7.5
       {
            killSound.Play();
            Destroy(other.gameObject); //then destroy the spider enemey
       } 
    }
}
