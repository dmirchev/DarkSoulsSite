using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DarkSoulsSiteMVC.DTOs
{
    public class ArmorEntry
    {
        [Required]
        [Display(Name = "Base Armor")]
        public int BaseArmor { get; set; }

        [Required]
        [Display(Name = "Fire Defense")]
        public int FireDefense { get; set; }

        [Required]
        [Display(Name = "Ice Defense")]
        public int IceDefense { get; set; }

        [Required]
        [Display(Name = "Lightning Defense")]
        public int LightningDefense { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public string Image { get; set; }
    }
}