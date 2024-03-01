using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    public void Awake()
    {
        if (Instance != null && Instance != this)
            DestroyImmediate(Instance);
        Instance = this as T;
    }
}
