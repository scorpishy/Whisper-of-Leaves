using System.Collections.Generic;
using Game.Domain.Common;

namespace Game.Domain.Garden
{
    public interface IGarden : IIdentifiable
    {
        IReadOnlyList<IGardenCell> Cells { get; }
    }
}
