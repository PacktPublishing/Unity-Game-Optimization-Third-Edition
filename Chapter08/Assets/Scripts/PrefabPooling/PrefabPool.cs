using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PoolablePrefabData {
    public GameObject go;
    public IPoolableComponent[] poolableComponents;
}

public class PrefabPool  {
    Dictionary<GameObject, PoolablePrefabData> _activeList = new Dictionary<GameObject, PoolablePrefabData>();
    Queue<PoolablePrefabData> _inactiveList = new Queue<PoolablePrefabData>();

    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation) {
        PoolablePrefabData data;

        if (_inactiveList.Count > 0) {
            data = _inactiveList.Dequeue();
        } else {
            // instantiate a new object
            GameObject newGO = GameObject.Instantiate(prefab, position, rotation) as GameObject;
            data = new PoolablePrefabData();
            data.go = newGO;
            data.poolableComponents = newGO.GetComponents<IPoolableComponent>();
        }

        data.go.SetActive(true);
        data.go.transform.position = position;
        data.go.transform.rotation = rotation;

        for (int i = 0; i < data.poolableComponents.Length; ++i) {
            data.poolableComponents[i].Spawned();
        }
        _activeList.Add(data.go, data);

        return data.go;
    }

    public bool Despawn(GameObject objToDespawn) {
        if (!_activeList.ContainsKey(objToDespawn)) {
            Debug.LogError("This Object is not managed by this object pool!");
            return false;
        }

        PoolablePrefabData data = _activeList[objToDespawn];

        for (int i = 0; i < data.poolableComponents.Length; ++i) {
            data.poolableComponents[i].Despawned();
        }

        data.go.SetActive(false);
        _activeList.Remove(objToDespawn);
        _inactiveList.Enqueue(data);
        return true;
    }
}
