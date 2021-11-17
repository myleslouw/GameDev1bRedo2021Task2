using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade6112
{
    [Serializable]
    class RangedWeapon : Weapon
    {
        public enum Types { Rifle, Longbow}
        public override int Range { get => base.Range; set => base.Range = value; }


        public RangedWeapon(int y, int x, string symbol, Types _weaponType) : base(y, x, symbol)
        {
            X = x;
            Y = y;

            switch (_weaponType)
            {
                case Types.Rifle:
                    Symbol = "*";
                    TypeString = "Rifle";
                    Durabilty = 3;
                    Range = 3;
                    Damage = 5;
                    WeaponCost = 7;
                    break;

                case Types.Longbow:
                    Symbol = "^";
                    TypeString = "Longbow";
                    Durabilty = 4;
                    Range = 2;
                    Damage = 4;
                    WeaponCost = 6;
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
