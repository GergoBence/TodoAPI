﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoAPI.Models
{
    public class Todo : Entity
    {
        public string Content { get; set; }
        public bool Done { get; set; }
    }
}