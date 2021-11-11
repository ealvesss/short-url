using System;
using System.Collections.Generic;
using System.Text;

namespace HeyUrl.Domain.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; private set; }

        public EntityBase()
        {
            Id = Guid.Empty;
        }
    }
}
