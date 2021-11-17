using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade6112
{
    class GameEngine    //instructions passed from form to Here.....then sent off
    {
        private Map engineMap;

        public Map EngineMap
        {
            get { return engineMap; }
            set { engineMap = value; }
        }

        private static readonly char heroChar = 'H';
        private static readonly char goblinChar = 'G';
        private static readonly char emptyChar = '.';
        private static readonly char obstacleChar = 'X';
        private static readonly char mageChar = 'M';
        private static readonly char gold = '$';

        protected string[,] mapStringArray;
        private Tile tempTile;

        public Character currentEnemy;   //the enemy the player will attack

        SaveGameSystem SaveGameSystemObject = new SaveGameSystem(@".\SavedGameData.txt"); // class used for saving and loading files

        public Shop shopObject;



        public GameEngine(int _minHeight, int _maxHeight, int _minWidth, int _maxWidth, int _numEnemies)       //when class is created a new map is made and filled 
        {
            engineMap = new Map(_minHeight, _maxHeight, _minWidth, _maxWidth, _numEnemies, 3, 3);

            shopObject = new Shop(EngineMap.Hero);
        }

        public bool MovePlayer(Character.movement direction)  //changes pos in the Map Array
        {
            //if its true it can move so it must check if there is something there

            switch (direction)  //changes the players postions in the Tile array so it can be taken to the string array 
            {
                case Character.movement.noMvm:
                    return false;
                    break;
                case Character.movement.Up:

                    tempTile = new EmptyTile(engineMap.Hero.Y, engineMap.Hero.X, ".");  //sets a temp tile for the initial positions

                    engineMap.MapArray[engineMap.Hero.Y - 1, engineMap.Hero.X] = engineMap.MapArray[engineMap.Hero.Y, engineMap.Hero.X]; //sets teh tile at the position above the hero, to be equal to the hero (now the hero is up 1)

                    engineMap.MapArray[tempTile.Y, tempTile.X] = tempTile; //the initial hero position is now equal to an empty tile
                    engineMap.Hero.Move(direction);  //changes the players x and y values;
                    return true;
                    break;
                case Character.movement.Down:
                    tempTile = new EmptyTile(engineMap.Hero.Y, engineMap.Hero.X, ".");

                    engineMap.MapArray[engineMap.Hero.Y + 1, engineMap.Hero.X] = engineMap.MapArray[engineMap.Hero.Y, engineMap.Hero.X]; //sets teh tile at the position down the hero to be equal to the hero

                    engineMap.MapArray[tempTile.Y, tempTile.X] = tempTile;
                    engineMap.Hero.Move(direction);  //changes the players x and y values;
                    return true;
                    break;
                case Character.movement.Left:
                    tempTile = new EmptyTile(engineMap.Hero.Y, engineMap.Hero.X, ".");

                    engineMap.MapArray[engineMap.Hero.Y, engineMap.Hero.X - 1] = engineMap.MapArray[engineMap.Hero.Y, engineMap.Hero.X]; //sets teh tile at the position left the hero to be equal to the hero

                    engineMap.MapArray[tempTile.Y, tempTile.X] = tempTile;
                    engineMap.Hero.Move(direction);  //changes the players x and y values;
                    return true;
                    break;
                case Character.movement.Right:
                    tempTile = new EmptyTile(engineMap.Hero.Y, engineMap.Hero.X, ".");

                    engineMap.MapArray[engineMap.Hero.Y, engineMap.Hero.X + 1] = engineMap.MapArray[engineMap.Hero.Y, engineMap.Hero.X]; //sets teh tile at the position to the right the hero to be equal to the hero

                    engineMap.MapArray[tempTile.Y, tempTile.X] = tempTile;
                    engineMap.Hero.Move(direction);  //changes the players x and y values;
                    return true;
                    break;
                default:
                    break;
            }

            return true;
        }

        public override string ToString()   //doesnt actually use this   found in form instead
        {
            if (mapStringArray == null)  //when running multiple times, it checks to see if there is aan existing map, if there is NOT, it will make and fill else it will just fill
            {
                mapStringArray = new string[engineMap.MapHeight, engineMap.MapWidth]; //sets the length to that of the Tile array

                for (int i = 0; i < engineMap.MapArray.GetLength(0); i++)           //takes each element of the Tile array and converts it to A strign in teh mapStringArray (i think...I hope)
                {
                    for (int j = 0; j < engineMap.MapArray.GetLength(1); j++)
                    {
                        Extensions.Fill<string>(mapStringArray, engineMap.MapArray[i, j].Symbol);  //FIll is located in Extensions Class

                    }
                }
                return OrganiseMap();
            }
            else
            {

                for (int i = 0; i < engineMap.MapArray.GetLength(0); i++)           //takes each element of the Tile array and converts it to A strign in teh mapStringArray (i think...I hope)
                {
                    for (int j = 0; j < engineMap.MapArray.GetLength(1); j++)
                    {
                        Extensions.Fill<string>(mapStringArray, engineMap.MapArray[i, j].Symbol);  //FIll is located in Extensions Class

                    }
                }

                return OrganiseMap();
            }


        }

        public string OrganiseMap()
        {

            string mapString = "";

            int rowLength = mapStringArray.GetLength(0);
            int colLength = mapStringArray.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    mapString = string.Format("{0} ", mapStringArray[i, j]);        //prints out the now string array into a grid shape
                    
                }
                return Environment.NewLine + Environment.NewLine;
            }
            return mapString;

        }

        public void MoveEnemies(Character.movement direction, int positionInArray)
        {
            //if its true it can move so it must check if there is something there

            switch (direction)  //changes the enemys postions in the Tile array so it can be taken to the string array 
            {
                case Character.movement.noMvm:

                    break;
                case Character.movement.Up:

                    tempTile = new EmptyTile(engineMap.EnemiesArray[positionInArray].Y, engineMap.EnemiesArray[positionInArray].X, ".");  //sets a temp tile for the initial positions

                    engineMap.MapArray[engineMap.EnemiesArray[positionInArray].Y - 1, engineMap.EnemiesArray[positionInArray].X] = engineMap.MapArray[engineMap.EnemiesArray[positionInArray].Y, engineMap.EnemiesArray[positionInArray].X]; //sets teh tile at the position above the enemy, to be equal to the enemyS (now the enemy is up 1)

                    engineMap.MapArray[tempTile.Y, tempTile.X] = tempTile; //the initial enemy position is now equal to an empty tile
                    engineMap.EnemiesArray[positionInArray].Move(direction);  //changes the enemys x and y values;

                    break;
                case Character.movement.Down:
                    tempTile = new EmptyTile(engineMap.EnemiesArray[positionInArray].Y, engineMap.EnemiesArray[positionInArray].X, ".");

                    engineMap.MapArray[engineMap.EnemiesArray[positionInArray].Y + 1, engineMap.EnemiesArray[positionInArray].X] = engineMap.MapArray[engineMap.EnemiesArray[positionInArray].Y, engineMap.EnemiesArray[positionInArray].X]; //sets teh tile at the position down the enemy to be equal to the enemy

                    engineMap.MapArray[tempTile.Y, tempTile.X] = tempTile;
                    engineMap.EnemiesArray[positionInArray].Move(direction);  //changes the enemy x and y values;

                    break;
                case Character.movement.Left:
                    tempTile = new EmptyTile(engineMap.EnemiesArray[positionInArray].Y, engineMap.EnemiesArray[positionInArray].X, ".");

                    engineMap.MapArray[engineMap.EnemiesArray[positionInArray].Y, engineMap.EnemiesArray[positionInArray].X - 1] = engineMap.MapArray[engineMap.EnemiesArray[positionInArray].Y, engineMap.EnemiesArray[positionInArray].X]; //sets teh tile at the position left the enemy to be equal to the enemy

                    engineMap.MapArray[tempTile.Y, tempTile.X] = tempTile;
                    engineMap.EnemiesArray[positionInArray].Move(direction);  //changes the enemy x and y values;

                    break;
                case Character.movement.Right:
                    tempTile = new EmptyTile(engineMap.EnemiesArray[positionInArray].Y, engineMap.EnemiesArray[positionInArray].X, ".");

                    engineMap.MapArray[engineMap.EnemiesArray[positionInArray].Y, engineMap.EnemiesArray[positionInArray].X + 1] = engineMap.MapArray[engineMap.EnemiesArray[positionInArray].Y, engineMap.EnemiesArray[positionInArray].X]; //sets teh tile at the position to the right the enemy to be equal to the enemy

                    engineMap.MapArray[tempTile.Y, tempTile.X] = tempTile;
                    engineMap.EnemiesArray[positionInArray].Move(direction);  //changes the enemy x and y values;

                    break;
                default:
                    break;
            }
        }

        public void SaveGame()
        {
            SaveGameSystemObject.SerializeObject(engineMap);  //sends the map to be seriealized and closes the stream
            SaveGameSystemObject.CloseStream();
        }

        public Map LoadGame()
        {
            return (Map)SaveGameSystemObject.DeserialiseObject();  //returns a map object that will be made into the game map in FOrm
        }

    }
}

