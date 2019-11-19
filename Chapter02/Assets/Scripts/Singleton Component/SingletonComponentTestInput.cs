using UnityEngine;

public class SingletonComponentTestInput : MonoBehaviour {
    [SerializeField] private GameObject _enemyPrefab;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            EnemyManagerSingletonComponent.Instance.CreateEnemy(_enemyPrefab);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            EnemyManagerSingletonComponent.Instance.KillAll();
        }
    }
}