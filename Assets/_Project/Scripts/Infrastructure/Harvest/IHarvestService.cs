using Game.Domain.Harvest;

namespace Game.Infrastructure.Harvest
{
    public interface IHarvestService
    {
        IHarvestedItem CollectedFruits { get; }
        IHarvestedItem DeadSprouts { get; }
    }
}
