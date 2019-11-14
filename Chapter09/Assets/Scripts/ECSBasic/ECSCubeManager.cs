using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ECSBase
{
    public class ECSCubeManager : MonoBehaviour
    {

        #region COMMON_GAME_MANAGER_DATA
        public float cubeSpacing = 0.1f;
        public int width = 10;
        public int height = 10;

        public GameObject cubePrefab;
        #endregion


        // Use this for initialization
        void Start()
        {
            SpawnCubes();

        }

        private void SpawnCubes()
        {
            Debug.Log(String.Format("Spawning {0} cubes", (width / cubeSpacing) * (height / cubeSpacing)));
            Vector3 position = new Vector3();
            while (position.x < width)
            {
                while (position.y < height)
                {
                    var newCube = GameObject.Instantiate(cubePrefab);
                    newCube.transform.position = position;
                    newCube.GetComponent<Rotator>().speed = UnityEngine.Random.Range(25.0f, 50.0f);
                    position = new Vector3(position.x, position.y + cubeSpacing, 0f);
                }
                position = new Vector3(position.x + cubeSpacing, 0f, 0f);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}