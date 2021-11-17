using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade6112
{
    [Serializable]
    class MeleeWeapon : Weapon
    {
        public enum Types { Dagger , Longsword}

        public override int Range { get => base.Range; set => base.Range = value; }


        public MeleeWeapon(int y, int x, string symbol, Types _weaponType) : base(y, x, symbol)
        {
            X = x;
            Y = y;

            switch (_weaponType)
            {
                case Types.Dagger:
                    Symbol = "-";
                    TypeString = "Dagger";
                    Durabilty = 10;
                    Damage = 3;
                    WeaponCost = 3;
                    break;

                case Types.Longsword:
                    Symbol = "/";
                    TypeString = "Longsword";
                    Durabilty = 6;
                    Damage = 4;
                    WeaponCost = 5;
                    break;

                default:
                    break;
            }

        }

        public override string ToString()
        {
            return "Weapon: " + this.TypeString;
        }
    }
}
