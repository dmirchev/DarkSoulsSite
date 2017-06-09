using DarkSoulsSite.Common.Extensions;
using DarkSoulsSite.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSoulsSite.Entities.Functions
{
    public class Fight
    {
        [Key]
        public string Id { get; set; }

        public string CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public string BossId { get; set; }
        public virtual Boss Boss { get; set; }

        public int CharacterPoints { get; set; }
        public int BossPoints { get; set; }

        public Fight()
        {

        }

        public Fight(string characterId, string bossId,
            int characterPoints, int bossPoints, CustomId id = null)
            : this(id)
        {
            this.CharacterId = characterId;
            this.BossId = bossId;
            this.CharacterPoints = characterPoints;
            this.BossPoints = bossPoints;
        }

        public Fight(CustomId id)
        {
            this.Id = string.IsNullOrEmpty(Convert.ToString(id)) ? new CustomId().ToString() : id.ToString();
        }
    }
}
