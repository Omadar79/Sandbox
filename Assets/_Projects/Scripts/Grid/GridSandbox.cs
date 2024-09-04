using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CatHotelStudios.Grid
{
    public class GridSandbox: MonoBehaviour
    {
        
        [SerializeField] protected int gridWidth = 30;
        [SerializeField] protected int gridHeight = 30;
        [SerializeField] protected float cellSize = .001f;
        
        private GridSystem<GridObject> _gridSystem;

        private void OnEnable()
        {
            SetupGridSystem();
        }
        
        [Button]
        private void SetupGridSystem()
        {
            if (_gridSystem != null)
            {
                ClearGridSystem();
            }
            
            
            _gridSystem = new GridSystem<GridObject>(gridWidth, gridHeight, cellSize
                , (g, gridPosition) => new GridObject(g, gridPosition));
        }

        private void ClearGridSystem()
        {
            _gridSystem = null;
        }
        
        public int GetWidth() => _gridSystem?.GetWidth() ?? 0;
        public int GetHeight() => _gridSystem?.GetHeight() ?? 0;

        public Vector3 GetWorldPosition(GridPosition gridPosition)
        {
            return _gridSystem.GetWorldPosition(gridPosition);
        }
        

        
        
    }
}