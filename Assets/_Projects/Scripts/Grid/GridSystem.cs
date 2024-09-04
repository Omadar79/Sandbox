using System;
using UnityEngine;

namespace CatHotelStudios.Grid
{
    public class GridSystem<TGridObject>
    {
        private int _width;
        private int _height;
        private float _cellSize;
        private TGridObject[,] _gridObjectArray;

        public GridSystem(int width, int height, float cellSize,
            Func<GridSystem<TGridObject>, GridPosition, TGridObject> createGridObject)
        {
            _width = width;
            _height = height;
            _cellSize = cellSize;

            _gridObjectArray = new TGridObject[width, height];

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    GridPosition gridPosition = new GridPosition(x, y);
                    _gridObjectArray[x, y] = createGridObject(this, gridPosition);
                }
            }
        }

        public int GetWidth() => _width;

        public int GetHeight() => _height;

        public Vector3 GetWorldPosition(GridPosition gridPosition)
        {
            return new Vector3(gridPosition.x,  gridPosition.y, 0) * _cellSize;
        }

        public GridPosition GetGridPosition(Vector3 worldPosition)
        {
            return new GridPosition(Mathf.RoundToInt(worldPosition.x / _cellSize),
                Mathf.RoundToInt(worldPosition.z / _cellSize));
        }


        public TGridObject GetGridObject(GridPosition gridPosition)
        {
            return _gridObjectArray[gridPosition.x, gridPosition.y];
        }

        public bool IsValidGridPosition(GridPosition gridPosition)
        {
            return gridPosition.x >= 0 &&
                   gridPosition.y >= 0 &&
                   gridPosition.x < _width &&
                   gridPosition.y < _height;
        }
    }
}
