using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    public Animator anim;
    public AiNew nemy;


    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player")){
            if (!nemy.stun)
            {
                anim.SetBool("walk", false);
                anim.SetBool("run", false);
                anim.SetBool("attack", true);
                nemy.Attack = true;
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
