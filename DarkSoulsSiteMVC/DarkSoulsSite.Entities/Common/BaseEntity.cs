using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSoulsSite.Entities.Common
{
    class BaseEntity
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        public BaseEntity() { }

        //public BaseEntity(string name, int level, CustonId)
    }
}
