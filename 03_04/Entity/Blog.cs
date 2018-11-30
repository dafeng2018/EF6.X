﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _03_04.Entity
{
    public class Blog : BaseEntity
    {
        [Required]
        [StringLength(100, ErrorMessage = "不能超过100字")]
        [Url]
        public string Url { get; set; }
        internal string _Tags { get; set; }
        public string[] Tags
        {
            get
            {
                return _Tags == null ? null : JsonConvert.DeserializeObject<string[]>(_Tags);
            }
            set
            {
                _Tags = JsonConvert.SerializeObject(value);
            }
        }
        internal string _Owner { get; set; }
        public Person Owner
        {
            get
            {
                return _Owner == null ? null : JsonConvert.DeserializeObject<Person>(_Owner);
            }
            set
            {
                _Owner = JsonConvert.SerializeObject(value);
            }
        }
        public virtual ICollection<Post> Posts { get; set; }
    }
}