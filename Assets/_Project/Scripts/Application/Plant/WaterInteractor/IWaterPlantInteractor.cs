using Game.Domain.Garden;

namespace Game.Application.Plant
{
    public interface IWaterPlantInteractor
    {
        void Execute(IGardenCell cell);
    }
}
