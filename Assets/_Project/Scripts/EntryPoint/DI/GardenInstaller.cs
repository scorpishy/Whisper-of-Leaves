using System.Collections.Generic;
using Game.Domain.Garden;
using Game.Domain.Plant;
using Game.Infrastructure.Garden;
using Game.Presentation.Garden;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.EntryPoint.DI
{
    public class GardenInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private int _rows = 3;
        [SerializeField] private int _columns = 3;

        public void Install(IContainerBuilder builder)
        {
            List<IGardenCell> gardenCells = CreateGardenCells(_rows, _columns);

            builder.Register<IGarden, Garden>(Lifetime.Singleton)
                   .WithParameter<IEnumerable<IGardenCell>>(gardenCells);

            builder.Register<IGardenCellPresenter, GardenCellPresenter>(Lifetime.Singleton);

            builder.RegisterComponentInHierarchy<GardenView>();
        }

        private List<IGardenCell> CreateGardenCells(int rows, int columns)
        {
            List<IGardenCell> gardenCells = new List<IGardenCell>(rows * columns);

            for (int i = 0; i < rows * columns; i++)
            {
                GardenCell cell = new GardenCell(() => new Plant());
                gardenCells.Add(cell);
            }

            return gardenCells;
        }
    }
}
