using Game.Domain.Garden;

namespace Game.Infrastructure.Garden
{
    public interface IGardenCellPresenter
    {
        void ExecuteCellAction(IGardenCell cell);
    }
}
