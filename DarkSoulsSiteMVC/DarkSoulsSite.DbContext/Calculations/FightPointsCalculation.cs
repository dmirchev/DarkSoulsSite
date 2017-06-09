using DarkSoulsSite.Entities.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSoulsSite.DbContext.Calculations
{
    public class FightPointsCalculation
    {
        int characterPoints = 0;
        int bossPoints = 0;

        public object FightPoints(Fight fight)
        {
            if (fight.Character.Level > fight.Boss.Level)
            {
                characterPoints++;
                
            }
            else
            {
                bossPoints++;
            }

            if (fight.Character.FinalDamage > fight.Boss.BaseDamage)
            {
                if (fight.Character.Magic.Fire > fight.Boss.FireDefense)
                {
                    characterPoints++;
                }
                else
                {
                    bossPoints++;
                }

                if (fight.Character.Magic.Ice > fight.Boss.IceDefense)
                {
                    characterPoints++;
                }
                else
                {
                    bossPoints++;
                }

                if (fight.Character.Magic.Lightning > fight.Boss.LightningDefense)
                {
                    characterPoints++;
                }
                else
                {
                    bossPoints++;
                }
            }

            if (fight.Character.FinalDamage > fight.Boss.BaseDamage)
            {
                if (fight.Character.FinalDamage > fight.Boss.BaseArmor)
                {
                    characterPoints++;
                }
                else
                {
                    bossPoints++;
                }

                if (fight.Character.Weapon.Bleed == true && fight.Boss.BleedDefence == false)
                {
                    characterPoints++;
                }
                else if (fight.Character.Weapon.Bleed == false && fight.Boss.BleedDefence == true)
                {
                    bossPoints++;
                }
            }

            fight.CharacterPoints = characterPoints;
            fight.BossPoints = bossPoints;

            return fight;
        }
    }
}
