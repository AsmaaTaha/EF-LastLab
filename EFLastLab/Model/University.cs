﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLastLab.Model
{
   public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public President president { get; set; }
    }
}