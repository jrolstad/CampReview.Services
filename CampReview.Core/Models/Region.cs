﻿using CampReview.Data;

namespace CampReview.Core.Models
{
    public class Region: IEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}