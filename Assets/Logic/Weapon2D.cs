using System.Runtime.CompilerServices;
using UnityEngine;

public class Weapon2D : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public float ProjectileForce = 10f;

    public float AttackSpeed = 1f;
    public float attackCooldown = 0f;

    public virtual void Fire(Vector2 Direction)
    {
        if (attackCooldown > 0) return;

        var projectile = Instantiate(ProjectilePrefab.gameObject, transform.position, transform.rotation);
        projectile.GetComponent<Projectile2D>().RB.velocity = Direction.normalized * ProjectileForce;
        attackCooldown = AttackSpeed;
    }
    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }
}
