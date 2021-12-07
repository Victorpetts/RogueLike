using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    private Rigidbody2D rb;
    private Transform transform;
    private Animator animator;
    
    public float movementSpeed;

    private Vector2 movement;
    
    private void Start() {
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetBool("IsMoving", movement.magnitude > 0);

        transform.localScale = movement.x switch {
            1 => new Vector2(-1f, 1f),
            -1 => new Vector2(1f, 1f),
            _ => transform.localScale
        };
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}