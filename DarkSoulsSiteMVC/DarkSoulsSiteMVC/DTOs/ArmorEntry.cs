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
        public int BaseArmor { get; set; }
        [Required]
        public int FireDefense { get; set; }
        [Required]
        public int IceDefense { get; set; }
        [Required]
        public int LightningDefense { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public string Image { get; set; }
    }
}