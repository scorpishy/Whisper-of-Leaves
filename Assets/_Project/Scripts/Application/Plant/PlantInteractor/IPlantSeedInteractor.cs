using Game.Domain.Garden;

namespace Game.Application.Plant
{
    public interface IPlantSeedInteractor
    {
        void Execute(IGardenCell cell);
    }
}
