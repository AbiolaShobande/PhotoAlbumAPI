﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.DTO
{
    public class AlbumDTO
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
    }
}