using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Add animation for Attack
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemyLayers;
    public int AttackDamage = 40;
    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.movSpeed == 7.5) //if player move speed is equal to 7.5 then destroy enemey
        {
            Attack();
        }
        void Attack()
        {
         Collider[] hitEnemies=   Physics.OverlapSphere(AttackPoint.position, AttackRange,enemyLayers);

            foreach(Collider enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHp>().TakeDamage(AttackDamage);
            }
        }

    }

    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;


        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }


}
