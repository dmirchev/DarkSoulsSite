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
        public string BaseArmor { get; set; }
        public string FireDefense { get; set; }
        public string MagicDefense { get; set; }
        public string LightningDefense { get; set; }

        public Armor(string baseArmor, string fireDefense, string magicDefense, string lightningDefense,
            string name, int level, CustomId id)
            : base(name, level, id)
        {
            this.BaseArmor = baseArmor;
            this.FireDefense = fireDefense;
            this.MagicDefense = magicDefense;
            this.LightningDefense = lightningDefense;
        }
    }
}
