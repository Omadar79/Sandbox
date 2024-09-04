using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.VisualScripting;
using UnityEngine;

namespace CatHotelStudios.ECS
{

    [UpdateBefore(typeof(GridSystem))]
    public partial struct GridSystem : ISystem
    {
        private EntityManager _entityManager;
        private int _gridWidth;
        private int _gridHeight;
        private Entity _configEntity;

      
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<ConfigComponent>();
            _gridHeight = 25;
            _gridWidth = 25;
        }


        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false; //run update only once

            _entityManager = state.EntityManager;
            ConfigComponent config = SystemAPI.GetSingleton<ConfigComponent>();

            float particleWidth = config.ParticleWidth;
            var query = SystemAPI.QueryBuilder().WithAll<GridComponent>().Build();
            var queryMask = query.GetEntityQueryMask();

            var ecb = new EntityCommandBuffer(Allocator.Temp);
            var gridCellsArray = new NativeArray<Entity>(_gridHeight * _gridWidth, Allocator.Temp);
            ecb.Instantiate(config.ParticlePrefab, gridCellsArray);

            int arrayIndex = 0;
            foreach (var cell in gridCellsArray)
            {
                int yVal = arrayIndex % _gridWidth;
                int xVal = (arrayIndex / _gridWidth);

                ecb.SetComponentForLinkedEntityGroup(cell, queryMask, new LocalTransform
                {
                    Position = new float3((particleWidth * xVal), (particleWidth * yVal), 10f),
                    Scale = particleWidth,
                    Rotation = quaternion.identity
                });
                //Debug.Log("Pos: " + xVal + "/" + yVal);
                arrayIndex++;
            }

            ecb.Playback(_entityManager);

        }

        public void OnDestroy(ref SystemState state)
        {
            //_gridArray.Dispose();
        }
    }
//}

   
}