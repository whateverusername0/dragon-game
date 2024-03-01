using UnityEngine;

public class Creature2D : MonoBehaviour
{
    public Rigidbody2D RB;
    // useless unless rb is kinematic
    public Global.PhysicalProperties PhysicalProperties;

    public float HP = 100;
    public float MaxHP = 100;

    public float IncinvibilityFrames = 0f;
    private float invincibilityCooldown = 0f;

    public string CreatureName = "";
    public TextMesh TextMesh;

    private void Update()
    {
        if (invincibilityCooldown > 0f)
            invincibilityCooldown -= Time.deltaTime;

        if (TextMesh != null)
            TextMesh.text = $"{CreatureName} {HP}HP ({MaxHP})";
    }

    public virtual void TakeHit(float Damage)
    {
        if (invincibilityCooldown > 0) return;
        invincibilityCooldown = IncinvibilityFrames;

        HP -= Damage;
        if (HP > MaxHP) HP = MaxHP;
        if (HP <= 0) Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
