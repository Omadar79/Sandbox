using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CatHotelStudios.ECS
{
    [UpdateBefore(typeof(GravitySystem))]
    public partial class InputSystem : SystemBase
    {
        private SandboxInputControls _sandboxInputControls;

        
        protected override void OnCreate()
        {
            if (!SystemAPI.TryGetSingleton(out InputComponent inputComponent))
            {
                EntityManager.CreateEntity(typeof(InputComponent));
            }

            _sandboxInputControls = new SandboxInputControls();
            _sandboxInputControls.Enable();
        }

        protected override void OnUpdate()
        {
            Vector2 mousePosition = _sandboxInputControls.Player.MoveAround.ReadValue<Vector2>();
            bool isMouseDown = _sandboxInputControls.Player.DropSand.IsPressed();

            SystemAPI.SetSingleton(new InputComponent()
            {
                MousePosition = new float2(mousePosition.x, mousePosition.y),
                MouseWorldPosition = Camera.main.ScreenToWorldPoint(new float3(mousePosition.x, mousePosition.y, 10f)),
                IsMouseDown = isMouseDown
            });

        }
    }
}