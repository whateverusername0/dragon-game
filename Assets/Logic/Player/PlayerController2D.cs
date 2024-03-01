using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public Creature2D ControlledCreature;
    public Weapon2D CurrentWeapon;
    public Rigidbody2D WeaponPivot;

    private void Update()
    {
        // enemy detection
        if (Input.GetMouseButtonDown(0))
        {
            var closestCreature = FindClosestEnemy();
            if (closestCreature == null) return;

            var direction = closestCreature.RB.position - ControlledCreature.RB.position;
            var aimAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            WeaponPivot.transform.eulerAngles = new Vector3(0, 0, aimAngle);

            // lunge & melee example
            if ((closestCreature.transform.position - transform.position).magnitude <= .35f)
                Attack(closestCreature);
            else Lunge(closestCreature);
        }
    }

    private Creature2D FindClosestEnemy()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 3.5f, Vector2.up, 0, 1 << (int)Global.Layers.Creature);

        if (hits.Length == 0) return null;

        float shortestDistance = Mathf.Infinity;
        Creature2D closestCreature = null;
        foreach (var hit in hits)
        {
            float distance = Vector2.Distance(hit.transform.position, transform.position);
            if (distance < shortestDistance && distance != 0)
            {
                shortestDistance = distance;
                closestCreature = hit.transform.GetComponent<Creature2D>();
            }
        }
        return closestCreature;
    }

    void Lunge(Creature2D target)
    {
        ControlledCreature.RB.AddForce((Vector2)(target.transform.position - transform.position).normalized * 10f);
    }
    void Attack(Creature2D target)
    {
        CurrentWeapon.Fire((Vector2)(target.transform.position - transform.position));
    }
}
