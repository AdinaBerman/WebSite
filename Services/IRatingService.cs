﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRatingService
    {
        public Task<Rating> addRating(Rating rating);
    }
}
