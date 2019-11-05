using System;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace ECSJob
{
    public class ECSJobManager : MonoBehaviour
    {

        #region COMMON_GAME_MANAGER_DATA
        public float cubeSpacing = 0.1f;
        public int width = 10;
        public int height = 10;

        public GameObject cubePrefab;
        #endregion

        EntityManager entityManager;


        // Use this for initialization
        void Start()
        {
            entityManager = World.Active.EntityManager;
            SpawnCubes();
        }

        private void SpawnCubes()
        {
            int amount = Mathf.FloorToInt(width / cubeSpacing) * Mathf.FloorToInt(height / cubeSpacing);
            Debug.Log(String.Format("Spawning {0} cubes", amount));

            Vector3 position = new Vector3();

            var entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(cubePrefab, World.Active);
           

            while (position.x < width)
            {
                while (position.y < height)
                {
                    var instance = entityManager.Instantiate(entityPrefab);

                    position = new Vector3(position.x, position.y + cubeSpacing, 0f);
                    entityManager.SetComponentData(instance, new Translation() { Value = position });
                    entityManager.SetComponentData(instance, new RotationSpeed() { Value = math.radians(UnityEngine.Random.Range(25.0f, 50.0f)) });
                }
                position = new Vector3(position.x + cubeSpacing, 0f, 0f);
            }

        }


    }
}