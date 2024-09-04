using Unity.Entities;
using Unity.Mathematics;

namespace CatHotelStudios.ECS
{
    public struct InputComponent : IComponentData
    {
        public float2 MousePosition;
        public float3 MouseWorldPosition;
        public bool IsMouseDown;
    }
}
