using UnityEngine;

public class StaticEnemyManagerCompanionComponent : MonoBehaviour {
    [SerializeField] private GameObject _enemyPrefab;

    public void CreateEnemy() {
        StaticEnemyManager.CreateEnemy(_enemyPrefab);
    }
}