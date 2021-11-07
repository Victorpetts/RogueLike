using UnityEngine;

public class EnemyBat : EnemyController {
    public Transform wayPoint1, wayPoint2;
    private Transform waypointTarget;

    private void Awake() {
        waypointTarget = wayPoint1;
    }

    protected override void Chase() {
        base.Chase();
        
        if (Vector2.Distance(transform.position, target.position) > aggroRange) {
            // if (Vector2.Distance(transform.position, waypointTarget.position) < 0.01f) {
            //     waypointTarget = wayPoint1 ? wayPoint2 : wayPoint1;
            // }            
            if (Vector2.Distance(transform.position, waypointTarget.position) < 0.01f) {
                waypointTarget = wayPoint2;
            }
            if (Vector2.Distance(transform.position, wayPoint2.position) < 0.01f) {
                waypointTarget = wayPoint1;
            }
            
            transform.position =
                Vector2.MoveTowards(transform.position, waypointTarget.position, moveSpeed * Time.deltaTime);
        }
    }
}
