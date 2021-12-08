using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayer;

    public float attackRange = 0.5f;
    public float attackDamage = 1f;

    public float attackRate = 2f;
    private float nextAttackTime;
    
    public Renderer attackCircle;
    
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    private void Start() {
        CurrentHealth = maxHealth;
    }

    void Update() {
        if (Time.time >= nextAttackTime) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    
    private float CurrentHealth {
        get => currentHealth;
        set {
            currentHealth = value;
            if (currentHealth <= 0) {
                GameOver();
            }
        }
    }

    void GameOver() {
        Debug.Log("You dead");
    }

    public void TakeDamage(float damage) {
        CurrentHealth -= damage;
    }

    void Attack() {
        // animator.SetTrigger("Attack");
        attackCircle.enabled = true;
        StartCoroutine(CircleEffect());

        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (var enemy in enemiesHit) {
            switch (enemy.name) {
                case "Bat(Clone)":
                    enemy.GetComponent<EnemyBat>().TakeDamage(attackDamage);
                    break;
                case "Slime(Clone)":
                    enemy.GetComponent<EnemySlime>().TakeDamage(attackDamage);
                    break;
                case "Witch(Clone)":
                    enemy.GetComponent<EnemyWitch>().TakeDamage(attackDamage);
                    break;
            }
        }
    }

    IEnumerator CircleEffect() {
        yield return new WaitForSeconds(0.1f);
        attackCircle.enabled = false;
    }

    private void OnDrawGizmosSelected() {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
