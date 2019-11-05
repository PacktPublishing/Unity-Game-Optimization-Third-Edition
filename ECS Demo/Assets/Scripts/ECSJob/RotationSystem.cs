using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;

namespace ECSJob
{
    public class RotationSystem : JobComponentSystem
    {
        [BurstCompile]
        public struct RotatorJob : IJobForEach<Rotation, RotationSpeed>
        {

            [ReadOnly]
            public float deltaTime;

            public void Execute(ref Rotation rotation, [ReadOnly] ref RotationSpeed rotationSpeed)
            {
                rotation.Value = math.mul(math.normalize(rotation.Value), quaternion.AxisAngle(math.up(), rotationSpeed.Value * deltaTime));
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            RotatorJob rotatorJob = new RotatorJob()
            {
                deltaTime = Time.deltaTime
            };

            return rotatorJob.Schedule(this, inputDeps);
        }
    }
}