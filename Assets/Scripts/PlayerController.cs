using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float movementSpeed;
    private Animator animator;
    private Transform transform;
    private Rigidbody2D rb;

    private void Start() {
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Vector2 dir = Vector2.zero;
        
        if (Input.GetKey(KeyCode.A)) {
            dir.x = -1;
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (Input.GetKey(KeyCode.D)) {
            dir.x = 1;
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
        
        if (Input.GetKey(KeyCode.W)) {
            dir.y = 1;
        }
        else if (Input.GetKey(KeyCode.S)) {
            dir.y = -1;
        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        rb.velocity = movementSpeed * dir;
    }
}