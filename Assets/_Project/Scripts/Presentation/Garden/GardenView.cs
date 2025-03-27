using System.Collections.Generic;
using Game.Domain.Garden;
using Game.Infrastructure.Garden;
using UnityEngine;
using VContainer;

namespace Game.Presentation.Garden
{
    public class GardenView : MonoBehaviour
    {
        [SerializeField] private GardenCellView[] cellViews;

        private IGarden _garden;
        private IGardenCellPresenter _gardenCellPresenter;

        [Inject]
        public void Construct(IGarden garden, IGardenCellPresenter gardenCellPresenter)
        {
            _garden = garden;
            _gardenCellPresenter = gardenCellPresenter;
        }

        private void Start()
        {
            IReadOnlyList<IGardenCell> cells = _garden.Cells;
            int count = Mathf.Min(cellViews.Length, cells.Count);
            for (int i = 0; i < count; i++)
            {
                cellViews[i].Initialize(cells[i], _gardenCellPresenter);
            }
        }
    }
}
