using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private protected int moveSpeed;
    [SerializeField] private protected int aggroRange;

    private protected Transform target;
    private protected PlayerCombat playerCombat;
    private SpriteRenderer sprite;

    public Image hpBar;
    public Image hpBarEffect;

    private float CurrentHealth {
        get => currentHealth;
        set {
            currentHealth = value;
            if (currentHealth <= 0) {
                Death();
            }
        }
    }

    private void Start() {
        CurrentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        FacePlayer();
        DisplayHpBar();
    }

    private void FixedUpdate() {
        Chase();
        Attack();
    }
    
    public void TakeDamage(float damage) {
        CurrentHealth -= damage;
    }
    
    private void Death() {
        Destroy(gameObject);
    }

    protected virtual void Chase() {
        if (Vector2.Distance(transform.position, target.position) < aggroRange) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    protected virtual void Attack() {
        if (Vector2.Distance(transform.position, target.position) < 1) {
            Debug.Log(this.name + " attacked");
            playerCombat.TakeDamage(1);
        }
    }

    private void FacePlayer() {
        sprite.flipX = transform.position.x > target.position.x;
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
