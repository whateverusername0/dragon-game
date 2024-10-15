using Utilities.Events;

public class GameManager : MonoSingleton<GameManager>
{
    public EventBus<BaseEventArgs> EventBus { get; private set; }

    public void Awake()
    {
        EventBus = new EventBus<BaseEventArgs>();
    }
}