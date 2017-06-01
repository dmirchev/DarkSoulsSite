using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DarkSoulsSiteMVC.DTOs
{
    public class CharacterEntry
    {
        [Required]
        [Display(Name = "Choose Weapon")]
        public string WeaponId { get; set; }

        [Required]
        [Display(Name = "Choose Armor")]
        public string ArmorId { get; set; }

        [Required]
        [Display(Name = "Choose Magic")]
        public string MagicId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public string Image { get; set; }
    }
}