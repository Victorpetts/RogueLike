using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    [SerializeField] private string enemyName;
    [SerializeField] private protected float moveSpeed;
    [SerializeField] private float maxHealth;
    [SerializeField] private protected float aggroRange;
    [SerializeField] private float currentHealth;

    private protected Transform target;
    private SpriteRenderer sprite;

    public Image hpBar;
    public Image hpBarEffect;

    void Start() {
        currentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        
        Debug.Log(this.name + " has hp " + currentHealth);

    }

    void Update() {
        FacePlayer();
        DisplayHpBar();
    }

    private void FixedUpdate() {
        Chase();
        // Attack();
    }
    
    public void TakeDamage(float damage) {
        Debug.Log(this.name + " got hit for dmg " + damage);
        currentHealth -= damage;

        // animator.SetTrigger("Hurt");

        Debug.Log(this.name + " has hp " + currentHealth);

        if (currentHealth <= 0)
            Death();
    }

    protected virtual void Chase() {
        if (Vector2.Distance(transform.position, target.position) < aggroRange) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    void FacePlayer() {
        sprite.flipX = transform.position.x > target.position.x;
    }

    protected virtual void Attack() {
        Debug.Log(enemyName + " attacked");
    }
    
    protected virtual void Death() {
        Destroy(gameObject);
    }

    protected virtual void DisplayHpBar() {
        hpBar.fillAmount = currentHealth / maxHealth;

        if (hpBarEffect.fillAmount > hpBar.fillAmount) {
            hpBarEffect.fillAmount -= 0.005f;
        }
        else {
            hpBarEffect.fillAmount = hpBar.fillAmount;
        }
    }
}
