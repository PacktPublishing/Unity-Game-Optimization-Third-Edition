using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;


namespace JobSystem
{

    public struct RotatorJob : IJobParallelForTransform
    {

        [ReadOnly]
        public NativeList<float> speeds;

        [ReadOnly]
        public float deltaTime;

        public void Execute(int index, TransformAccess transform)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            currentRotation.y += speeds[index] * deltaTime;
            transform.rotation = Quaternion.Euler(currentRotation);
        }
    }
}