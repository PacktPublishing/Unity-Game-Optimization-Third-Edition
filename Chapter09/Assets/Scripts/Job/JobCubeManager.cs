using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.Jobs;

namespace JobSystem
{
    public class JobCubeManager : MonoBehaviour
    {

        #region COMMON_GAME_MANAGER_DATA
        public float cubeSpacing = 0.1f;
        public int width = 10;
        public int height = 10;

        public GameObject cubePrefab;
        #endregion

        TransformAccessArray transformAccessArray;
        Unity.Jobs.JobHandle jobHandle;
        NativeList<float> speeds;

        private void OnDisable()
        {
            jobHandle.Complete();
            transformAccessArray.Dispose();
            speeds.Dispose();
        }

        // Use this for initialization
        void Start()
        {
            transformAccessArray = new TransformAccessArray(0, -1);
            speeds = new NativeList<float>(1, Allocator.Persistent);
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
                    var newCube = Instantiate(cubePrefab);
                    newCube.transform.position = position;
                    Destroy(newCube.GetComponent<Classic.Rotator>());
                    position = new Vector3(position.x, position.y + cubeSpacing, 0f);
                    transformAccessArray.Add(newCube.transform);
                    speeds.Add(UnityEngine.Random.Range(25.0f, 50.0f));
                }
                position = new Vector3(position.x + cubeSpacing, 0f, 0f);
            }

        }

        // Update is called once per frame
        void Update()
        {
            jobHandle.Complete();

            if (jobHandle.IsCompleted)
            {
                var rotatorJob = new RotatorJob()
                {
                    deltaTime = Time.deltaTime,
                    speeds = speeds
                };

                jobHandle = rotatorJob.Schedule(transformAccessArray);
                Unity.Jobs.JobHandle.ScheduleBatchedJobs();
            }

        }
    }
}