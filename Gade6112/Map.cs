using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography; //used for non repetitive number generation

namespace Gade6112
{
    [Serializable]
    class Map
    {
        private Tile[,] mapArray;

        public Tile[,] MapArray
        {
            get { return mapArray; }
            set { mapArray = value; }
        }

        private Hero hero;

        public Hero Hero
        {
            get { return hero; }
            set { hero = value; }
        }

        private Enemy[] enemies;

        public Enemy[] EnemiesArray
        {
            get { return enemies; }
            set { enemies = value; }
        }

        private int mapHeight;

        public int MapHeight
        {
            get { return mapHeight; }
            set { mapHeight = value; }
        }

        private int mapWidth;

        public int MapWidth
        {
            get { return mapWidth; }
            set { mapWidth = value; }
        }

        private static List<Tuple<int, int>> alreadyUsedPositions = new List<Tuple<int, int>>(); //a list of positions so no repeats
        Tuple<int, int> checkingTuple;

        Random rndm = new Random();

        private enum enemyType { _goblin, mage }

        private Item[] itemArray;

        public Item[] ItemArray
        {
            get { return itemArray; }
            set { itemArray = value; }
        }   //holds all items (gold and weapons)

        private int positionWidth, positionHeight;
        private static bool positionTaken;
        public int count;
        int itemRandomizer;




        public Map(int minHeight, int maxHeight, int minWidth, int maxWidth, int numEnemies, int numGoldDrops, int WeaponDrops)
        {
            mapHeight = rndm.Next(minHeight, maxHeight);
            mapWidth = rndm.Next(minWidth, maxWidth);

            mapArray = new Tile[mapHeight, mapWidth];


            for (int i = 0; i < mapArray.GetLength(0); i++)
            {
                for (int j = 0; j < mapArray.GetLength(1); j++)
                {
                    mapArray[i, j] = new EmptyTile(i, j, ".");         //makes all the tiles empty  
                }
            }
            ObstacleBoundary();   //creates the boundary around map


            enemies = new Enemy[numEnemies];  //2 for now?? could change later?



            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = Create(Tile.TileType.Enemy) as Enemy;   //looops through the amount of enemies and creates them
            }

            ItemArray = new Item[numGoldDrops + WeaponDrops]; //creates the array of items to the same amount of items that will be spawned

            for (int i = 0; i < ItemArray.GetLength(0); i++)
            {
                itemRandomizer = rndm.Next(0, 2);   //randoms whether to spawn gold or weapaon

                if (itemRandomizer == 0)  //if 0 it will create gold
                {
                    ItemArray[i] = Create(Tile.TileType.Gold) as Gold;
                }
                else  //creates a random weapon
                {
                    itemArray[i] = Create(Tile.TileType.Weapon) as Weapon;
                }

            }

            Hero = Create(Tile.TileType.Hero) as Hero;   //creates the hero

            UpdateVision();
            alreadyUsedPositions.Add(new Tuple<int, int>(0, 0)); //put 1 item in list at start
        }

