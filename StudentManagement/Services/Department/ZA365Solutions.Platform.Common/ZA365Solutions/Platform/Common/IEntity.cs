namespace ZA365Solutions.Platform.Common
{
    using System;

    public interface IEntity
    {
        Guid Id { get; set; }

        bool IsDeleted { get; set; }

        bool IsNew { get; set; }
    }
}

