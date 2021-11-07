using UnityEngine;

public class Enemy : MonoBehaviour {
    public Animator animator;
    
    public int maxHealth = 100;
    private int currentHealth;
    
    void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log(name + " died. Big sad!");

        animator.SetBool("Death", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}