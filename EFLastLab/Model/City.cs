﻿using EFLastLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLastLab
{
   public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public List<UserVisits> userVisits { get; set; }
        //public Book book { get; set; }


    }
}
