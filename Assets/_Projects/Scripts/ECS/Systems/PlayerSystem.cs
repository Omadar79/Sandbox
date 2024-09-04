
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace CatHotelStudios.ECS
{
    [UpdateBefore(typeof(GridSystem))]
    public partial struct PlayerSystem : ISystem
    {
        private EntityManager _entityManager;
        
        private Entity _inputEntity;
        private Entity _mousePointerEntity;
        private Entity _configEntity;
        private Entity _particlePrefab;
        
        private InputComponent _inputComponent;
        private ConfigComponent _configComponent;
        private bool _isMouseDown;
        private int _sandCount;
        private float _spawnCounter;
        private float _spawnTimer;

        //private MousePointerComponent _mousePointerComponent;
        
     
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<ConfigComponent>();
            state.RequireForUpdate<InputComponent>();
            state.RequireForUpdate<MousePointerComponent>();
            _sandCount = 0;
            _spawnTimer = 0;
        }

      
        public void OnUpdate(ref SystemState state)
        {
            _entityManager = state.EntityManager;
            
            
            _configEntity = SystemAPI.GetSingletonEntity<ConfigComponent>();
            _inputEntity =  SystemAPI.GetSingletonEntity<InputComponent>();


            _configComponent = _entityManager.GetComponentData<ConfigComponent>(_configEntity);
            _inputComponent = _entityManager.GetComponentData<InputComponent>(_inputEntity);

            _spawnTimer = _configComponent.SpawnDelay;
           
 
            
            MoveMouse(ref state);
            SpawnSand(ref state);
        }

        
   
        public void OnDestroy(ref SystemState state)
        {

        }

        private void MoveMouse(ref SystemState state)
        { 
     
             foreach (var transform in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<MousePointerComponent>())
             {
                 transform.ValueRW.Position = _inputComponent.MouseWorldPosition;
                 _isMouseDown = _inputComponent.IsMouseDown;
             }
          
        }

        
        private void SpawnSand(ref SystemState state)
        {
            _spawnCounter += state.World.Time.DeltaTime;
            
            
            if (_isMouseDown && _spawnCounter > _spawnTimer)
            {
                _spawnCounter = 0;
                _sandCount++; 
                Debug.Log("DropSand: " + _sandCount);
                Entity entityInstance = _entityManager.Instantiate(_configComponent.ParticlePrefab);
                _entityManager.SetComponentData(entityInstance, new LocalTransform
                    {
                        Position = _inputComponent.MouseWorldPosition,
                        Rotation = quaternion.identity,
                        Scale = _entityManager.GetComponentData<LocalTransform>(_configComponent.ParticlePrefab).Scale
                    }
                );
            }
            
            _isMouseDown = false;
        }
        
    
        
        
        static float4 RandomColor(ref Random random)
        {
            // 0.618034005f is inverse of the golden ratio
            var hue = (random.NextFloat() + 0.618034005f) % 1;
            return (Vector4)Color.HSVToRGB(hue, 1.0f, 1.0f);
        }
    }


}