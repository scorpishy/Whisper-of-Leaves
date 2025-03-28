using System;
using System.Collections.Generic;

namespace Game.Domain.Garden
{
    public class Garden : IGarden
    {
        private readonly List<IGardenCell> _cells;

        public Guid Id { get; } = Guid.NewGuid();
        public IReadOnlyList<IGardenCell> Cells => _cells;

        public Garden(IEnumerable<IGardenCell> cells)
        {
            _cells = new List<IGardenCell>(cells);
        }
    }
}
