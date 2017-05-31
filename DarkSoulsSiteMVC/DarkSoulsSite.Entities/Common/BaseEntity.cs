using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DarkSoulsSite.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkSoulsSite.Common.Extensions;

namespace DarkSoulsSite.Entities.Common
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

       

        [Required]
        public int Level { get; set; }

        [Required]
        public string Image { get; set; }



        public BaseEntity() { }

        public BaseEntity(string name, int level, string image, CustomId id = null)
            : this(id)
        {
            this.Name = name;
            this.Level = level;
            this.Image = image;
        }

        public BaseEntity(CustomId id)
        {
            this.Id = string.IsNullOrEmpty(Convert.ToString(id)) ? new CustomId().ToString() : id.ToString();
        }
    }
}
