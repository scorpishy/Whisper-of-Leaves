using System;

namespace Game.Domain.Common
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
