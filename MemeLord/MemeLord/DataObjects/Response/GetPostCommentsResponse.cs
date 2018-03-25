﻿using System.Collections.Generic;
using MemeLord.DataObjects.Dto;

namespace MemeLord.DataObjects.Response
{
    public class GetPostCommentsResponse
    {
        public int LastId { get; set; }
        public IEnumerable<CommentDto> CommentsList { get; set; }
    }
}