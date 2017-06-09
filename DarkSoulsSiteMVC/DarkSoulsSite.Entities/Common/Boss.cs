
using DarkSoulsSite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSoulsSite.Entities.Common
{
    public class Boss : BaseEntity
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

        public Boss()
        {

        }

        public Boss(int baseDamage, int baseArmor, int fireDefense, int iceDefense, int lightningDefense,
            bool bleedDefense, bool poisonDefense, string reward, int rating,
            string name, int level, string image, CustomId id)
            : base(name, level, image, id)
        {
            this.BaseDamage = baseDamage;
            this.BaseArmor = baseArmor;
            this.FireDefense = fireDefense;
            this.IceDefense = iceDefense;
            this.LightningDefense = lightningDefense;
            this.BleedDefence = bleedDefense;
            this.PoisonDefence = poisonDefense;
            this.Reward = reward;
            this.Rating = rating;
        }
    }
}
