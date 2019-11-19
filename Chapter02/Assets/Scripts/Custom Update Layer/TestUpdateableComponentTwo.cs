using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class TestUpdateableComponentTwo : UpdateableComponent {

    private Stopwatch _timer = new Stopwatch();

    protected override void Initialize() {
        base.Initialize();
        _timer.Start();
    }

    public override void OnUpdate(float dt) {
        base.OnUpdate(dt);

        if (_timer.Elapsed.TotalSeconds > 2.0) {
            UnityEngine.Debug.Log("Updateable Component Two (every 2 seconds)");
            _timer.Reset();
            _timer.Start();
        }
    }
}
