﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kutse.Models
{
    public class Guest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Sisesta nimi")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sisesta email")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage ="Valesti sisestatud email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Sisesta telefoni number")]
        [RegularExpression(@"\+372\d{8}", ErrorMessage = "Vale number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Sisesta oma valik")]
        public bool? WillAttend { get; set; }
    }
}