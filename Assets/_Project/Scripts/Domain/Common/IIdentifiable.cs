using System;

namespace Game.Domain.CommonScope
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
