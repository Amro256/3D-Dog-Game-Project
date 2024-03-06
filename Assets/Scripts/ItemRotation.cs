using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    int rotationSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 200; //hard coded value for the rotation speed, so all bones are rotating at the same speed
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World )  ; //Rotates on the y axis. The space world means rotation is altered by the world space
    }
}
