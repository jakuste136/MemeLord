using System;

namespace MemeLord.Models
{
    public interface ISoftDeletable
    {
        DateTime? DeletionDate { get; set; }
    }
}