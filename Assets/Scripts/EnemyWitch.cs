using UnityEngine;

public class EnemyWitch : EnemyController {
    [SerializeField] private float tpRate = 2f;
    private float tpTimer;

    [SerializeField] private float atkRate = 2.1f;
    private float atkTimer;
    public GameObject projectile;

    [SerializeField] private float minX, maxX, minY, maxY;

    protected override void Chase() {
        Teleport();
    }

    private void Teleport() {
        tpTimer += Time.deltaTime;

        if (tpTimer > tpRate) {
            transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            tpTimer = 0;
        }
    }

    protected override void Attack() {
        atkTimer += Time.deltaTime;
        
        if (atkTimer > atkRate) {
            Instantiate(projectile, transform.position, Quaternion.identity);
            atkTimer = 0;
        }
    }

}
