using System.Collections.Generic;
using UnityEngine;
using Utilities.Events;

namespace Content.Damage
{
    public class Damageable : MonoBehaviour
    {
        private static GameManager GM;

        [SerializeField] public float TotalDamage { get; set; } = 0f;

        /// <summary>
        ///     Считай это предел после которого обьект умирает.
        /// </summary>
        [SerializeField] public float Threshold { get; private set; } = 100f;

        /// <summary>
        ///     Нужно ли удалять обьект после достижения предела?
        /// </summary>
        [SerializeField] public bool DeleteOnThreshold { get; private set; } = true;

        /// <summary>
        ///     Если поле не null то он вызовет этот ивент.
        /// </summary>
        [SerializeField] public BaseEventArgs? EventOnThreshold { get; private set; } = null;

        public void Start()
        {
            GM = GameManager.Instance;

            GM.EventBus.SubscribeTo<BeforeTakeDamageEvent>(BeforeTakeDamage);
            GM.EventBus.SubscribeTo<TakeDamageEvent>(OnTakeDamage);
            GM.EventBus.SubscribeTo<AfterTakeDamageEvent>(AfterTakeDamage);
        }

        #region Events

        private void BeforeTakeDamage(ref BeforeTakeDamageEvent args)
        {
            var dmg = args.GameObject.GetComponent<Damageable>();

            // TODO check armor
        }

        private void OnTakeDamage(ref TakeDamageEvent args)
        {
            var dmg = args.GameObject.GetComponent<Damageable>();

            foreach (var k in args.Damage.Values)
                dmg.TotalDamage += k;

            // add stuff here
        }

        private void AfterTakeDamage(ref AfterTakeDamageEvent args)
        {
            var dmg = args.GameObject.GetComponent<Damageable>();

            // TODO visual effects

            if (dmg.TotalDamage >= dmg.Threshold)
                Die(args.GameObject, dmg);
        }

        private void Die(GameObject target, Damageable comp)
        {
            // add more stuff here

            if (comp.EventOnThreshold != null)
                GM.EventBus.Raise(comp.EventOnThreshold);

            if (comp.DeleteOnThreshold)
                Destroy(target);
        }

        #endregion

        #region Public API

        public bool TakeDamage(GameObject entity, Dictionary<DamageType, float> damage)
        {
            if (entity == null
            || !entity.TryGetComponent<Damageable>(out _))
                return false;

            // damage is being edited in certain events so i'll just use it over and over
            GM.EventBus.Raise(new BeforeTakeDamageEvent(entity, damage));
            GM.EventBus.Raise(new TakeDamageEvent(entity, damage));
            GM.EventBus.Raise(new AfterTakeDamageEvent(entity, damage));

            return true;
        }

        #endregion
    }

    public enum DamageType
    {
        Basic = 0,
        // todo add elemental
    }

    #region Events

    public class TakeDamageEvent : HandledEntityEventArgs
    {
        public Dictionary<DamageType, float> Damage = new();

        public TakeDamageEvent(GameObject target) : base(target) { }
        public TakeDamageEvent(GameObject target, Dictionary<DamageType, float> damage) : base(target)
        {
            Damage = damage;
        }
    }
    /// <summary>
    ///     Raised before taking damage in case you want to apply armor of some sort.
    /// </summary>
    public sealed class BeforeTakeDamageEvent : TakeDamageEvent
    {
        public BeforeTakeDamageEvent(GameObject target) : base(target) { }
        public BeforeTakeDamageEvent(GameObject target, Dictionary<DamageType, float> damage) : base(target, damage) { }
    }
    /// <summary>
    ///     Raised for visual effects and other processing.
    /// </summary>
    public sealed class AfterTakeDamageEvent : TakeDamageEvent
    {
        public AfterTakeDamageEvent(GameObject target) : base(target) { }
        public AfterTakeDamageEvent(GameObject target, Dictionary<DamageType, float> damage) : base(target, damage) { }
    }

    #endregion
}