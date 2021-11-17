using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade6112
{
    [Serializable]
    class Mage : Enemy
    {

        public Mage(int _yPos, int _xPos) : base(_yPos, _xPos, 5, 5, 5, "M")
        {
            X = _xPos;
            Y = _yPos;
            MaxHP = 5;
            Damage = 5;
            Symbol = "M";



        }
        public void AttackDiagonal()  //mages attack diagonally. they also attack goblins  (Creates an additional vision array of the diagonal spots that the mage can attack rather than in a range)
        {
            for (int i = 0; i < DiagonalTile.Length; i++)  //checks each tile in the Diaognal array and if it is the Hero/goblin it will attack
            {
                if (DiagonalTile[i] is Hero)
                {
                    try
                    {
                        base.Attack((Character)characterVision[i]);
                    }
                    catch (Exception)
                    {

                    }
                }
                if (DiagonalTile[i] is Goblin)
                {
                    try
                    {
                        base.Attack((Character)characterVision[i]);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
        public override movement ReturnMovement(movement move = movement.noMvm)
        {

            //character never moves
            return 0;
        }

        public override bool CheckRange(Character target)
        {
            //AOE attack, including diagnals

            return false;
        }
        public override string ToString()
        {
            string enemyInfo;
            string className = "Mage";

            enemyInfo = "Barehanded: " + className + " (" + this.hp + "/" + this.maxHp + ") at [" + X + ", " + Y + "] [" + damage + " DMG]";
            return enemyInfo;
        }
    }
}
