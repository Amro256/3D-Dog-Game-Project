using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HpBar HpBar;
    //The health bar is going to be equeal to the max health.
    void Start()
    {
        currentHealth = maxHealth;
        HpBar.SetMaxhealth(maxHealth);
    }
    // the bar is equal to the current health
    void Update()
    { 
        HpBar.Sethealth(currentHealth);
    }
    // if the player recive damage the health decrease

   public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = Manager.lastCheckPoint;
            currentHealth = maxHealth; //When the player dies, they come back at 100 HP instead of -20
            Manager.AddLives(-1);
            //Destroy(gameObject);
        }


    }
}
