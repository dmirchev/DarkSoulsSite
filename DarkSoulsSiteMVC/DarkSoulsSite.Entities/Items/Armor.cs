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
        public int BaseArmor { get; set; }
        public int FireDefense { get; set; }
        public int IceDefense { get; set; }
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
