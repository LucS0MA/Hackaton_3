using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform boxCombat;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Combat");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(boxCombat.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
        }
    }


    void OnDrawGizmosSelected()
    {
        if (boxCombat == null)
            return;

        Gizmos.DrawWireSphere(boxCombat.position, attackRange);
    }

}