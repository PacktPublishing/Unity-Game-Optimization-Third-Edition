using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace ECSBase
{
    public class Rotator : MonoBehaviour
    {
        public float speed;
    }

    class RotatorSystem : ComponentSystem
    {

        protected override void OnUpdate()
        {
            float deltaTime = Time.deltaTime;

            Entities.WithAll<Rotator, Transform>().ForEach(
                (Entity e, Rotator rotator, Transform transform) =>
                {
                    float speed = rotator.speed;
                    transform.Rotate(0f, speed * deltaTime, 0f);
                });
        }
    }
}