﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLastLab.Model
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Home home { get; set; }
    }
}
