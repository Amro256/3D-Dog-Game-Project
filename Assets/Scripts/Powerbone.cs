using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerbone : MonoBehaviour
{
    // Start is called before the first frame update
    //Not being used
    private void OnTriggerEnter(Collider other) 
    {
        if(gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }    
    }
}
