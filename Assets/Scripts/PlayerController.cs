using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float speed;
    private Animator animator;
    private SpriteRenderer sprite;
    // private Transform transform;

    private void Start() {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        // transform = GetComponent<Transform>();
    }

    private void Update() {
        Vector2 dir = Vector2.zero;
        
        if (Input.GetKey(KeyCode.A)) {
            dir.x = -1;
            sprite.flipX = false;
            // transform.Rotate(0, 180, 0);
        }
        else if (Input.GetKey(KeyCode.D)) {
            dir.x = 1;
            sprite.flipX = true;
            // transform.Rotate(0, 180, 0);
        }
        
        if (Input.GetKey(KeyCode.W)) {
            dir.y = 1;
        }
        else if (Input.GetKey(KeyCode.S)) {
            dir.y = -1;
        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * dir;
        
        // if (Input.GetKeyDown(KeyCode.Space)) {
        //     animator.SetTrigger("Attack");
        // }
    }
}