using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkSound : MonoBehaviour
{
    public AudioSource[] barkSound; //Creates an array that can be altered in the inspectro

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Key1")) //Once the '1' key is pressed then the sound will play
        {
            barkSound[0].Play();
        }
    }
}
