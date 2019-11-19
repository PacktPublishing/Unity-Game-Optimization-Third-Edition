using System.Collections.Generic;
using UnityEngine;

public static class StaticEnemyManager {
    private static List<Enemy> _enemies;

    static StaticEnemyManager() {
        _enemies = new List<Enemy>();
    }

    public static void CreateEnemy(GameObject prefab) {
        string[] names = { "Tom", "Dick", "Harry" };
        GameObject enemy = GameObject.Instantiate(prefab, 5.0f * Random.insideUnitSphere, Quaternion.identity);
        Enemy enemyComp = enemy.GetComponent<Enemy>();
        enemy.gameObject.name = names[Random.Range(0, names.Length)];
        _enemies.Add(enemyComp);
    }

    public static void KillAll() {
        for (int i = 0; i < _enemies.Count; ++i) {
            _enemies[i].Die();
            GameObject.Destroy(_enemies[i].gameObject);
        }
        _enemies.Clear();
    }
}