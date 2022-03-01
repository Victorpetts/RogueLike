using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour {
    public Transform attackPoint;
    public LayerMask enemyLayer;

    public float attackRange = 0.5f;
    public float attackDamage = 1f;

    public float attackRate = 2f;
    private float nextAttackTime;
    
    public Renderer attackCircle;
    public UIManager ui;
    
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    
    public Image hpBar;
    public Image hpBarEffect;
    
    private float CurrentHealth {
        get => currentHealth;
        set {
            currentHealth = value;
            if (currentHealth <= 0) {
                GameOver();
            }
        }
    }

    private void Start() {
        CurrentHealth = maxHealth;
    }

    void Update() {
        DisplayHpBar();
        
        if (Time.time >= nextAttackTime) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void GameOver() {
        gameObject.SetActive(false);
        ui.ActivatePanel();
    }

    public void TakeDamage(float damage) {
        CurrentHealth -= damage;
    }

    void Attack() {
        attackCircle.enabled = true;
        StartCoroutine(CircleEffect());

        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (var enemy in enemiesHit) {
            enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
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
    
    private void DisplayHpBar() {
        hpBar.fillAmount = CurrentHealth / maxHealth;

        if (hpBarEffect.fillAmount > hpBar.fillAmount) {
            hpBarEffect.fillAmount -= 0.005f;
        } else {
            hpBarEffect.fillAmount = hpBar.fillAmount;
        }
    }
}
