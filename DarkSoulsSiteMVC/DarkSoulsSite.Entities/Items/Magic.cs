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
    public class Magic : BaseEntity
    {
        [Required]
        [Display(Name = "Base Magic")]
        public int BaseMagic { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lightning { get; set; }

        public Magic()
        {

        }

        public Magic(int baseMagic, int fire, int ice, int lightning,
            string name, int level, string image, CustomId id)
            : base(name, level, image, id)
        {
            this.BaseMagic = baseMagic;
            this.Fire = fire;
            this.Ice = ice;
            this.Lightning = lightning;
        }
    }
}
