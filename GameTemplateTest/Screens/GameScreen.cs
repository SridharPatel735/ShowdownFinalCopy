using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using GameSystemServices;
using System.Diagnostics;
using GameTemplateTest;
using System.Media;
/// <summary>
/// Created by Sridhar, Calem, and Sammy
/// January 2020
/// We created a game using a game loop, this game brings everything we have learned in class all together.
/// </summary>

namespace GravityTest
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        //player2 button control keys - DO NOT CHANGE
        //Creating the boolean
        Boolean aDown, sDown, dDown, wDown, cDown, vDown, xDown, zDown;
        Boolean isJumping = false;
        Boolean isJumping2 = false;
        Boolean shot2 = false;
        Boolean shot = false;

        //Creating the stopwatch
        Stopwatch reloadWatch2 = new Stopwatch();
        Stopwatch bulletDelayWatch2 = new Stopwatch();
        Stopwatch reloadWatch = new Stopwatch();
        Stopwatch bulletDelayWatch = new Stopwatch();

        //Creating the varibles for the heros
        int bulletX2, bulletY2, hero2Health, bullets2, heroX2, heroY2, bulletSpeed2;
        string direction2 = "left";
        int jumpCounter2 = -1;
        int jumpCounter = -1;
        string direction = "right";
        SoundPlayer hitSound = new SoundPlayer(GameTemplateTest.Properties.Resources.MaleGrunt);
        SoundPlayer bulletSound = new SoundPlayer(GameTemplateTest.Properties.Resources.gunshot);
        int heroX, heroY, heroWidth, heroSpeed, jumpHeight, bulletX, bulletY, bulletSpeed, bullets, heroHealth;


        public GameScreen()
        {
            InitializeComponent();
            InitializeGameValues();
        }

        public void InitializeGameValues()
        {
            //TODO - setup all your initial game values here. Use this method
            // each time you restart your game to reset all values.
            heroX = 0;
            heroY = 419;
            heroWidth = 100;
            heroSpeed = 10;
            jumpHeight = 20;
            bulletSpeed = 25;
            bulletX = this.Width;
            bulletY = this.Height;
            bullets = 30;
            bulletDelayWatch.Start();
            heroHealth = 5;
            hero2Health = 5;
            heroX2 = 1553;
            heroY2 = 419;
            bullets2 = 30;
            bulletDelayWatch2.Start();
            bulletSpeed2 = -25;
            heroBox.BackgroundImage = DifficultySetting.player1[1];
            heroBox2.BackgroundImage = DifficultySetting.player2[0];
            if (DifficultySetting.color == true)
            {
                bulletLabel.ForeColor = Color.Red;
                bulletCount.ForeColor = Color.Red;
                healthCount.ForeColor = Color.Red;
                healthLabel.ForeColor = Color.Red;

                bulletLabel2.ForeColor = Color.DarkBlue;
                bulletCount2.ForeColor = Color.DarkBlue;
                healthCount2.ForeColor = Color.DarkBlue;
                healthLabel2.ForeColor = Color.DarkBlue;
            }
            else
            {
                bulletLabel2.ForeColor = Color.Red;
                bulletCount2.ForeColor = Color.Red;
                healthCount2.ForeColor = Color.Red;
                healthLabel2.ForeColor = Color.Red;

                bulletLabel.ForeColor = Color.DarkBlue;
                bulletCount.ForeColor = Color.DarkBlue;
                healthCount.ForeColor = Color.DarkBlue;
                healthLabel.ForeColor = Color.DarkBlue;
            }
            Thread.Sleep(5000);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // opens a pause screen is escape is pressed. Depending on what is pressed
            // on pause screen the program will either continue or exit to main menu
            if (e.KeyCode == Keys.Escape && gameTimer.Enabled)
            {
                gameTimer.Enabled = false;
                rightArrowDown = leftArrowDown = upArrowDown = downArrowDown = false;

                DialogResult result = PauseForm.Show();

                if (result == DialogResult.Cancel)
                {
                    gameTimer.Enabled = true;
                }
                else if (result == DialogResult.Abort)
                {
                    MainForm.ChangeScreen(this, "MenuScreen");
                }
            }

            //TODO - basic player 1 key down bools set below. Add remainging key down
            // required for player 1 or player 2 here.

            //player 1 & 2 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    if (isJumping == false)
                    {
                        isJumping = true;
                    }
                    break;
                case Keys.Space:
                    spaceDown = true;
                    if (bulletDelayWatch.ElapsedMilliseconds >= 1900)
                    {
                        shot = true;
                        bulletDelayWatch.Stop();
                        bulletDelayWatch.Reset();
                    }
                    break;
                case Keys.M:
                    mDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    if (isJumping2 == false)
                    {
                        isJumping2 = true;
                    }
                    break;
                case Keys.C:
                    cDown = true;
                    if (bulletDelayWatch2.ElapsedMilliseconds >= 1900)
                    {
                        shot2 = true;
                        bulletDelayWatch2.Stop();
                        bulletDelayWatch2.Reset();
                    }
                    break;
                case Keys.V:
                    vDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //TODO - basic player 1 key up bools set below. Add remainging key up
            // required for player 1 or player 2 here.

            //player 1 & 2 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                case Keys.M:
                    mDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.C:
                    cDown = false;
                    break;
                case Keys.V:
                    vDown = false;
                    break;
            }
        }

        /// <summary>
        /// This is the Game Engine and repeats on each interval of the timer. For example
        /// if the interval is set to 16 then it will run each 16ms or approx. 50 times
        /// per second
        /// </summary>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Game Loop
            MoveHero();
            JumpHero();
            BulletMechanics();
            CollisionCheck();
            HeroHealthCheck();
            Refresh();
        }

        public void MoveHero()
        {
            //Moving the Heros
            if (leftArrowDown == true && heroX >= 0)
            {
                direction = "left";
                heroX = heroX - heroSpeed;
                heroBox.BackgroundImage = DifficultySetting.player1[0];
            }

            if (rightArrowDown == true && heroX <= this.Width - heroWidth)
            {
                direction = "right";
                heroX = heroX + heroSpeed;
                heroBox.BackgroundImage = DifficultySetting.player1[1];
            }
            heroBox.Location = new Point(heroX, heroY);

            if (aDown == true && heroX2 >= 0)
            {
                direction2 = "left";
                heroX2 = heroX2 - heroSpeed;
                heroBox2.BackgroundImage = DifficultySetting.player2[0];
            }

            if (dDown == true && heroX2 <= this.Width - heroWidth)
            {
                direction2 = "right";
                heroX2 = heroX2 + heroSpeed;
                heroBox2.BackgroundImage = DifficultySetting.player2[1];
            }
            heroBox2.Location = new Point(heroX2, heroY2);
        }
        public void JumpHero()
        {
            //Junping mechanics
            if (heroY >= 65 && isJumping == true)
            {
                jumpCounter++;
                if (jumpCounter < 10)
                {
                    heroY = heroY - jumpHeight;
                    if (leftArrowDown == true && heroX >= 0)
                    {
                        direction = "left";
                        heroX = heroX - heroSpeed;
                        heroBox.BackgroundImage = DifficultySetting.player1[0];
                    }

                    if (rightArrowDown == true && heroX <= this.Width - heroWidth)
                    {
                        direction = "right";
                        heroX = heroX + heroSpeed;
                        heroBox.BackgroundImage = DifficultySetting.player1[1];
                    }
                    heroBox.Location = new Point(heroX, heroY);

                }
                else if (jumpCounter >= 10 && jumpCounter < 20)
                {
                    heroY = heroY + jumpHeight;
                    if (leftArrowDown == true && heroX >= 0)
                    {
                        direction = "left";
                        heroX = heroX - heroSpeed;
                        heroBox.BackgroundImage = DifficultySetting.player1[0];
                    }

                    if (rightArrowDown == true && heroX <= this.Width - heroWidth)
                    {
                        direction = "right";
                        heroX = heroX + heroSpeed;
                        heroBox.BackgroundImage = DifficultySetting.player1[1];
                    }
                    heroBox.Location = new Point(heroX, heroY);
                }
                else if (jumpCounter == 20)
                {
                    jumpCounter = -1;
                    heroY = 419;
                    isJumping = false;
                }
            }
            if (heroY2 >= 65 && isJumping2 == true)
            {
                jumpCounter2++;
                if (jumpCounter2 < 10)
                {
                    heroY2 = heroY2 - jumpHeight;
                    if (aDown == true && heroX2 >= 0)
                    {
                        direction2 = "left";
                        heroX2 = heroX2 - heroSpeed;
                        heroBox2.BackgroundImage = DifficultySetting.player2[0];
                    }

                    if (dDown == true && heroX2 <= this.Width - heroWidth)
                    {
                        direction2 = "right";
                        heroX2 = heroX2 + heroSpeed;
                        heroBox2.BackgroundImage = DifficultySetting.player2[1];
                    }
                    heroBox2.Location = new Point(heroX2, heroY2);

                }
                else if (jumpCounter2 >= 10 && jumpCounter2 < 20)
                {
                    heroY2 = heroY2 + jumpHeight;
                    if (aDown == true && heroX >= 0)
                    {
                        direction2 = "left";
                        heroX2 = heroX2 - heroSpeed;
                        heroBox2.BackgroundImage = DifficultySetting.player2[0];
                    }

                    if (dDown == true && heroX2 <= this.Width - heroWidth)
                    {
                        direction2 = "right";
                        heroX2 = heroX2 + heroSpeed;
                        heroBox2.BackgroundImage = DifficultySetting.player2[1];
                    }
                    heroBox2.Location = new Point(heroX2, heroY2);
                }
                else if (jumpCounter2 == 20)
                {
                    jumpCounter2 = -1;
                    heroY2 = 419;
                    isJumping2 = false;
                }
            }
        }

        public void BulletMechanics()
        {
            if (heroX == heroX2)
            {
                shot = false;
                shot2 = false;
            }
            if (heroX == heroX2 - 100)
            {
                shot = false;
                shot2 = false;
            }
            if (heroX2 == heroX - 100)
            {
                shot = false;
                shot2 = false;
            }
            //bullet mechanics
            if (shot == true && bullets != 0)
            {
                shot = false;
                bulletSound.Play();
                if (direction == "right")
                {
                    bulletX = heroX + 75;
                    bulletY = heroY + 75;
                    bullets--;
                    bulletLabel.Text = bullets + "";
                    bulletSpeed = 25;
                }
                else
                {
                    bulletX = heroX;
                    bulletY = heroY + 75;
                    bullets--;
                    bulletLabel.Text = bullets + "";
                    bulletSpeed = -25;
                }
                bulletDelayWatch.Start();
            }

            bulletX = bulletX + bulletSpeed;
            bulletBox.Location = new Point(bulletX, bulletY);

            if (bullets < 30 && mDown == true)
            {
                reloadWatch.Start();
            }

            if (reloadWatch.ElapsedMilliseconds >= 1000)
            {
                reloadWatch.Stop();
                bullets = 30;
                bulletLabel.Text = bullets + "";
                reloadWatch.Reset();
            }
            //bullet mechanics
            if (shot2 == true && bullets2 != 0)
            {
                shot2 = false;
                bulletSound.Play();
                if (direction2 == "right")
                {
                    bulletX2 = heroX2 + 75;
                    bulletY2 = heroY2 + 75;
                    bullets2--;
                    bulletLabel2.Text = bullets2 + "";
                    bulletSpeed2 = 25;
                }
                else
                {
                    bulletX2 = heroX2;
                    bulletY2 = heroY2 + 75;
                    bullets2--;
                    bulletLabel2.Text = bullets2 + "";
                    bulletSpeed2 = -25;
                }
                bulletDelayWatch2.Start();
            }

            bulletX2 = bulletX2 + bulletSpeed2;
            bulletBox2.Location = new Point(bulletX2, bulletY2);

            if (bullets2 < 30 && vDown == true)
            {
                reloadWatch2.Start();
            }

            if (reloadWatch2.ElapsedMilliseconds >= 1000)
            {
                reloadWatch2.Stop();
                bullets2 = 30;
                bulletLabel2.Text = bullets2 + "";
                reloadWatch2.Reset();
            }
        }
        public void CollisionCheck()
        {
            //Checking the collisons
            if (heroBox.Bounds.IntersectsWith(bulletBox2.Bounds))
            {
                hitSound.Play();
                heroHealth--;
                healthLabel.Text = heroHealth + "";
                if (direction2 == "left")
                {
                    bulletX2 = -19;
                }
                else
                {
                    bulletX2 = this.Width + 19;
                }
            }
            if (heroBox2.Bounds.IntersectsWith(bulletBox.Bounds))
            {
                hitSound.Play();
                hero2Health--;
                healthLabel2.Text = hero2Health + "";
                if (direction == "left")
                {
                    bulletX = this.Width + 19;
                }
                else
                {
                    bulletX = -19;
                }
            }
        }

        public void HeroHealthCheck()
        {
            //Checks the hero's health
            if (heroHealth <= 0)
            {
                youDiedLabel.Visible = true;
                bulletCount.Visible = false;
                bulletLabel.Visible = false;
                healthCount.Visible = false;
                healthLabel.Visible = false;
                healthCount2.Visible = false;
                healthLabel2.Visible = false;
                bulletLabel2.Visible = false;
                bulletCount2.Visible = false;
                if (direction == "left")
                {
                    heroBox.BackgroundImage = GameTemplateTest.Properties.Resources.marco_dead_Right;
                }
                else
                {
                    heroBox.BackgroundImage = GameTemplateTest.Properties.Resources.marco_dead_Left;
                }
                healthLabel.Text = heroHealth + "";
                deathLabel.Visible = true;
                for (int i = 0; i <= 256; i = i + 5)
                {
                    deathLabel.BackColor = Color.FromArgb(i, 0, 0, 0);
                    youDiedLabel.ForeColor = Color.FromArgb(i, 255, 0, 0);
                    heroBox2.BackColor = Color.FromArgb(i, 0, 0, 0);
                    heroBox.BackColor = Color.FromArgb(i, 0, 0, 0);
                    youDiedLabel.BackColor = Color.FromArgb(i, 0, 0, 0);
                    Thread.Sleep(50);
                    Refresh();
                }
                Thread.Sleep(1000);
                Application.Exit();
            }
            if (hero2Health <= 0)
            {
                youDiedLabel.Visible = true;
                bulletCount.Visible = false;
                bulletLabel.Visible = false;
                healthCount.Visible = false;
                healthLabel.Visible = false;
                healthCount2.Visible = false;
                healthLabel2.Visible = false;
                bulletLabel2.Visible = false;
                bulletCount2.Visible = false;
                if (direction2 == "left")
                {
                    heroBox2.BackgroundImage = GameTemplateTest.Properties.Resources.marco2_dead_Right;
                }
                else
                {
                    heroBox2.BackgroundImage = GameTemplateTest.Properties.Resources.marco2_dead_Left;
                }
                healthLabel2.Text = hero2Health + "";
                deathLabel.Visible = true;
                for (int i = 0; i <= 256; i = i + 5)
                {
                    deathLabel.BackColor = Color.FromArgb(i, 0, 0, 0);
                    youDiedLabel.ForeColor = Color.FromArgb(i, 255, 0, 0);
                    heroBox2.BackColor = Color.FromArgb(i, 0, 0, 0);
                    youDiedLabel.ForeColor = Color.FromArgb(i, 255, 0, 0);
                    heroBox.BackColor = Color.FromArgb(i, 0, 0, 0);
                    youDiedLabel.BackColor = Color.FromArgb(i, 0, 0, 0);
                    Thread.Sleep(50);
                    Refresh();
                }
                Thread.Sleep(1000);
                Application.Exit();
            }
        }
    }
}