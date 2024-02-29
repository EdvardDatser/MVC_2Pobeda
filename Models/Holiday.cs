using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kutse.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Sisesta id siia")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Sisesta pidu nimi siia")]
        public DateTime Date { get; set; }
    }
}