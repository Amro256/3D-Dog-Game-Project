using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    PlayerMovement pm;
    public bool Grounded;
    
    //Not being used
    // Start is called before the first frame update

     private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player")) 
        {
            //print("Bone Collected");
            Destroy(gameObject);
        }
}
}
