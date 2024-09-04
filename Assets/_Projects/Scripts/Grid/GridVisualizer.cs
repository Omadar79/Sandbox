using Sirenix.OdinInspector;
using UnityEngine;

namespace CatHotelStudios.Grid
{
    public class GridVisualizer: MonoBehaviour
    {
        [SerializeField,Required] private GridSandbox gridSandbox;
    
        [SerializeField,Required] Transform gridSystemVisualTransform;
        
        
        private GridVisualGameObject[,] _gridVisualGameObject;
        
        

        [Button]
        private void InitializeVisualization()
        {
            ResetGridVisuals();
            _gridVisualGameObject = new GridVisualGameObject[gridSandbox.GetWidth(),gridSandbox.GetHeight()];
            
            var visualSizeX = gridSystemVisualTransform.transform.GetComponent<SpriteRenderer>().bounds.extents.x;
            var visualSizeY = gridSystemVisualTransform.transform.GetComponent<SpriteRenderer>().bounds.extents.y;
            
            for (int x = 0; x < gridSandbox.GetWidth(); x++)
            {
                for (int y = 0; y < gridSandbox.GetHeight(); y++)
                {
                    GridPosition gridPosition = new GridPosition(x, y);
                    Transform gridSystemVisTransform = Instantiate(gridSystemVisualTransform, new Vector3(x * visualSizeX, y * visualSizeY), Quaternion.identity,this.transform);
                    
                     _gridVisualGameObject[x, y] = gridSystemVisTransform.GetComponentInChildren<GridVisualGameObject>();
                     _gridVisualGameObject[x, y].gridPositionX = x;
                     _gridVisualGameObject[x, y].gridPositionY = y;
                }
            }

            UpdateGridVisuals();
        }

        private void ResetGridVisuals()
        {
            if (_gridVisualGameObject == null) return;
            
            for (int x = 0; x < gridSandbox.GetWidth(); x++)
            {
                for (int y = 0; y < gridSandbox.GetHeight(); y++)
                {
                    DestroyImmediate(_gridVisualGameObject[x, y] .gameObject);
                }
            }
        }

        private void UpdateGridVisuals()
        {
        }


    }
}