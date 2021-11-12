using UnityEngine;

public class Projectile : MonoBehaviour {
    private Transform target;
    
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float lifeTime = 3f;
    private float lifeTimer;
    
    // public GameObject destroyEffect;

    private void Awake() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target.position, projectileSpeed * Time.deltaTime);

        lifeTimer += Time.deltaTime;
        if(lifeTimer >= lifeTime) {
            // Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            // Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}