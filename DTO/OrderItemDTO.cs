﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderItemDTO
    {

        public int? ProductId { get; set; }

        public int Quentity { get; set; }

    }
}
