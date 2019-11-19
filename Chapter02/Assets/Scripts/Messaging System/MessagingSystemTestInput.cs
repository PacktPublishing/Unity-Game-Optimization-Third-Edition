using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagingSystemTestInput : MonoBehaviour {

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            MessagingSystem.Instance.QueueMessage(new CreateEnemyMessage());            
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            MessagingSystem.Instance.QueueMessage(new KillAllEnemiesMessage());
        }
    }
}
