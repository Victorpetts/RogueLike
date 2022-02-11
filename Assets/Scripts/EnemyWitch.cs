using UnityEngine;

public class EnemyWitch : EnemyController {
    
    [SerializeField] private float atkRate = 2.1f;
    private float atkTimer;
    public GameObject projectile;

    protected override void Chase() {
        // Teleport();
    }

    protected override void Attack() {
        atkTimer += Time.deltaTime;
        
        if (atkTimer > atkRate) {
            Instantiate(projectile, transform.position, Quaternion.identity);
            atkTimer = 0;
        }
    }

}
