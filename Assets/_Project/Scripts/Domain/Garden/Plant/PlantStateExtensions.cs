using Game.Domain.HarvestScope;

namespace Game.Domain.GardenScope
{
    public static class PlantStateExtensions
    {
        public static HarvestedItemType ToHarvestedItemType(this PlantState state)
        {
            return state switch
            {
                PlantState.Fruit => HarvestedItemType.Fruit,
                PlantState.DeadSprout => HarvestedItemType.DeadSprout,
                _ => HarvestedItemType.None
            };
        }
    }
}