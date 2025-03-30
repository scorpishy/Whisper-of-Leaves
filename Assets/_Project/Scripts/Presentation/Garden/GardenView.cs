using Game.Domain.GardenScope;
using UnityEngine;
using VContainer;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Game.Presentation.GardenScope
{
    public class GardenView : MonoBehaviour
    {
        [SerializeField] private GardenCellView[] cellViews;

        private Garden _garden;
        private GardenCellPresenter _gardenCellPresenter;

        [Inject]
        public void Construct(Garden garden, GardenCellPresenter gardenCellPresenter)
        {
            _garden = garden;
            _gardenCellPresenter = gardenCellPresenter;
        }

        private void Start()
        {
            List<Guid> cellIds = _garden.Cells.Select(cell => cell.Value.Id).ToList();
            int count = Mathf.Min(cellViews.Length, cellIds.Count);
            for (int i = 0; i < count; i++)
            {
                cellViews[i].Initialize(cellIds[i], _garden, _gardenCellPresenter);
            }
        }
    }
}
