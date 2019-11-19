using UnityEngine;
using System.Collections.Generic;

class EnemyManagerComponent : MonoBehaviour {
    List<GameObject> _enemies = new List<GameObject>();

    public void AddEnemy(GameObject enemy) {
        if (!_enemies.Contains(enemy)) {
            _enemies.Add(enemy);
        }
    }

    public void CreateEnemy(GameObject prefab) {
        string[] names = { "Tom", "Dick", "Harry" };
        GameObject enemy = GameObject.Instantiate(prefab, 5.0f * Random.insideUnitSphere, Quaternion.identity);
        enemy.gameObject.name = names[Random.Range(0, names.Length)];
        _enemies.Add(enemy);
    }

    public void KillAll() {
        for (int i = 0; i < _enemies.Count; ++i) {
            GameObject.Destroy(_enemies[i]);
        }
        _enemies.Clear();
    }
}