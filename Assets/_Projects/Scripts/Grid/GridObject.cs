namespace CatHotelStudios.Grid
{
    public class GridObject
    {
        private GridPosition _gridPosition;
        private GridSystem<GridObject> _gridSystem;
        
        public GridObject( GridSystem<GridObject> gridSystem, GridPosition gridPosition)
        {
            _gridSystem = gridSystem;
            _gridPosition = gridPosition;
        }

        public override string ToString()
        {
            return _gridPosition.ToString();
        }
    }
}