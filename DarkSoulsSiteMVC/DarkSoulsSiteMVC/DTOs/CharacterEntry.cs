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
        public string WeaponId { get; set; }
        [Required]
        public string ArmorId { get; set; }
        [Required]
        public string MagicId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public string Image { get; set; }
    }
}