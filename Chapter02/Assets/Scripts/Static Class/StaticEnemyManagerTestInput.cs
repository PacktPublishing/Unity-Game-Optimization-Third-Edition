using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyManagerTestInput : MonoBehaviour {
     
    [SerializeField] private StaticEnemyManagerCompanionComponent _enemyCreatorCompanion;

    void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
            _enemyCreatorCompanion.CreateEnemy();
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            StaticEnemyManager.KillAll();
        }
	}
}
