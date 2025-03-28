using System;

namespace Game.Domain.Plant
{
    public class Plant : IPlant
    {
        public Guid Id { get; } = Guid.NewGuid();
        public PlantState State { get; private set; }

        public Plant()
        {
            State = PlantState.Seed;
        }

        public void Grow()
        {
            if (State == PlantState.Seed)
                State = PlantState.Sprout;
            else if (State == PlantState.Sprout)
                State = PlantState.Fruit;
        }

        public void Wither()
        {
            if (State == PlantState.Sprout)
                State = PlantState.DeadSprout;
        }
    }
}
