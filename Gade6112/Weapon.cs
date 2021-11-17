using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade6112
{
    [Serializable]
    abstract class Weapon : Item
    {
        protected int damage;

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        protected virtual int range { get; set; }

        public virtual int Range
        {
            get { return range; }
            set { range = value; }
        }

        protected int durabilty;

        public int Durabilty
        {
            get { return durabilty; }
            set { durabilty = value; }
        }

        protected int weaponCost;


        public int WeaponCost
        {
            get { return weaponCost; }
            set { weaponCost = value; }
        }

        public string TypeString; //the name of the weapon

        public Weapon(int y, int x, string symbol) : base(y, x, symbol)
        {

        }

    }
}
