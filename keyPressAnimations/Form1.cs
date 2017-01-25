using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;

//Program created by Carter Bott
//on January 11th, 2016.
//Description: A basic 2D, top-down arcade game.

namespace keyPressAnimations
{
   public partial class Form1 : Form
    {
        #region variables
        //initial starting values for Hero character
        int xHero = 100;
        int yHero = 200;
        int speedHero = 3;
        int widthHero = 40;
        int heightHero = 40;
        string heroDirection = "up";

        //initial starting values for Zombie characters
        int xZombie = 5;
        int yZombie = 5;
        int speedZombie = 1;
        int widthZombie = 40;
        int heightZombie = 40;
        string zombieDirection = "up";

        int xZombie2 = 405;
        int yZombie2 = 5;

        int xZombie3 = 205;
        int yZombie3 = 5;

        //initial starting values for bullet
        int xBullet = -1000;
        int yBullet = -1000;
        int widthBullet = 10;
        int heightBullet = 10;
        int bulletSpeed = 6;
        string bulletDirection = "up";

        //character sprites
        Image survivorimageUp = Properties.Resources.up;
        Image survivorimageLeft = Properties.Resources.left;
        Image survivorimageRight = Properties.Resources.right;
        Image survivorimageDown = Properties.Resources.down;

        Image zombieimageUp = Properties.Resources.zup;
        Image zombieimageLeft = Properties.Resources.zleft;
        Image zombieimageRight = Properties.Resources.zright;
        Image zombieimageDown = Properties.Resources.zdown;

        //sound effects
        SoundPlayer death = new SoundPlayer(Properties.Resources.death);
        SoundPlayer walking = new SoundPlayer(Properties.Resources.walking);
         
        //determines whether a key is being pressed or not - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, sArrowDown;

        //check game state
        Boolean gameOn = true;

        //create graphic objects
        SolidBrush drawBrush = new SolidBrush(Color.Red);

        #endregion
        public Form1()
        {
            InitializeComponent();
   
            //start the timer when the program starts
            gameTimer.Enabled = true;
            gameTimer.Start();

            //print title screen


        }