        public void UpdateVision()
        {
            //Gets the tile to the N,S,E,W of the hero and enemies and saves it in the character array
            //0 = up
            //1 = down
            //2 = left
            //3 = right

            //hero vision
            for (int i = 0; i < hero.CharacterVision.Length; i++)  //nulls tehem initally
            {
                hero.CharacterVision[i] = null;
            }
            hero.CharacterVision[0] = mapArray[hero.Y - 1, hero.X];
            hero.CharacterVision[1] = mapArray[hero.Y + 1, hero.X];
            hero.CharacterVision[2] = mapArray[hero.Y, hero.X - 1];
            hero.CharacterVision[3] = mapArray[hero.Y, hero.X + 1];

            for (int i = 0; i < EnemiesArray.GetLength(0); i++)  //all enemy vision
            {
                if (EnemiesArray[i] is Goblin)   //goblin vision
                {
                    for (int j = 0; j < EnemiesArray[i].CharacterVision.Length; j++)  //nulls themm initally
                    {
                        EnemiesArray[i].CharacterVision[j] = null;
                    }
                    EnemiesArray[i].CharacterVision[0] = mapArray[EnemiesArray[i].Y - 1, EnemiesArray[i].X];
                    EnemiesArray[i].CharacterVision[1] = mapArray[EnemiesArray[i].Y + 1, EnemiesArray[i].X];
                    EnemiesArray[i].CharacterVision[2] = mapArray[EnemiesArray[i].Y, EnemiesArray[i].X - 1];
                    EnemiesArray[i].CharacterVision[3] = mapArray[EnemiesArray[i].Y, EnemiesArray[i].X + 1];
                }
                if (EnemiesArray[i] is Mage)  //mages (diagonals included)
                {
                    for (int j = 0; j < EnemiesArray[i].CharacterVision.Length; j++)  //nulls themm initally
                    {
                        EnemiesArray[i].CharacterVision[j] = null;
                    }
                    EnemiesArray[i].CharacterVision[0] = mapArray[EnemiesArray[i].Y - 1, EnemiesArray[i].X];
                    EnemiesArray[i].CharacterVision[1] = mapArray[EnemiesArray[i].Y + 1, EnemiesArray[i].X];
                    EnemiesArray[i].CharacterVision[2] = mapArray[EnemiesArray[i].Y, EnemiesArray[i].X - 1];
                    EnemiesArray[i].CharacterVision[3] = mapArray[EnemiesArray[i].Y, EnemiesArray[i].X + 1];

                    EnemiesArray[i].DiagonalTile[0] = mapArray[EnemiesArray[i].Y - 1, EnemiesArray[i].X - 1];   //NW
                    EnemiesArray[i].DiagonalTile[1] = mapArray[EnemiesArray[i].Y - 1, EnemiesArray[i].X + 1];   //NE
                    EnemiesArray[i].DiagonalTile[2] = mapArray[EnemiesArray[i].Y + 1, EnemiesArray[i].X - 1];   //SW
                    EnemiesArray[i].DiagonalTile[3] = mapArray[EnemiesArray[i].Y + 1, EnemiesArray[i].X + 1];   //SE
                }

                if (EnemiesArray[i] is Leader)
                {
                    for (int j = 0; j < EnemiesArray[i].CharacterVision.Length; j++)  //nulls themm initally
                    {
                        EnemiesArray[i].CharacterVision[j] = null;
                    }
                    EnemiesArray[i].CharacterVision[0] = mapArray[EnemiesArray[i].Y - 1, EnemiesArray[i].X];
                    EnemiesArray[i].CharacterVision[1] = mapArray[EnemiesArray[i].Y + 1, EnemiesArray[i].X];
                    EnemiesArray[i].CharacterVision[2] = mapArray[EnemiesArray[i].Y, EnemiesArray[i].X - 1];
                    EnemiesArray[i].CharacterVision[3] = mapArray[EnemiesArray[i].Y, EnemiesArray[i].X + 1];
                }
            }

        }

        private Tile Create(Tile.TileType tileType)
        {
            RandomPosition();


            switch (tileType)
            {
                case Tile.TileType.Hero:    //***used at the start***
                    Hero = new Hero(positionWidth, positionHeight, 100);   //creates a hero at the random coordinates 
                    mapArray[positionHeight, positionWidth] = hero;
                    return Hero;
                case Tile.TileType.Enemy:
                    //will spawn either a goblin or mage
                    Tile newTile = EnemyRandomizer(positionHeight, positionWidth);  //Enemyrandomizer will random between Goblin or mage and create it   
                    mapArray[positionHeight, positionWidth] = newTile;
                    return newTile;
                    break;

                case Tile.TileType.Gold:
                    Tile goldTile = new Gold(positionHeight, positionWidth, "$");   //places gold
                    mapArray[positionHeight, positionWidth] = goldTile;
                    return goldTile;
                    break;
                case Tile.TileType.Weapon:
                    Tile weaponTile = RandomWeapon(positionWidth, positionHeight);   //empty for now will add Weapon
                    mapArray[positionHeight, positionWidth] = weaponTile;
                    return weaponTile;
                    break;
                default:
                    return null;
                    break;
            }
        }

