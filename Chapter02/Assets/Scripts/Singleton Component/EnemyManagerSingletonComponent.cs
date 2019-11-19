using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerSingletonComponent : SingletonComponent<EnemyManagerSingletonComponent> {
    public static EnemyManagerSingletonComponent Instance
    {
        get { return ((EnemyManagerSingletonComponent)_Instance); }
        set { _Instance = value; }
    }

    static List<GameObject> _enemies = new List<GameObject>();

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