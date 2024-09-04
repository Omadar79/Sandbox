using Unity.Entities;
using UnityEngine;

namespace CatHotelStudios.ECS
{
    public class MousePointerAuthoring : MonoBehaviour
    {
 
        private class PlayerBaker : Baker<MousePointerAuthoring>
        {
            public override void Bake(MousePointerAuthoring authoring)
            {
                Entity mouseEntity = GetEntity( TransformUsageFlags.Dynamic);
                
                AddComponent(mouseEntity,new MousePointerComponent {
                });
            }
        }
    }
    public struct MousePointerComponent : IComponentData
    {
    }
}