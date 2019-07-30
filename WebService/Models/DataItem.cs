using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class DataItem
    {
        [Key]
        public int Number { get; set; }
        [Required]
        public int Code { get; set; }
        [Required]
        public string Value { get; set; }
    }
}