﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Roles
    {
        [Key]
        public int Role_id { get; set; }
        public string Role_name { get; set; }

        public ICollection<Userss> Users { get; set; }
    }
}
