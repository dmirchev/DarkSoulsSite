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
        public int BaseDamage { get; set; }
        [Required]
        public int BaseArmor { get; set; }
        public int FireDefense { get; set; }
        public int IceDefense { get; set; }
        public int LightningDefense { get; set; }
        public bool BleedDefence { get; set; }
        public bool BleedPoison { get; set; }
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
            this.Reward = reward;
            this.Rating = rating;
        }
    }
}
