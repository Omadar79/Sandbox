using UnityEngine;

namespace CatHotelStudios.Grid
{
    public class GridVisualGameObject : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public int gridPositionX;
        public int gridPositionY;
        
        // Start is called before the first frame update
        public void Show()
        {
            _spriteRenderer.enabled = true;
        }


        public void Hide()
        {
            _spriteRenderer.enabled = false;
        }
    }
}