using System;
using System.Collections.Generic;

namespace Game.Domain.GardenScope
{
    public class Garden
    {
        private readonly int _rows = 3;
        private readonly int _columns = 3;
        private readonly Dictionary<Guid, GardenCell> _cells;

        public Guid Id { get; } = Guid.NewGuid();
        public IReadOnlyDictionary<Guid, GardenCell> Cells => _cells;

        public event Action<Guid, PlantState> OnCellStateChanged;

        public Garden(Func<GardenCell> cellFactory)
        {
            _cells = new Dictionary<Guid, GardenCell>();

            for (int i = 0; i < _rows * _columns; i++)
            {
                GardenCell cell = cellFactory();
                _cells[cell.Id] = cell;
                cell.OnStateChanged += state => OnCellStateChanged?.Invoke(cell.Id, state);
            }
        }

        public PlantState GetCellState(Guid cellId)
        {
            if (_cells.TryGetValue(cellId, out GardenCell cell))
                return cell.IsEmpty ? PlantState.None : cell.Plant.State;

            throw new ArgumentException($"Cell with ID {cellId} not found.");
        }

        public void PlantSeed(Guid cellId)
        {
            if (_cells.TryGetValue(cellId, out GardenCell cell))
            {
                cell.PlantSeed();
                OnCellStateChanged?.Invoke(cellId, cell.Plant.State);
                return;
            }
            throw new ArgumentException($"Cell with ID {cellId} not found.");
        }

        public void GrowPlant(Guid cellId)
        {
            if (_cells.TryGetValue(cellId, out GardenCell cell) && !cell.IsEmpty)
            {
                cell.Grow();
                return;
            }
            throw new ArgumentException($"Cell with ID {cellId} not found.");
        }

        public void WitherPlant(Guid cellId)
        {
            if (_cells.TryGetValue(cellId, out GardenCell cell) && !cell.IsEmpty)
            {
                cell.Wither();
                return;
            }
            throw new ArgumentException($"Cell with ID {cellId} not found.");
        }

        public void RemovePlant(Guid cellId)
        {
            if (_cells.TryGetValue(cellId, out GardenCell cell))
            {
                cell.Remove();
                OnCellStateChanged?.Invoke(cellId, PlantState.None);
                return;
            }
            throw new ArgumentException($"Cell with ID {cellId} not found.");
        }
    }
}
