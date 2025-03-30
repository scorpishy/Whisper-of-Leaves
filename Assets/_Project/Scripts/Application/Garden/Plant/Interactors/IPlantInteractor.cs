using System;

namespace Game.Application.GardenScope
{
    public interface IPlantInteractor
    {
        void Execute(Guid cellId);
    }
}
