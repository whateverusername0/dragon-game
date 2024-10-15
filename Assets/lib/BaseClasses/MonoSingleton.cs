using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    public static T Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(Instance);
        Instance = (T)this;
        DontDestroyOnLoad(this);
    }
}
