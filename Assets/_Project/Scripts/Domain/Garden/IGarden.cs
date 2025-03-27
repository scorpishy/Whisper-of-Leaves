using System.Collections.Generic;

namespace Game.Domain.Garden
{
    public interface IGarden
    {
        IReadOnlyList<IGardenCell> Cells { get; }
    }
}