        public void ObstacleBoundary()    //creates the X's around the map
        {
            int colLength = mapArray.GetLength(0);
            int rowLength = mapArray.GetLength(1);

            for (int i = 0; i < colLength; i++)  //used for surrounding with obstaces
            {
                for (int j = 0; j < rowLength; j++)
                {
                    mapArray[0, j] = new Obstacle(i, j, "X");
                    mapArray[i, 0] = new Obstacle(i, j, "X");

                }
            }
            for (int i = 0; i < colLength; i++)  //used for surrounding with obstaces
            {
                for (int j = 0; j < rowLength; j++)
                {

                    mapArray[colLength - 1, j] = new Obstacle(i, j, "X");
                    mapArray[i, rowLength - 1] = new Obstacle(i, j, "X");

                }
            }

        }

        public Enemy EnemyRandomizer(int posWidth, int posHeight)
        {
            int enemyRandom = rndm.Next(1, 4);  //randoms between goblin and mage

            switch (enemyRandom)
            {
                case 1:
                    return new Goblin(posWidth, posHeight);

                case 2:
                    return new Mage(posWidth, posHeight);

                case 3:
                    return new Leader(posWidth, posHeight);

            }
            return null;

        }

        

        public Weapon RandomWeapon( int posWidth, int posHeight)
        {
            int weaponDecider = rndm.Next(0,4);
            if (weaponDecider == 0)
            {
                return new MeleeWeapon(posWidth, posHeight, "-",  MeleeWeapon.Types.Dagger) ;   //if the random item num was 0 it will create a dagger
            }
            if (weaponDecider == 1)
            {
                return new MeleeWeapon(posWidth, posHeight, "/", MeleeWeapon.Types.Longsword);   //if the random item num was 1 it will create a longsword
            }
            if (weaponDecider == 2)
            {
                return new RangedWeapon(posWidth, posHeight, "^", RangedWeapon.Types.Longbow);   //if the random item num was 2 it will create a longbow
            }
            else
            {
                return new RangedWeapon(posWidth, posHeight, "*", RangedWeapon.Types.Rifle);   //if the random item num was 3 it will create a rifle;
            }
        }
        public void RandomPosition()
        {
            positionHeight = rndm.Next(1, mapHeight - 2);//gets random number place (excludes the XXXX surroundings)
            positionWidth = rndm.Next(1, mapWidth - 2);

            GetNonRepeatRandom(positionWidth, positionHeight);


            if (positionTaken)  //if the pos has been used, it wil reroll a spot
            {
                count += 100;
                RandomPosition();
            }
            else
            {
                alreadyUsedPositions.Add(new Tuple<int, int>(positionWidth, positionHeight)); //other wise it will add it to the list of spots that have been used and the method will continue
                count--;
            }

        }
        public void GetNonRepeatRandom(int posWidth, int posHeight)
        {
            checkingTuple = new Tuple<int, int>(posWidth, posHeight); //creates a tuple of that position to check if it has been used

            if (alreadyUsedPositions.Contains(checkingTuple))
            {
                positionTaken = true;
            }
            else
            {
                positionTaken = false;
            }

            //foreach (Tuple<int, int> position in alreadyUsedPositions)   //looks at all the tuples in the lis
            //{
            //    if (position == checkingTuple)  //if any of the positions in the list are equal to the checking one it will have to change it
            //    {
            //        positionTaken = true;  //means position has been used
            //    }
            //    else
            //    { 
            //        positionTaken = false;
            //    }

            //}

        }
    }
}
