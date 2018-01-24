using System;

namespace Ks.Models
{
    public abstract class Entity
    {
        /// <summary>
        /// 流水号 PK
        /// </summary>
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}