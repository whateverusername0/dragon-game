

public class Global : MonoSingleton<Global>
{
    public Controls Input;

    private new void Awake()
    {
        base.Awake();
        Input = new Controls();
    }

    public enum Layers
    {
        Default = 0,
        TransparentFX = 1,
        IgnoreRaycast = 2,
        Water = 4,
        UI = 5,
        Terrain = 10,
        World = 11,
        Creature = 12,
        Projectile = 13,
    }

    public struct PhysicalProperties
    {
        public float Mass { get; set; }
        public float LinearDrag { get; set; }
        public float AngularDrag { get; set; }
    }
}