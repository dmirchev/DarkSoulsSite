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
        public string BaseMagic { get; set; }
        public string FireMagic { get; set; }
        public string MagicMagic { get; set; }
        public string LightningMagic { get; set; }

        public Magic(string baseMagic, string fireMagic, string magicMagic, string lightningMagic,
            string name, int level, CustomId id)
            : base(name, level, id)
        {
            this.BaseMagic = baseMagic;
            this.FireMagic = fireMagic;
            this.MagicMagic = magicMagic;
            this.LightningMagic = lightningMagic;
        }
    }
}
