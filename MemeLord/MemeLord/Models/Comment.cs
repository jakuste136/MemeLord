﻿using System;
using System.Collections.Generic;
using MemeLord.Models.Utils;

namespace MemeLord.Models
{
    public class Comment : BaseEntity, ISoftDeletable
    {
        public Post Post { get; set; }
        public Comment MasterComment { get; set; }
        public IList<Comment> Answers { get; set; }
        public User User { get; set; }
        public int Rating { get; set; }
        public DateTime? DeletionDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Text { get; set; }
    }
}