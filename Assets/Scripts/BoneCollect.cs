using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneCollect : MonoBehaviour
{
    public int boneValue = 1; //gives a value to the bones
    StaminaBar stam;
    public ParticleSystem bonePar;
    [SerializeField] private AudioSource boneColelct;
    [SerializeField] private AudioSource powerBone;
    
    // Start is called before the first frame update
    void Start()
    {
        stam = GetComponent<StaminaBar>(); //reference to stamina bar slider script
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bones"))
        {
            boneColelct.Play(); //Bone collect sounds play
            //Manager.AddingBones(boneValue);
            Instantiate(bonePar, transform.position, transform.rotation); //Calls the particle effect in the postion and roation of the boen
            print("Bone Collected");
            print("Stamina refilled");
            Destroy(other.gameObject); //bone is destroyed when it is collected 
            
            

            if(stam.stamina != stam.maxStamina) //if the current stamina is not max then call the increaseStam function from the stamina bar script
            stam.IncreaseStam();
            stam.stamBar.value = stam.stamina; //Updating the stamina bar UI
        }


        if(other.gameObject.CompareTag("PowerBone")) //Once this bone is collected the stamina will be set to 10 acting as max stamina. This will act as a powerup
            {
                powerBone.Play();
                Destroy(other.gameObject);
                stam.stamina = 100; //Sets the stamina to max for a few seconds 
                stam.stamBar.value = stam.stamina;
                StartCoroutine(PowerDown()); //Calling the power Down method
            }

            if(other.gameObject.CompareTag("RedBone"))
        {
            boneColelct.Play();
            Manager.AddingBones(boneValue); //Updates the UI for the bone. This was originally for the regular bones but changed 
            Instantiate(bonePar, transform.position, transform.rotation); //Calling particle system
            Destroy(other.gameObject); //bone is destroyed when it is collected 
    }


    IEnumerator PowerDown() //Timer for powerup
    {
        yield return new WaitForSeconds(5f); //Wait 5 seconds before changing the stamina value/bar back to the value set
        stam.stamina = 2;
        stam.stamBar.value = stam.stamina;
    }




    
}}
