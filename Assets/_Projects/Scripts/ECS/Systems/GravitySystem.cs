using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace CatHotelStudios.ECS
{
    
    
    public partial struct GravitySystem : ISystem
    {
        private EntityManager _entityManager;
        
        private Entity _configEntity;
        private Entity _particlePrefab;
        
        //private ConfigComponent _configComponent;

        private float _dropRateMultiplier;
        private float _cellSizeModifier;
        
  
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<ConfigComponent>();
            _dropRateMultiplier = 1f;
            _cellSizeModifier = .2f;
        }


        public void OnUpdate(ref SystemState state)
        {
            _entityManager = state.EntityManager;
            
            ConfigComponent config = SystemAPI.GetSingleton<ConfigComponent>();

            _cellSizeModifier = config.ParticleWidth;
            _dropRateMultiplier = config.DropRateMultiplier;
            
     
            // foreach (var (transform,gridCell) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<GridComponent>>().WithAll<GridComponent>())
            // {
            //    var loc = new float3(
            //        gridCell.ValueRO.GridPosition.x * _cellSizeModifier,
            //        gridCell.ValueRO.GridPosition.y * _cellSizeModifier
            //        , 10f);
            //
            //    transform.ValueRW.Position = loc;
            //     
            //     Debug.Log("Pos: " + loc.x + "/" + loc.y);
            // }
            //
            //
            
        }
    }
}