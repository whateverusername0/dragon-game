using UnityEngine;

public class Dumbass2D : MonoBehaviour
{
    public Creature2D Creature;
    public Creature2D Target;
    public Weapon2D Weapon;
    public Rigidbody2D WeaponPivot;

    public float ChaseSpeed = 1f;

    private void Update()
    {
        if (Target == null) return;
        
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * ChaseSpeed);
        var direction = Target.RB.position - Creature.RB.position;
        var aimAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        WeaponPivot.transform.eulerAngles = new Vector3(0, 0, aimAngle);

        if ((Target.transform.position - transform.position).magnitude <= .35f)
            Weapon.Fire(Target.transform.position - transform.position);
    }
}
