﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.DataTypes
{
    public  abstract class SmartResponseBase
    {
        public bool Success { get; set; }
        public String ErrorMessage { get; set; }
    }
}
