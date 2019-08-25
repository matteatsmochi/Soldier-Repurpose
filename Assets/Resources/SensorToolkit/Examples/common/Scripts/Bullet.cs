using UnityEngine;
using System.Collections;

namespace SensorToolkit.Example
{
    [RequireComponent(typeof(RaySensor))]
    public class Bullet : MonoBehaviour
    {
        public float Speed;
        public float damageMin;
        public float damageMax;
        public float MaxAge;
        public float ImpactForce;
        public GameObject HitEffect;
        public int fromIndex;

        float age;
        RaySensor raySensor;

        void Start()
        {
            raySensor = GetComponent<RaySensor>();
            raySensor.SensorUpdateMode = RaySensor.UpdateMode.Manual;
            age = 0;
        }

        void Update()
        {
            age += Time.deltaTime;
            if (age > MaxAge)
            {
                explode(Vector3.up);
                return;
            }

            var deltaPos = transform.forward * Speed * Time.deltaTime;
            raySensor.Length = deltaPos.magnitude;
            raySensor.Pulse();

            transform.position += deltaPos;
        }

        public void HitObject(GameObject g)
        {
            var health = g.GetComponent<newHealth>();
            var damage = Random.Range(damageMin, damageMax);

            if (health != null)
            {
                health.Impact(damage, transform.forward * ImpactForce, raySensor.GetRayHit(g).point, fromIndex);
            }
            explode(raySensor.GetRayHit(g).normal);
        }

        public void HitWall()
        {
            explode(raySensor.ObstructionRayHit.normal);
        }

        void explode(Vector3 direction)
        {
            if (HitEffect != null)
            {
                Instantiate(HitEffect, transform.position, Quaternion.LookRotation(direction));
            }
            Destroy(gameObject);
        }
    }
}