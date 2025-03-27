using Game.Domain.Garden;

namespace Game.Application.Plant
{
    public interface IRemovePlantInteractor
    {
        void Execute(IGardenCell cell);
    }
}
