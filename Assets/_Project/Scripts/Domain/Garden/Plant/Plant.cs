using System;
using Game.Domain.CommonScope;

namespace Game.Domain.GardenScope
{
    public class Plant : IIdentifiable
    {
        public Guid Id { get; } = Guid.NewGuid();
        public PlantState State { get; private set; }

        public Plant()
        {
            State = PlantState.Seed;
        }

        internal void Grow()
        {
            if (State == PlantState.Seed)
                State = PlantState.Sprout;
            else if (State == PlantState.Sprout)
                State = PlantState.Fruit;
        }

        internal void Wither()
        {
            if (State == PlantState.Sprout)
                State = PlantState.DeadSprout;
        }
    }
}