        public void gameStartValues()
        {
            #region reset character values
            //reset Hero values
            xHero = 100;
            yHero = 200;
            speedHero = 3;
            widthHero = 40;
            heightHero = 40;
            heroDirection = "up";

            //reset Zombie values
            xZombie = 5;
            yZombie = 5;          
            speedZombie = 1;
            widthZombie = 40;
            heightZombie = 40;
            zombieDirection = "up";

            //reset Zombie2 values
            xZombie2 = 405;
            yZombie2 = 5;

            //reset Zombie3 values
            xZombie3 = 205;
            yZombie3 = 5;

            //reset bullet value
            xBullet = -1000;
            yBullet = -1000;
            widthBullet = 10;
            heightBullet = 10;
            bulletDirection = "up";

            #endregion
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //check to see if a key is pressed and set is KeyDown value to true if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;                    
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;                 
                    break;
                case Keys.Space:
                    gameOn = true;
                    gameStartValues();
                    gameTimer.Enabled = true;
                    break;
                case Keys.S:
                    sArrowDown = true;
                    break;
                default:
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //check to see if a key has been released and set its KeyDown value to false if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.S:
                    sArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region move character based on key presses
            
            //Hero movement
            if (leftArrowDown == true && xHero > 0)
            {
                xHero = xHero - speedHero;
                heroDirection = "left";
            }

            if (downArrowDown == true && yHero < this.Height - heightHero)
            {
                yHero = yHero + speedHero;
                heroDirection = "down";
            }

            if (rightArrowDown == true && xHero < this.Width - widthHero)
            {
                xHero = xHero + speedHero;
                heroDirection = "right";
            }

            if (upArrowDown == true && yHero > 0)
            {
                yHero = yHero - speedHero;
                heroDirection = "up";
            }

            //Zombie movement
            if (xHero > xZombie)
            {
                xZombie = xZombie + speedZombie;
                zombieDirection = "right";
            }

            if (xHero < xZombie)
            {
                xZombie = xZombie - speedZombie;
                zombieDirection = "left";
            }

            if (yHero > yZombie)
            {
                yZombie = yZombie + speedZombie;
                zombieDirection = "up";
            }

            if (yHero < yZombie)
            {
                yZombie = yZombie - speedZombie;
                zombieDirection = "down";
            }

            //Zombie2 movement
            if (xHero > xZombie2)
            {
                xZombie2 = xZombie2 + speedZombie;
                zombieDirection = "right";
            }

            if (xHero < xZombie2)
            {
                xZombie2 = xZombie2 - speedZombie;
                zombieDirection = "left";
            }

            if (yHero > yZombie2)
            {
                yZombie2 = yZombie2 + speedZombie;
                zombieDirection = "up";
            }

            if (yHero < yZombie2)
            {
                yZombie2 = yZombie2 - speedZombie;
                zombieDirection = "down";
            }

            //Zombie3 movement
            if (xHero > xZombie3)
            {
                xZombie3 = xZombie3 + speedZombie;
                zombieDirection = "right";
            }

            if (xHero < xZombie3)
            {
                xZombie3 = xZombie3 - speedZombie;
                zombieDirection = "left";
            }

            if (yHero > yZombie3)
            {
                yZombie3 = yZombie3 + speedZombie;
                zombieDirection = "up";
            }

            if (yHero < yZombie3)
            {
                yZombie3 = yZombie3 - speedZombie;
                zombieDirection = "down";
            }

            //bullet fire
            if (sArrowDown == true && (xBullet > this.Width || xBullet < 0) && (yBullet > this.Height || yBullet < 0))
            {
                xBullet = xHero;
                yBullet = yHero;
                bulletDirection = heroDirection;

                if (heroDirection == "up")
                {
                    yBullet = yBullet + bulletSpeed;
                }

                if (heroDirection == "left")
                {
                    xBullet = xBullet - bulletSpeed;
                }

                if (heroDirection == "down")
                {
                    yBullet = yBullet - bulletSpeed;
                }

                if (heroDirection == "right")
                {
                    xBullet = xBullet + bulletSpeed;
                }
            }

            #endregion

            #region collision

            //rectangles to track character collision
            Rectangle heroRec = new Rectangle(xHero, yHero, widthHero, heightHero);
            Rectangle zomRec = new Rectangle(xZombie, yZombie, widthZombie, heightZombie);
            Rectangle zomRec2 = new Rectangle(xZombie2, yZombie2, widthZombie, heightZombie);
            Rectangle zomRec3 = new Rectangle(xZombie3, yZombie3, widthZombie, heightZombie);

            if (heroRec.IntersectsWith (zomRec) || heroRec.IntersectsWith(zomRec2) || heroRec.IntersectsWith(zomRec3))
            {
                death.Play();
                gameTimer.Stop();
                gameOn = false;
            }

            #endregion

            //refresh the screen, which causes the Form1_Paint method to run
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            #region character direction
            if (gameOn == true)
            {
                //draw controls
                e.Graphics.DrawString("Use arrow keys to move, S to shoot and SPACE to reset the game.", new Font("Arial", 8), new SolidBrush(Color.White),5, 325);

                //draw bullet
                e.Graphics.FillRectangle(drawBrush, xBullet, yBullet, widthBullet, heightBullet);
                //draw Hero to screen
                if (heroDirection == "up")
                {
                    e.Graphics.DrawImage(survivorimageUp, xHero, yHero, widthHero, heightHero);
                }

                if (heroDirection == "left")
                {
                    e.Graphics.DrawImage(survivorimageLeft, xHero, yHero, widthHero, heightHero);
                }

                if (heroDirection == "down")
                {
                    e.Graphics.DrawImage(survivorimageDown, xHero, yHero, widthHero, heightHero);
                }

                if (heroDirection == "right")
                {
                    e.Graphics.DrawImage(survivorimageRight, xHero, yHero, widthHero, heightHero);
                }

                //zombie direction
                if (zombieDirection == "up")
                {
                    e.Graphics.DrawImage(zombieimageUp, xZombie, yZombie, widthZombie, heightZombie);
                }

                if (zombieDirection == "left")
                {
                    e.Graphics.DrawImage(zombieimageLeft, xZombie, yZombie, widthZombie, heightZombie);
                }

                if (zombieDirection == "down")
                {
                    e.Graphics.DrawImage(zombieimageDown, xZombie, yZombie, widthZombie, heightZombie);
                }

                if (zombieDirection == "right")
                {
                    e.Graphics.DrawImage(zombieimageRight, xZombie, yZombie, widthZombie, heightZombie);
                }

                //zombie2 direction
                if (zombieDirection == "up")
                {
                    e.Graphics.DrawImage(zombieimageUp, xZombie2, yZombie2, widthZombie, heightZombie);
                }

                if (zombieDirection == "left")
                {
                    e.Graphics.DrawImage(zombieimageLeft, xZombie2, yZombie2, widthZombie, heightZombie);
                }

                if (zombieDirection == "down")
                {
                    e.Graphics.DrawImage(zombieimageDown, xZombie2, yZombie2, widthZombie, heightZombie);
                }

                if (zombieDirection == "right")
                {
                    e.Graphics.DrawImage(zombieimageRight, xZombie2, yZombie2, widthZombie, heightZombie);
                }

                //zombie3 direction
                if (zombieDirection == "up")
                {
                    e.Graphics.DrawImage(zombieimageUp, xZombie3, yZombie3, widthZombie, heightZombie);
                }

                if (zombieDirection == "left")
                {
                    e.Graphics.DrawImage(zombieimageLeft, xZombie3, yZombie3, widthZombie, heightZombie);
                }

                if (zombieDirection == "down")
                {
                    e.Graphics.DrawImage(zombieimageDown, xZombie3, yZombie3, widthZombie, heightZombie);
                }

                if (zombieDirection == "right")
                {
                    e.Graphics.DrawImage(zombieimageRight, xZombie3, yZombie3, widthZombie, heightZombie);
                }         
            }

            #endregion

            else
            {
                //display game over screen
                Thread.Sleep(1000);
                e.Graphics.DrawString("GAME OVER", new Font("DejaVu Sans", 35), new SolidBrush(Color.Red), 90, 120);
                e.Graphics.DrawString("Press Space to Play Again", new Font("DejaVu Sans", 20), new SolidBrush(Color.White), 65, 180);
            }
        }
    }

}
