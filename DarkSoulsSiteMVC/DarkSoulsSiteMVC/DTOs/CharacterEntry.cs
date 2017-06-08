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
        [Display(Name = "Character Base Damage")]
        public int CharDamage { get; set; }
        [Required]
        [Display(Name = "Character Base Armor")]
        public int CharArmor { get; set; }
        [Required]
        [Display(Name = "Character Base Magic")]
        public int CharMagic { get; set; }

        [Required]
        [Display(Name = "Choose Weapon")]
        public string WeaponId { get; set; }

        [Required]
        [Display(Name = "Choose Armor")]
        public string ArmorId { get; set; }

        [Required]
        [Display(Name = "Choose Magic")]
        public string MagicId { get; set; }

        public int FinalDamage { get; set; }
        public int FinalArmor { get; set; }
        public int FinalMagic { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        //[Required]
        public string Image { get; set; }
    }
}