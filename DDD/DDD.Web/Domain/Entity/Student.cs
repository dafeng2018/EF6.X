﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Web.Domain.Entity
{
    public class Student : BaseEntity
    {

        public string Name { get; set; }

        public int TeacherId { get; set; }
    }
}
