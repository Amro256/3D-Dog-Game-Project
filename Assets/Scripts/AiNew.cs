using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AiNew : MonoBehaviour
{
    public int rute;
    public float beat;
    public Animator Anim;
    public Quaternion Angle;
    public float grade;

    public GameObject Target;
    public bool Attack;

    public GameObject Hbox;
    public bool stun;

    public float speed;

    public NavMeshAgent agents;
    public float DistanceA;
    public float Rvision;

    public RangeAttack RangeAtt;


    void Start()
    {
        Anim = GetComponent<Animator>();
        Target = GameObject.Find("Fox");
    }

    // Update is called once per frame
    
    //How the Ai is going to move when it see the player
    public void EnemyPath()
    {
        //This code is going to generate a number that is going to cause that the enemy is going to stay in a area o move.
        if (Vector3.Distance(transform.position, Target.transform.position) > 5)
        {
            agents.enabled = false;
           
            beat += 1 * Time.deltaTime;
            if (beat >= 4)
            {
                rute = Random.Range(0, 2);
                beat = 0;
            }
            
            switch (rute)
            {
                case 0:
                    Anim.SetBool("walk", false);
                    break;


                case 1:
                    grade = Random.Range(0, 360);
                    Angle = Quaternion.Euler(0, grade, 0);
                    rute++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Angle, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    Anim.SetBool("walk", true);
                    break;

            }
        }
        //if the player get in the area of detection of the enemy, the enmy is going to stop walking and is going to run towards the player and attack it.
        else
      
        {
              var lookPos = Target.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
            if (Vector3.Distance(transform.position, Target.transform.position) >1 && !Attack) { 
        
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            Anim.SetBool("walk", false);
            Anim.SetBool("run", true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                Anim.SetBool("attack", false);
            }

            else
            {
                if (!stun && !Attack)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                    Anim.SetBool("walk", false);
                    Anim.SetBool("run", false);
                   
                }
              


            }

        }
        }

    //Amimation that is going to cancel the attacks .
    public void FinalAnim()
    {
        Anim.SetBool("attack", false);
        Attack = false;
        stun = false;
        RangeAtt.GetComponent<CapsuleCollider>().enabled = true;
    }
    

    void Update()
    {
        EnemyPath();
    }

}
