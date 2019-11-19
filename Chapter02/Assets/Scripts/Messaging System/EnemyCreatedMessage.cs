using UnityEngine;

public class EnemyCreatedMessage : Message {

    public readonly GameObject enemyObject;
    public readonly string enemyName;

    public EnemyCreatedMessage(GameObject enemyObject, string enemyName) {
        this.enemyObject = enemyObject;
        this.enemyName = enemyName;
    }
}
