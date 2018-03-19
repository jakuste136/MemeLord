using System;

namespace MemeLord.Models.Utils
{
    public interface ISoftDeletable
    {
        DateTime? DeletionDate { get; set; }
    }
}