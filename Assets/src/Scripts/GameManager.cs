using UnityEngine;
using Utilities.Events;

/// <summary>
///     Праотец праотцов, должен быть в каждой сцене в одном энтити. Или в DoNotDestroyOnLoad, как угодно.
/// </summary>
public class GameManager : MonoSingleton<GameManager>
{
    public EventBus<BaseEventArgs> EventBus { get; private set; }

    public void Awake()
    {
        EventBus = new EventBus<BaseEventArgs, GameObject>();
    }
}