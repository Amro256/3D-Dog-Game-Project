using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintActivation : MonoBehaviour
{
    HintWindow hints; // reference to HintWindow Script
    // Start is called before the first frame update

    //Script not being used

    public void OnTriggerEnter(Collider other) 
    {
        if(gameObject.CompareTag("Player"))
       {
            hints.showMessage();
       } 
    }
}
