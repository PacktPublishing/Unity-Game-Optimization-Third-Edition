using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerWithMessagesComponent : MonoBehaviour {

    private List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] private GameObject _enemyPrefab;

    void Start() {
        MessagingSystem.Instance.AttachListener(typeof(CreateEnemyMessage), this.HandleCreateEnemy);
        MessagingSystem.Instance.AttachListener(typeof(KillAllEnemiesMessage), this.HandleKillAllEnemies);
    }

    bool HandleCreateEnemy(Message msg) {
        CreateEnemyMessage castMsg = msg as CreateEnemyMessage;
        string[] names = { "Tom", "Dick", "Harry" };
        GameObject enemy = GameObject.Instantiate(_enemyPrefab, 5.0f * Random.insideUnitSphere, Quaternion.identity);
        string enemyName = names[Random.Range(0, names.Length)];
        enemy.gameObject.name = enemyName;
        _enemies.Add(enemy);
        MessagingSystem.Instance.QueueMessage(new EnemyCreatedMessage(enemy, enemyName));
        return true;
    }

    bool HandleKillAllEnemies(Message msg) {
        KillAll();
        return true;
    }

    public void AddEnemy(GameObject enemy) {
        if (_enemies.Contains(enemy)) {
            return;
        }
        _enemies.Add(enemy);
    }

    public void KillAll() {
        foreach (GameObject enemy in _enemies) {
            GameObject.Destroy(enemy);
        }
    }

    void OnDestroy() {
        if (MessagingSystem.IsAlive) {
            MessagingSystem.Instance.DetachListener(typeof(EnemyCreatedMessage), this.HandleCreateEnemy);
        }
    }
}
