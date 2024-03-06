using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform player;
    public Transform startLoc;
    public Transform Loc1;

    // this one represent the principal position of the player 
    public void teleStart()
    {
        player.transform.position = startLoc.transform.position;
    }
    //this one represent the second position.
    public void teleLoc1()
    {
        player.transform.position = Loc1.transform.position;
    }


void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
