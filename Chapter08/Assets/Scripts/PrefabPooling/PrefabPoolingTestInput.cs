using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPoolingTestInput : MonoBehaviour {
    [SerializeField] GameObject _orcPrefab;
    [SerializeField] GameObject _trollPrefab;
    [SerializeField] GameObject _ogrePrefab;
    [SerializeField] GameObject _dragonPrefab;

    List<GameObject> _orcs = new List<GameObject>();
    List<GameObject> _trolls = new List<GameObject>();
    List<GameObject> _ogres = new List<GameObject>();
    List<GameObject> _dragons = new List<GameObject>();

    void Start() {
        PrefabPoolingSystem.Prespawn(_orcPrefab, 11);
        PrefabPoolingSystem.Prespawn(_trollPrefab, 8);
        PrefabPoolingSystem.Prespawn(_ogrePrefab, 5);
        PrefabPoolingSystem.Prespawn(_dragonPrefab, 1);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { SpawnObject(_orcPrefab, _orcs); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { SpawnObject(_trollPrefab, _trolls); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { SpawnObject(_ogrePrefab, _ogres); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { SpawnObject(_dragonPrefab, _dragons); }
        if (Input.GetKeyDown(KeyCode.Q)) { DespawnRandomObject(_orcs); }
        if (Input.GetKeyDown(KeyCode.W)) { DespawnRandomObject(_trolls); }
        if (Input.GetKeyDown(KeyCode.E)) { DespawnRandomObject(_ogres); }
        if (Input.GetKeyDown(KeyCode.R)) { DespawnRandomObject(_dragons); }
    }

    void SpawnObject(GameObject prefab, List<GameObject> list) {
        GameObject obj = PrefabPoolingSystem.Spawn(prefab,
                                                    5.0f * Random.insideUnitSphere,
                                                    Quaternion.identity);
        list.Add(obj);
    }

    void DespawnRandomObject(List<GameObject> list) {
        if (list.Count == 0) {
            // Nothing to despawn
            return;
        }

        int i = Random.Range(0, list.Count);
        PrefabPoolingSystem.Despawn(list[i]);
        list.RemoveAt(i);
    }
}