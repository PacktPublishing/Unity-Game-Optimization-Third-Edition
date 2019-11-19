using UnityEngine;

public class TestObject : IPoolableObject {
    public void New() {
        Debug.Log("New TestObject created!");
    }
    public void Respawn() {
        Debug.Log("A TestObject has been respawned!");
    }
}