﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFluentAPIRelationships.Entities
{
    public class Address
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
    }
}
