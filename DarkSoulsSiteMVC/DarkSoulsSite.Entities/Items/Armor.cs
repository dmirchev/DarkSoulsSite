using DarkSoulsSite.Common.Extensions;
using DarkSoulsSite.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSoulsSite.Entities.Items
{
    public class Armor : BaseEntity
    {
        [Required]
        [Display(Name = "Base Armor")]
        public int BaseArmor { get; set; }
        [Display(Name = "Fire Defense")]
        public int FireDefense { get; set; }
        [Display(Name = "Ice Defense")]
        public int IceDefense { get; set; }
        [Display(Name = "Lightning Defense")]
        public int LightningDefense { get; set; }

        public Armor()
        {

        }

        public Armor(int baseArmor, int fireDefense, int iceDefense, int lightningDefense,
            string name, int level, string image, CustomId id)
            : base(name, level, image, id)
        {
            this.BaseArmor = baseArmor;
            this.FireDefense = fireDefense;
            this.IceDefense = iceDefense;
            this.LightningDefense = lightningDefense;
        }
    }
}
