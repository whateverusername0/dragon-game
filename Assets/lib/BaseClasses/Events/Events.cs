using UnityEngine;

namespace Utilities.Events
{
    /// <summary>
    ///     Используется если вы хотите создать какой-то новый ивент без лишнего кала
    /// </summary>
    public class BaseEventArgs { }

    public class EntityEventArgs : BaseEventArgs
    {
        /// <summary>
        ///     Entity
        /// </summary>
        public GameObject? GameObject;

        public EntityEventArgs(GameObject gameObject)
        {
            GameObject = gameObject;
        }
    }

    public class TargetedEntityEventArgs : EntityEventArgs
    {
        public GameObject? Target;

        public TargetedEntityEventArgs(GameObject gameObject, GameObject target) : base(gameObject)
        {
            Target = target;
        }
    }

    public class CancellableEntityEventArgs : EntityEventArgs
    {
        public bool Cancelled { get; set; } = false;

        public CancellableEntityEventArgs(GameObject gameObject) : base(gameObject) { }
    }

    public class HandledEntityEventArgs : EntityEventArgs
    {
        public bool Handled { get; set; } = false;

        public HandledEntityEventArgs(GameObject gameObject) : base(gameObject) { }
    }
}