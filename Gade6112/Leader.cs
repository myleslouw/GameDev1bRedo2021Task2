using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade6112
{
    [Serializable]
    class Leader : Enemy
    {
        private Tile Target;
        private int rndmEnum;
        Random rndm;
        private Weapon currentWeaponObject;


        public Leader(int _yPos, int _xPos) : base(_yPos, _xPos, 2, 20, 20, "L")
        {
            X = _xPos;
            Y = _yPos;
            MaxHP = 20;
            HP = 20;
            Damage = 2;
            Symbol = "L";

            rndm = new Random();
        }

        public override movement ReturnMovement(movement move)
        {
            //will follow player, if the players move isnt valid for the leader (noMvm) it will random a direction instead


            switch (move)
            {
                case movement.noMvm:
                    return randomDirection();

                case movement.Up:
                    if (CharacterVision[0] is EmptyTile)
                    {
                        return movement.Up;
                    }
                    else if (CharacterVision[0] is Weapon)
                    {
                        currentWeaponObject = (Weapon)CharacterVision[0];
                        Pickup(currentWeaponObject);
                        return move;
                    }
                    else
                    {
                        return randomDirection();
                    }

                case movement.Down:
                    if (CharacterVision[1] is EmptyTile)
                    {
                        return movement.Down;
                    }
                    else if (CharacterVision[1] is Weapon)
                    {
                        currentWeaponObject = (Weapon)CharacterVision[1];
                        Pickup(currentWeaponObject);
                        return move;
                    }
                    else
                    {
                        return randomDirection();
                    }

                case movement.Left:
                    if (CharacterVision[2] is EmptyTile)
                    {
                        return movement.Left;
                    }
                    else if (CharacterVision[2] is Weapon)
                    {
                        currentWeaponObject = (Weapon)CharacterVision[2];
                        Pickup(currentWeaponObject);
                        return move;
                    }
                    else
                    {
                        return randomDirection();
                    }

                case movement.Right:
                    if (CharacterVision[3] is EmptyTile)
                    {
                        return movement.Right;
                    }
                    else if (CharacterVision[3] is Weapon)
                    {
                        currentWeaponObject = (Weapon)CharacterVision[3];
                        Pickup(currentWeaponObject);
                        return move;
                    }
                    else
                    {
                        return randomDirection();
                    }

            }
            return movement.noMvm;
        }

        public movement randomDirection()
        {
            //return a random direction
            //make sure direction is valid
            rndmEnum = rndm.Next(0, 4);

            //0 = up
            //1 = down
            //2 = left
            //3 = right
            switch (rndmEnum)
            {
                case 0:                                                //if rndm num is 0, that mean it will go up, so it checks if empty, if not it will rerun the method and try again
                    if (CharacterVision[0] is EmptyTile)
                    {
                        return movement.Up;
                    }
                    else
                    {
                        return randomDirection(); 
                    }
                case 1:
                    if (CharacterVision[1] is EmptyTile)
                    {
                        return movement.Down;
                    }
                    else
                    {
                        return randomDirection();
                    }
                case 2:
                    if (CharacterVision[2] is EmptyTile)
                    {
                        return movement.Left;
                    }
                    else
                    {
                        return randomDirection();
                    }
                case 3:
                    if (CharacterVision[3] is EmptyTile)
                    {
                        return movement.Right;
                    }
                    else
                    {
                        return randomDirection();
                    }
                default:
                    return movement.noMvm;
            }
        }

        public override string ToString()
        {
            string enemyInfo;
            string className = "Leader";
            if (CurrentWeapon == null)
            {
                enemyInfo = "Barehanded: " + className + " (" + this.hp + "/" + this.maxHp + ") at [" + X + ", " + Y + "] [" + damage + " DMG]";
                return enemyInfo;
            }
            else
            {
                enemyInfo = "Equipped: " + className + " (" + this.hp + "/" + this.maxHp + ") at [" + X + ", " + Y + "] with " + CurrentWeapon.TypeString + " [" + currentWeapon.Damage + " DMG]";
                return enemyInfo;
            }
        }
    }
}
