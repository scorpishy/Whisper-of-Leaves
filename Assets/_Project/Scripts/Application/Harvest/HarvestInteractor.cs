using Game.Domain.HarvestScope;

namespace Game.Application.HarvestScope
{
    public class HarvestInteractor
    {
        private readonly IHarvestRepository _repository;

        public HarvestInteractor(IHarvestRepository repository) => _repository = repository;

        public void AddHarvest(HarvestedItemType type, int quantity = 1)
        {
            HarvestedItem item = _repository.Get(type);
            item.Add(quantity);
            _repository.Save(item);
        }
    }
}