using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReferencesTestInput : MonoBehaviour {

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private EnemyManagerComponent _enemyManager;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            _enemyManager.CreateEnemy(_enemyPrefab);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            _enemyManager.KillAll();
        }
    }
}
