using UnityEngine;
using UnityEngine.EventSystems;
using Utilities.Events;

public class ClickDetector : MonoBehaviour,
    IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{
    private static GameManager GM;

    public void Start()
    {
        GM = GameManager.Instance;
    }

    public void OnPointerClick(PointerEventData eventData)
        => GM.EventBus.Raise(new PointerClickEvent(gameObject, eventData));

    public void OnPointerDown(PointerEventData eventData)
        => GM.EventBus.Raise(new PointerDownEvent(gameObject, eventData));

    public void OnPointerEnter(PointerEventData eventData)
        => GM.EventBus.Raise(new PointerEnterEvent(gameObject, eventData));

    public void OnPointerExit(PointerEventData eventData)
        => GM.EventBus.Raise(new PointerExitEvent(gameObject, eventData));

    public void OnPointerUp(PointerEventData eventData)
        => GM.EventBus.Raise(new PointerUpEvent(gameObject, eventData));
}

#region Events

// PointerDownEvent PointerUpEvent PointerEnterEvent PointerExitEvent PointerClickEvent
// BeginDragEvent DragEvent ExitDragEvent

public sealed class PointerDownEvent : EntityEventArgs
{
    public readonly PointerEventData PointerEventData;

    public PointerDownEvent(GameObject gameObject, PointerEventData ped) : base(gameObject)
    {
        PointerEventData = ped;
    }
}

public sealed class PointerUpEvent : EntityEventArgs
{
    public readonly PointerEventData PointerEventData;

    public PointerUpEvent(GameObject gameObject, PointerEventData ped) : base(gameObject)
    {
        PointerEventData = ped;
    }
}

public sealed class PointerEnterEvent : EntityEventArgs
{
    public readonly PointerEventData PointerEventData;

    public PointerEnterEvent(GameObject gameObject, PointerEventData ped) : base(gameObject)
    {
        PointerEventData = ped;
    }
}

public sealed class PointerExitEvent : EntityEventArgs
{
    public readonly PointerEventData PointerEventData;

    public PointerExitEvent(GameObject gameObject, PointerEventData ped) : base(gameObject)
    {
        PointerEventData = ped;
    }
}

public sealed class PointerClickEvent : EntityEventArgs
{
    public readonly PointerEventData PointerEventData;

    public PointerClickEvent(GameObject gameObject, PointerEventData ped) : base(gameObject)
    {
        PointerEventData = ped;
    }
}

#endregion