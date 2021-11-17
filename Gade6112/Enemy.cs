using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade6112
{
    [Serializable]
    abstract class Enemy : Character
    {
        Random rndm = new Random();

        private Tile[] diagonalTiles;

        public Tile[] DiagonalTile  //the diagonal in characterVIsion used for mage
        {
            get { return diagonalTiles; }
            set { diagonalTiles = value; }
        }

        public Enemy(int _yPos, int _xPos, int _damage, int _HP, int _maxHP, string _symbol) : base(_yPos, _xPos, _symbol)
        {
            X = _xPos;
            Y = _yPos;
            Damage = _damage;
            HP = _HP;
            MaxHP = _maxHP;
            Symbol = "E";
            DiagonalTile = new Tile[4]; //only filled by mage
        }

        public override string ToString()
        {
            string enemyInfo;
            string className = "Enemy";
            enemyInfo = className + " at [" + X + ", " + Y + "] (Damage: " + Damage + ")(Health: " + this.hp + ")";
            return enemyInfo;
        }

        public override movement ReturnMovement(movement move = movement.noMvm)
        {
            throw new NotImplementedException();
        }
        public void AttackHero()
        {
            for (int i = 0; i < characterVision.GetLength(0); i++)  //checks each tile in the vision array and if it is the Hero it will attack
            {
                if (characterVision[i] is Hero)
                {
                    base.Attack((Character)characterVision[i]);
                }
            }
        }


    }
}
