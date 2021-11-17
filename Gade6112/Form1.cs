using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gade6112
{
    public partial class Form1 : Form
    {

        GameEngine gameEngine;
        public int MinHeight;
        public int MaxHeight;
        public int MaxWidth;
        public int MinWidth;
        public int NumEnemies;


        int count;

        Character.movement leaderMovement; //used to save player movement to then be copied by the laeder 

        public Form1()
        {
            InitializeComponent();
            btn_Start.Visible = true;

        }

        private void btn_Start_Click(object sender, EventArgs e)    //starts the game once inputs are all there
        {
            MessageBox.Show("Players Start with 5 Gold \nEnemies are designed to move after 0,5 seconds after player move to look more like a game");

            gameEngine = new GameEngine(8, 12, 8, 12, 3);     //creates a game engine and gives it params to make the map

            DisplayMap();

            btn_Start.Visible = false;

            //fills the buttons in the shop with their items names
            btn_shopItem1.Text = gameEngine.shopObject.DisplayWeapon(0);
            btn_shopItem2.Text = gameEngine.shopObject.DisplayWeapon(1);
            btn_shopItem3.Text = gameEngine.shopObject.DisplayWeapon(2);
        }
        public void DisplayMap() //main Display method
        {
            if (gameEngine.EngineMap.Hero.isDead())
            {
                MessageBox.Show("Player has died");
                Application.Exit();
            }

            lbl_GameScreen.Text = "";  //erases it so it can be called with up to date values each time

            int rowLength = gameEngine.EngineMap.MapArray.GetLength(0);   //gets lengths of the array
            int colLength = gameEngine.EngineMap.MapArray.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    lbl_GameScreen.Text += string.Format("{0} ", gameEngine.EngineMap.MapArray[i, j].Symbol);        //prints out each tiles symbol element that is now a string array into a grid shape
                }
                lbl_GameScreen.Text += Environment.NewLine + Environment.NewLine;
            }

            lb_UpdateScreen.Items.Clear();   //clears the listbox every turn
            lbl_EnemiesList.Text = "";

            for (int i = 0; i < gameEngine.EngineMap.EnemiesArray.GetLength(0); i++)
            {
                lbl_EnemiesList.Text += gameEngine.EngineMap.EnemiesArray[i] + "\n";
            }

            lbl_PlayerStats.Text = gameEngine.EngineMap.Hero.ToString();   //shows the player stats

            //anything to extra here
            gameEngine.EngineMap.UpdateVision();  //updates the vision everytime the map is reloaded
            checkSurroundings();

        }

        public void checkSurroundings()     //Displays the tiles in the heros vision array in the listbox
        {


            foreach (Tile tile in gameEngine.EngineMap.Hero.CharacterVision)  //searches all tiels in vision
            {

                lb_UpdateScreen.Items.Add(" " + tile.ToString());  //show it on the screen

            }
        }

        public async void waitForEnemyTurn()  //waits half a second before the enemy turn to make it look better while playing
        {
            await Task.Delay(500);         //method taken from https://stackoverflow.com/questions/23250224/windows-forms-wait-5-seconds-before-displaying-a-message
            EnemyTurn();
        }

        public void EnemyTurn()          //every "round" (after player input) the enemies will be moved and attack if necessary
        {
            for (int i = 0; i < gameEngine.EngineMap.EnemiesArray.GetLength(0); i++)
            {


                if (gameEngine.EngineMap.EnemiesArray[i] is Goblin)
                {
                    gameEngine.MoveEnemies(gameEngine.EngineMap.EnemiesArray[i].ReturnMovement(), i);  //goes to game engine to chenge their pos in the map array
                    Goblin tempGoblin = (Goblin)gameEngine.EngineMap.EnemiesArray[i];
                    tempGoblin.AttackHero();
                }
                if (gameEngine.EngineMap.EnemiesArray[i] is Mage)
                {
                    gameEngine.MoveEnemies(gameEngine.EngineMap.EnemiesArray[i].ReturnMovement(), i);  //goes to game engine to chenge their pos in the map array (will do return noMvm as mages dont move)
                    Mage tempMage = (Mage)gameEngine.EngineMap.EnemiesArray[i]; //cast to mage in order to be able to attack
                    tempMage.AttackHero(); //attacks normal vision
                    tempMage.AttackDiagonal(); //attacks diagonal
                }
                if (gameEngine.EngineMap.EnemiesArray[i] is Leader)
                {
                    gameEngine.MoveEnemies(gameEngine.EngineMap.EnemiesArray[i].ReturnMovement(leaderMovement), i);   //goes to the game engine to change the pos which goes in the same direction as the hero movement
                    Leader tempLeader = (Leader)gameEngine.EngineMap.EnemiesArray[i];   //casts to leader in order to attack
                    tempLeader.AttackHero();  //attacks the hero if in range
                }
            }

            DisplayMap();  //after all moves and attacks it updates the map
        }


        //BUttons

        private void btn_Up_Click(object sender, EventArgs e)
        {

            gameEngine.MovePlayer(gameEngine.EngineMap.Hero.ReturnMovement(Character.movement.Up));     //movement is sent to hero ReturnMovement, it checks if valid, returns a movement and sent to the game engine MovePlayer which will move player and chenge its x and y pos
            rtb_HitAlert.Text = "";   //once moved it will reset the box that says if there was a hit
            leaderMovement = Character.movement.Up;
            DisplayMap();
            waitForEnemyTurn();

        }

        private void btn_Right_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(gameEngine.EngineMap.Hero.ReturnMovement(Character.movement.Right));
            rtb_HitAlert.Text = "";
            leaderMovement = Character.movement.Right;
            DisplayMap();
            waitForEnemyTurn();
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(gameEngine.EngineMap.Hero.ReturnMovement(Character.movement.Left));
            rtb_HitAlert.Text = "";
            leaderMovement = Character.movement.Left;
            DisplayMap();
            waitForEnemyTurn();
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(gameEngine.EngineMap.Hero.ReturnMovement(Character.movement.Down));
            rtb_HitAlert.Text = "";
            leaderMovement = Character.movement.Down;
            DisplayMap();
            waitForEnemyTurn();
        }

        private void btn_Attack_Click(object sender, EventArgs e)
        {
            if (lb_UpdateScreen.SelectedIndex == -1)   //if nothing is selected from the Listbox
            {
                lb_UpdateScreen.Items.Add("Please select an enemy to attack ^^");
            }
            else
            {
                rtb_HitAlert.Text = "Enemy Hit!";
                //attack logic
                //casts the tile in the vision array that the player will attack to a character so it can then be sent to Attack to do damage
                gameEngine.EngineMap.Hero.Attack((Character)gameEngine.EngineMap.MapArray[gameEngine.EngineMap.Hero.CharacterVision[lb_UpdateScreen.SelectedIndex].Y, gameEngine.EngineMap.Hero.CharacterVision[lb_UpdateScreen.SelectedIndex].X]);
                gameEngine.currentEnemy = (Character)gameEngine.EngineMap.MapArray[gameEngine.EngineMap.Hero.CharacterVision[lb_UpdateScreen.SelectedIndex].Y, gameEngine.EngineMap.Hero.CharacterVision[lb_UpdateScreen.SelectedIndex].X]; //saves the enemy to attack as a vairable

                if (gameEngine.currentEnemy.isDead())  //if the health of the attacked player gets to 0 or below it will replace the enemy with an empty tile
                {
                    //gameEngine.EngineMap.MapArray[gameEngine.EngineMap.Hero.CharacterVision[lb_UpdateScreen.SelectedIndex].Y, gameEngine.EngineMap.Hero.CharacterVision[lb_UpdateScreen.SelectedIndex].X] = null;
                    gameEngine.EngineMap.MapArray[gameEngine.EngineMap.Hero.CharacterVision[lb_UpdateScreen.SelectedIndex].Y, gameEngine.EngineMap.Hero.CharacterVision[lb_UpdateScreen.SelectedIndex].X] = new EmptyTile(gameEngine.EngineMap.Hero.CharacterVision[lb_UpdateScreen.SelectedIndex].X, gameEngine.EngineMap.Hero.CharacterVision[lb_UpdateScreen.SelectedIndex].Y, ".");
                }
                DisplayMap();

            }
            waitForEnemyTurn();
        }


        private void btn_Save_Click(object sender, EventArgs e)
        {
            gameEngine.SaveGame(); // will run the save game method in game engine which will save to binary
            MessageBox.Show("Game Saved!");

        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            gameEngine.EngineMap = gameEngine.LoadGame(); //the current map being used will be set the one loaded from the file
            MessageBox.Show("Previous Save Loaded! Please click Ok");  //notif of completion
            DisplayMap();  //displays the loaded map
        }

        public async void BuyAnimation(Button btn ,int num)   //button says purchased and then shows the next item after 1 second
        {
            btn.Text = "Purchased!";
            await Task.Delay(1000);
            btn.Text = gameEngine.shopObject.DisplayWeapon(num);
        }
        public async void FailedBuyAnimation(Button btn, int num)
        {
            btn.Text = "Not Enough Gold";
            await Task.Delay(1000);
            btn.Text = gameEngine.shopObject.DisplayWeapon(num);
        }

        private void btn_shopItem1_Click(object sender, EventArgs e)
        {
            if (gameEngine.shopObject.CanBuy(0))  //if the player has enough to buy the 1st weapon
            {
                gameEngine.shopObject.Buy(0);  //buy the weapon and equips it
                BuyAnimation(btn_shopItem1, 0);
                DisplayMap();
            }
            else
            {
                FailedBuyAnimation(btn_shopItem1, 0);
            }
        }

        private void btn_shopItem2_Click(object sender, EventArgs e)
        {
            if (gameEngine.shopObject.CanBuy(1))  //if the player has enough to buy the 2nd weapon
            {
                gameEngine.shopObject.Buy(1);  //buy the weapon and equips it
                BuyAnimation(btn_shopItem2, 1);
                DisplayMap();
            }
            else
            {
                FailedBuyAnimation(btn_shopItem2, 1);
            }
        }

        private void btn_shopItem3_Click(object sender, EventArgs e)
        {
            if (gameEngine.shopObject.CanBuy(2))  //if the player has enough to buy the 3rd weapon
            {
                gameEngine.shopObject.Buy(2);  //buy the weapon and equips it
                BuyAnimation(btn_shopItem3, 2);
                DisplayMap();
            }
            else
            {
                FailedBuyAnimation(btn_shopItem3, 2);
            }
        }
    }
}
