using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DarkSoulsSiteMVC.DTOs
{
    public class WeaponEntry
    {
        [Required]
        [Display(Name = "Base Damage")]
        public int BaseDamage { get; set; }

        [Required]
        public bool Bleed { get; set; }

        [Required]
        public bool Poison { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        //[Required]
        public string Image { get; set; }
    }
}