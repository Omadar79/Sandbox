using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace CatHotelStudios.ECS
{
    public class ConfigAuthoring : MonoBehaviour
    {
        public Vector3 gravityDirection = new Vector3(0, -1.0F, 0);
        public GameObject particlePrefab;
        public float spawnDelay = 0.5f;
        public float dropRateMultiplier = 0.5f;
        public float particlePrefabWidth = 0.5f;

        private void OnValidate()
        {
            //ReAdjustParticleWidth();
        }

        private void Awake()
        {
            //ReAdjustParticleWidth();
        }
        
        private void ReAdjustParticleWidth()
        {
            //particlePrefabWidth = particlePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        }
        
        private class ConfigBaker : Baker<ConfigAuthoring>
        {
            public override void Bake(ConfigAuthoring authoring)
            {
                Entity entity = GetEntity( TransformUsageFlags.None);
                
                AddComponent(entity, new ConfigComponent
                {
                    GravityDirection = authoring.gravityDirection ,
                    ParticlePrefab = GetEntity(authoring.particlePrefab, TransformUsageFlags.Dynamic),
                    SpawnDelay = authoring.spawnDelay,
                    DropRateMultiplier = authoring.dropRateMultiplier,
                    ParticleWidth = authoring.particlePrefabWidth
                });
            }
        }
    }
    
    public struct ConfigComponent : IComponentData
    {
        public float3 GravityDirection;
        public float SpawnDelay;
        public float DropRateMultiplier;
        public Entity ParticlePrefab;
        public float ParticleWidth;
    }
}