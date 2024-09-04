using Unity.Entities;
using UnityEngine;

namespace CatHotelStudios.ECS
{
    public class ParticleAuthoring : MonoBehaviour
    {
        private class ParticleBaker : Baker<ParticleAuthoring>
        {
            public override void Bake(ParticleAuthoring authoring)
            {
                Entity entity = GetEntity( TransformUsageFlags.Dynamic);
                
                AddComponent<GridComponent>(entity);
            }
        }
    }
    
    //
    // public struct ParticleComponent : IComponentData
    // {
    //    //public int2 GridPosition;
    // }
    
    public struct GridComponent : IComponentData
    {
    }
}