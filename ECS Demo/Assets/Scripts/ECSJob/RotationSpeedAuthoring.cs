using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;
using Unity.Mathematics;

namespace ECSJob
{

    // ReSharper disable once InconsistentNaming
    [Serializable]
    public struct RotationSpeed : IComponentData
    {
        public float Value;
    }

    [RequiresEntityConversion]
    public class RotationSpeedAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {

        public float rotationSpeed = 35f;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new RotationSpeed { Value = math.radians(rotationSpeed) }; // Convert to speed in radians
            dstManager.AddComponentData(entity, data);
        }
    }
}
