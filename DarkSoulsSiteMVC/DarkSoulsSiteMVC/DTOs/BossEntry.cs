using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DarkSoulsSiteMVC.DTOs
{
    public class BossEntry
    {
        [Required]
        [Display(Name = "Base Damage")]
        public int BaseDamage { get; set; }

        [Required]
        [Display(Name = "Base Armor")]
        public int BaseArmor { get; set; }

        [Display(Name = "Fire Defense")]
        public int FireDefense { get; set; }

        [Display(Name = "Ice Defense")]
        public int IceDefense { get; set; }

        [Display(Name = "Lightning Defense")]
        public int LightningDefense { get; set; }

        [Display(Name = "Bleed Defence")]
        public bool BleedDefence { get; set; }

        [Display(Name = "Poison Defence")]
        public bool PoisonDefence { get; set; }

        public string Reward { get; set; }

        public int Rating { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        //[Required]
        public string Image { get; set; }
    }
}