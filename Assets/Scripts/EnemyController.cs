using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] private string enemyName;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxHealth;
    private float currentHealth;

    private Transform target;
    [SerializeField] private float aggroRange;
    private SpriteRenderer sprite;
    
    void Start() {
        currentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();

        Debug.Log(enemyName + " has " + currentHealth + " hp and " + moveSpeed + " speed");
    }

    void Update() {
        Chase();
        FacePlayer();
    }

    void Chase() {
        if (Vector2.Distance(transform.position, target.position) < aggroRange) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    void FacePlayer() {
        sprite.flipX = transform.position.x > target.position.x;
    }
}
