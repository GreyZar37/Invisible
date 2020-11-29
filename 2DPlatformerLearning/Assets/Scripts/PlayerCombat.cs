using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Transform attackpoint;
    public float attackRange = 0.5f;

    public LayerMask enemyLayers;

    private float currentAttackTimer;
    private float attackCooldown = 0.25f;





    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        currentAttackTimer -= Time.deltaTime;

        if (currentAttackTimer <= 0)
        {
            currentAttackTimer = 0;
        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && currentAttackTimer == 0)
        {
            Attack();            
            currentAttackTimer = attackCooldown;
            
        }
    }

    void Attack()
    {
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            
            enemy.GetComponent<EnemyHealth>().takeDamage(20);
            enemy.GetComponent<AiController>().damagedFlip(true, 0.3f);
 
        }

       

    }
    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;

        Gizmos.DrawSphere(attackpoint.position, attackRange);
    }

}

