﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcess.API.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Error { get; set; }
    }
}
