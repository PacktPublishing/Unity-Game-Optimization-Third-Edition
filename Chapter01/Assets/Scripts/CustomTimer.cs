using System;
using System.Diagnostics;

public class CustomTimer : IDisposable {
    private string _timerName;
    private int _numTests;
    private Stopwatch _watch;

    // give the timer a name, and a count of the number of tests we're running
    public CustomTimer(string timerName, int numTests) {
        _timerName = timerName;
        _numTests = numTests;
        if (_numTests <= 0) {
            _numTests = 1;
        }
        _watch = Stopwatch.StartNew();
    }

    // automatically called when the 'using()' block ends
    public void Dispose() {
        _watch.Stop();
        float ms = _watch.ElapsedMilliseconds;
        UnityEngine.Debug.Log(string.Format("{0} finished: {1:0.00} " +
            "milliseconds total, {2:0.000000} milliseconds per-test " +
            "for {3} tests", _timerName, ms, ms / _numTests, _numTests));
    }
}