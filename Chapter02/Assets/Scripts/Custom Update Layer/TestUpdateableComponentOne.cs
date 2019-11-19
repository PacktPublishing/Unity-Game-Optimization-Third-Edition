using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class TestUpdateableComponentOne : UpdateableComponent {

    private Stopwatch _timer = new Stopwatch();

    protected override void Initialize() {
        base.Initialize();
        _timer.Start();
    }

    public override void OnUpdate(float dt) {
        base.OnUpdate(dt);

        if (_timer.Elapsed.TotalSeconds > 1.0) {
            UnityEngine.Debug.Log("Updateable Component One (every second)");
            _timer.Reset();
            _timer.Start();
        }
    }
}
