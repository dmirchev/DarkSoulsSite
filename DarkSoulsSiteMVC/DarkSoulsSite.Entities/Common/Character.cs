using DarkSoulsSite.Common.Extensions;
using DarkSoulsSite.Entities.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSoulsSite.Entities.Common
{
    public class Character : BaseEntity
    {
        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [Display(Name = "Character Base Damage")]
        public int CharDamage { get; set; }

        [Required]
        [Display(Name = "Character Base Armor")]
        public int CharArmor { get; set; }

        [Required]
        [Display(Name = "Character Base Magic")]
        public int CharMagic { get; set; }

        [Required]
        [Display(Name = "Weapon")]
        public string WeaponId { get; set; }
        public virtual Weapon Weapon { get; set; }

        [Required]
        [Display(Name = "Armor")]
        public string ArmorId { get; set; }
        public virtual Armor Armor { get; set; }

        [Required]
        [Display(Name = "Magic")]
        public string MagicId { get; set; }
        public virtual Magic Magic { get; set; }

        public int FinalDamage { get; set; }
        public int FinalArmor { get; set; }
        public int FinalMagic { get; set; }

        public Character()
        {

        }

        public Character(string userid, int charDamage, int charArmor, int charMagic,
            string weaponid, string armorid, string magicid,
            int finalDamage, int finalArmor, int finalMagic,
            string name, int level, string image, CustomId id)
            : base(name, level, image, id)
        {
            this.UserId = userid;
            this.CharDamage = charDamage;
            this.CharArmor = charArmor;
            this.CharMagic = charMagic;
            this.WeaponId = weaponid;
            this.ArmorId = armorid;
            this.MagicId = magicid;

            this.FinalDamage = finalDamage;
            this.FinalArmor = finalArmor;
            this.FinalMagic = finalMagic;
            
        }
    }

}
