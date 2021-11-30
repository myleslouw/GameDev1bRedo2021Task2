﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade6112
{
    [Serializable]
    class Leader : Enemy
    {

        private Tile tile;

        public Tile Target    //the hero
        {
            get { return tile; }
            set { tile = value; }
        }

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
            currentWeapon = new MeleeWeapon(Y, X,  "/", MeleeWeapon.Types.Longsword);
            GoldCount = 2;

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
                        return move;
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
                        return move;
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
                        return move;
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
                        return move;
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

        public Character.movement CalculatePath(Character target, Tile[] vision)
        {
            int[] distances = new int[4];              //an array of 4 ints for the distances from each vision tile to the hero
             
            for (int i = 0; i < vision.Length; i++)    //takes each tile in vision 
            {
                Character tempSpot = (Character)vision[i];   //casts to a character to access the distanceTo method

                distances[i] = DistanceTo(target);       //adds all the distances of the vision array tiels to the hero

            }

            return LeaderDirectionParser(Lowest(distances));      //returns the direction to go for the shortest path
        }


        public int Lowest(int[] inputs)
        {
            int pos = 0;   //the position of the element in the array

            for (int i = 0; i < inputs.Length; i++)     //searches all distances
            {
                if (inputs[i] < inputs[pos])   //finds the smallest element 
                {
                    pos = i;
                }
            }
            return pos;   //returns its position in the vision array
        }

        public Character.movement LeaderDirectionParser(int index)    //changes the which tile it should move to, to a direction enum
        {
            switch (index)
            {
                case 0:

                    return movement.Up;

                case 1:

                    return movement.Down;

                case 2:

                    return movement.Left;

                case 3:

                    return movement.Right;

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
                enemyInfo = "Barehanded: " + className + " (" + this.hp + "/" + this.maxHp + " HP) at [" + X + ", " + Y + "] [" + damage + " DMG]";
                return enemyInfo;
            }
            else
            {
                enemyInfo = "Equipped: " + className + " (" + this.hp + "/" + this.maxHp + " HP) at [" + X + ", " + Y + "] with " + CurrentWeapon.weaponTypeString + " [" + currentWeapon.Damage + " DMG]";
                return enemyInfo;
            }
        }
    }
}
