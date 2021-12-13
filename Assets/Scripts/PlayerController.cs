using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    private Rigidbody2D rb;
    private Animator animator;
    
    public float movementSpeed;
    private Vector2 movement;
    
    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private GameObject[] enemies;
    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (enemies.Length == 0) {
            other.GetComponent<RandomWalk>().GenerateDungeon();
            transform.position = new Vector3(-2.4f, 2.4f, -0.2f);
        }
    }

}