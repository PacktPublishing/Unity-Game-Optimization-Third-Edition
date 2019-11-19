using UnityEngine;
using System.Collections;

public class CustomTimerTest : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			int numTests = 1000;
			
			using (new CustomTimer("Controlled Test", numTests)) {
				for(int i = 0; i < numTests; ++i) {
					TestFunction();
				}
			}
		}
	}

	void TestFunction() {
		// count up to 100000, for no good reason
		for(int i = 0; i < 100000; ++i) {
		}
	}

}
