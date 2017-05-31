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
        public string BaseDamage { get; set; }
        [Required]
        public string BaseArmor { get; set; }
        public string FireDefense { get; set; }
        public string MagicDefense { get; set; }
        public string LightningDefense { get; set; }
        //public string Reward { get; set; }

        public Boss(string baseDamage, string baseArmor, string fireDefense, string magicDefense, string lightningDefense,
            string name, int level, CustomId id)
            : base(name, level, id)
        {
            this.BaseDamage = baseDamage;
            this.BaseArmor = baseArmor;
            this.FireDefense = fireDefense;
            this.MagicDefense = magicDefense;
            this.LightningDefense = lightningDefense;
        }
    }
}
