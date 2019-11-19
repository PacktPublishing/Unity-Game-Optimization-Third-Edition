using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTestInput : MonoBehaviour {

    private ObjectPool<TestObject> _objectPool = new ObjectPool<TestObject>(5);

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            _objectPool.Spawn();
            PrintObjectCount();
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            _objectPool.Reset();
            PrintObjectCount();
        }
    }
    
    private void PrintObjectCount() {
        Debug.Log(string.Format("Pool contains {0} objects. {1} active", _objectPool.Count, _objectPool.NumActive));
    }
}
