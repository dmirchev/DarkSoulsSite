using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DarkSoulsSiteMVC.DTOs
{
    public class MagicEntry
    {
        [Required]
        [Display(Name = "Base Magic")]
        public int BaseMagic { get; set; }

        [Required]
        public int Fire { get; set; }

        [Required]
        public int Ice { get; set; }

        [Required]
        public int Lightning { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        //[Required]
        public string Image { get; set; }
    }
}