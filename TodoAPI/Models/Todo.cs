using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoAPI.Models
{
    public class Todo 
    {
        
        public int ID { get; set; }
        public string Content { get; set; }
        public bool Done { get; set; }
    }
}