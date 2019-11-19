using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreatedListenerComponent : MonoBehaviour {

	void Start () {
		MessagingSystem.Instance.AttachListener(typeof(EnemyCreatedMessage), HandleEnemyCreated);
	}
	
	bool HandleEnemyCreated(Message msg) {
        EnemyCreatedMessage castMsg = msg as EnemyCreatedMessage;
        Debug.Log(string.Format("A new enemy was created! {0}", castMsg.enemyName));
        return true;
    }

    void OnDestroy() {
        if (MessagingSystem.IsAlive) {
            MessagingSystem.Instance.DetachListener(typeof(EnemyCreatedMessage), this.HandleEnemyCreated);
        }
    }
}
