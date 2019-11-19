using UnityEngine;

public class SingletonComponent<T> : MonoBehaviour where T : SingletonComponent<T> {
    private static T __Instance;
    private bool _alive = true;

    protected static SingletonComponent<T> _Instance
    {
        get
        {
            if (!__Instance) {
                T[] managers = GameObject.FindObjectsOfType(typeof(T)) as T[];
                if (managers != null) {
                    if (managers.Length == 1) {
                        __Instance = managers[0];
                        return __Instance;
                    } else if (managers.Length > 1) {
                        Debug.LogError("You have more than one " + 
                                        typeof(T).Name + 
                                        " in the Scene. You only need " + 
                                        "one - it's a singleton!");
                        for (int i = 0; i < managers.Length; ++i) {
                            T manager = managers[i];
                            Destroy(manager.gameObject);
                        }
                    }
                }
                GameObject go = new GameObject(typeof(T).Name, typeof(T));
                __Instance = go.GetComponent<T>();
                DontDestroyOnLoad(__Instance.gameObject);
            }
            return __Instance;
        }
        set
        {
            __Instance = value as T;
        }
    }

    void OnDestroy() {
        _alive = false;
    }

    void OnApplicationQuit() {
        _alive = false;
    }

    public static bool IsAlive
    {
        get
        {
            if (__Instance == null)
                return false;
            return __Instance._alive;
        }
    }
}