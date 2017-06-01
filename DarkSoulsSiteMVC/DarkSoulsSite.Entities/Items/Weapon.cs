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
        [Display(Name = "Base Damage")]
        public int BaseDamage { get; set; }
        public bool Bleed { get; set; }
        public bool Poison { get; set; }

        public Weapon()
        {

        }

        public Weapon(int baseDamage, bool bleed, bool poison,
            string name, int level, string image, CustomId id)
            : base(name, level, image, id)
        {
            this.BaseDamage = baseDamage;
            this.Bleed = bleed;
            this.Poison = poison;
        }
    }
}
