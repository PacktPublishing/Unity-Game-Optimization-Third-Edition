using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateableComponent : MonoBehaviour, IUpdateable {

    void Start() {
        GameLogic.Instance.RegisterUpdateableObject(this);
        Initialize();
    }

    void OnDestroy() {
        if (GameLogic.IsAlive) {
            GameLogic.Instance.DeregisterUpdateableObject(this);
        }
    }

    public virtual void OnUpdate(float dt) { }
    protected virtual void Initialize() {
        // derived classes should override this method for initialization code, and NOT reimplement Start()
    }
}
