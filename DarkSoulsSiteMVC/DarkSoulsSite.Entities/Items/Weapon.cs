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
    public class Weapon : BaseEntity
    {
        [Required]
        public string BaseDamage { get; set; }
        public string FireDamage { get; set; }
        public string MagicDamage { get; set; }
        public string LightningDamage { get; set; }

        public Weapon(string baseDamage, string fireDamage, string magicDamage, string lightningDamage,
            string name, int level, CustomId id)
            : base(name, level, id)
        {
            this.BaseDamage = baseDamage;
            this.FireDamage = fireDamage;
            this.MagicDamage = magicDamage;
            this.LightningDamage = lightningDamage;
        }
    }
}
