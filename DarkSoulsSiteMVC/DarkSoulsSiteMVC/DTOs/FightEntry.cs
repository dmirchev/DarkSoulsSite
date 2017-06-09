using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkSoulsSiteMVC.DTOs
{
    public class FightEntry
    {
        public string CharacterId { get; set; }

        public string BossId { get; set; }

        public int CharacterPoints { get; set; }

        public int BossPoints { get; set; }

        public string Result { get; set; }
    }
}