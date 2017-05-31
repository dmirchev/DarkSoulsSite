using DarkSoulsSite.Common.Extensions;
using DarkSoulsSite.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSoulsSite.Entities
{
    public class DarkSouls
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public string CharacterId { get; set; }
        //public virtual Character Character;

        public string BossId { get; set; }

        public DarkSouls(string userId, string characterId, string bossId,
            DateTime dateCreated, DateTime? dateModified, CustomId id = null)
            :this(id)
        {
            this.UserId = userId;
            this.CharacterId = characterId;
            this.BossId = BossId;
            //this.DateCreated = dateCreated;
            //this.DateModified = dateModified;
        }

        public DarkSouls(CustomId id)
        {
            this.Id = string.IsNullOrEmpty(Convert.ToString(id)) ? new CustomId().ToString() : id.ToString();
        }
    }
}
