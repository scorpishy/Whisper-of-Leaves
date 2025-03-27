using Game.Domain.Garden;

namespace Game.Application.Plant
{
    public interface IGrowPlantInteractor
    {
        void Execute(IGardenCell cell);
    }
}
