﻿using AGL.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGL.Web.ViewModels
{
    public class HomeViewModel
    {
        public string Gender { get; set; }
        public IEnumerable<Pet> Cats { get; set; }
    }

}
