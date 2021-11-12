using UnityEngine;

public class PlayerCombat : MonoBehaviour {
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayer;

    public float attackRange = 0.5f;
    public float attackDamage = 1f;

    public float attackRate = 2f;
    private float nextAttackTime;
    
    void Update() {
        if (Time.time >= nextAttackTime) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack() {
        animator.SetTrigger("Attack");

        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (var enemy in enemiesHit) {
            switch (enemy.name) {
                case "Bat":
                    enemy.GetComponent<EnemyBat>().TakeDamage(attackDamage);
                    break;
                case "Slime":
                    enemy.GetComponent<EnemySlime>().TakeDamage(attackDamage);
                    break;
                case "Witch":
                    enemy.GetComponent<EnemyWitch>().TakeDamage(attackDamage);
                    break;
            }
        }
    }

    private void OnDrawGizmosSelected() {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
