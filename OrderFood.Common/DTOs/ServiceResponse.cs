﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.Common.DTOs
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }

        public List<T>? Datas { get; set; }
    }
}
