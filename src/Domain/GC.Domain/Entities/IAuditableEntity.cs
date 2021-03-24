using System;

namespace CG.Domain.Entities
{
    public interface IAuditableEntity
    {
        /// <summary>
        /// Entity creation date at Utc.
        /// </summary>
        DateTime CreatedDateAtUtc { get; set; }
        
        /// <summary>
        /// Entity logicalDeleted date at Utc.
        /// </summary>
        DateTime? DeletedDateAtUtc { get; set; }
        
        /// <summary>
        /// Entity last update date at Utc.
        /// </summary>
        DateTime? LastUpdateDateAtUtc { get; set; }
    }
}