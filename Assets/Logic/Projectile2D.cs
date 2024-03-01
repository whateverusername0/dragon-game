using UnityEngine;

/// <summary>
///     A projectile is supposed to deal damage to whatever.
///     Made specifically to work with <see cref="CreatureBase"/>.
/// </summary>
public class Projectile2D : MonoBehaviour
{
    public Rigidbody2D RB;
    public Collider2D Bounds;

    public float Damage = 0;

    /// <summary>
    /// Projectile collision event processor.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == (int)Global.Layers.Creature)
        {
            collider.gameObject.GetComponent<Creature2D>().TakeHit(Damage);
            Disappear();
        }
    }

    private void Disappear()
    {
        //this.enabled = false;
        Destroy(gameObject);
    }
}
