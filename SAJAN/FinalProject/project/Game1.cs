using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows.Forms.Automation;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Newtonsoft.Json;
using SharpDX.XInput;
using System.IO;
using System.ComponentModel.DataAnnotations;
//using SharpDX.Direct2D1;

namespace project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //for score board
        private KeyboardState previousState;
        private SpriteFont font;
        private Texture2D heart;
        private int score;
        //enemy art
        private static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        private Texture2D player;
        private Texture2D enemyA;
        private Texture2D enemyB;
        private Texture2D midBoss;
        private Texture2D finalBoss;
        private Texture2D basicBullet;
        private Texture2D midBossBullet;
        private Texture2D finalBossBullet;
        Microsoft.Xna.Framework.Vector2 left;
        Microsoft.Xna.Framework.Vector2 middle;
        Microsoft.Xna.Framework.Vector2 right;

        int menuX = 650;

        private bool wave1 = false;
        private bool wave2 = false;
        private bool wave3 = false;
        private bool wave4 = false;
        private bool wave5 = false;
        private bool wave6 = false;

        bool game = false;
        bool victory = false;
        bool alive = true;

        private Player myPlayer;
        
        private Container container;

        private int bulletWaitTime;
        private bool cheatKeyReleased;
        private bool safety;
        private int keywait;

        Song backgroundSong;
        Song victorySong;
        Song gameOver;

        List<Song> songs;
        List<SoundEffect> sounds;
        //List<Wave> waveList = new List<Wave>();
        //List<Wave> waves = new List<Wave>();
        Wave Wave1;
        Wave Wave2;
        Wave Wave3;
        Wave Wave4;
        Wave Wave5;
        Wave Wave6;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            this.sounds = new List<SoundEffect>();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.score = 0;
            bulletWaitTime = 0;
            cheatKeyReleased = true;
            keywait = 0;
            safety = false;

            
            this.left = new Microsoft.Xna.Framework.Vector2(100, 50);
            this.middle = new Microsoft.Xna.Framework.Vector2(250, 50);
            this.right = new Microsoft.Xna.Framework.Vector2(400, 50);

            List<string> enemies = new List<string>();// ["BasicEnemyA", "BasicEnemyA", "BasicEnemyA"];
            List<int> hp = new List<int>();
            List<Vector2> pos = new List<Vector2>();
            List<int> pattern = new List<int>();

            //this.waveList = new List<Wave>();

            /*          container.addEnemyB(left, 1);
                                container.addEnemyB(middle, 2);
                                container.addEnemyB(right, 2);*/

/*            enemies.Add("FinalBoss");
            hp.Add(300);
            pos.Add(new Vector2(.7f, .7f));
            pattern.Add(1);*/
            /*// public List<String> enemyList { get; set; }
            *//*public List<int> enemyHP { get; set; }
            public List<Vector2> enemyPos { get; set; }
            public List<int> enemyPattern { get; set; }*//*
            Wave temp = new Wave();
            temp.enemyList = enemies;
            temp.enemyHP = hp;
            temp.enemyPos = pos;
            temp.enemyPattern = pattern;        

            // Serialize
            String stringjson = JsonConvert.SerializeObject(temp);
            File.WriteAllText("C:\\wave\\wave6.json", stringjson);*/

            // Deserialize
            string json = File.ReadAllText("C:\\wave\\wave1.json");
            this.Wave1 = new Wave();
            Wave1 = JsonConvert.DeserializeObject<Wave>(json);

            json = File.ReadAllText("C:\\wave\\wave2.json");
            this.Wave2 = new Wave();
            Wave2 = JsonConvert.DeserializeObject<Wave>(json);

            json = File.ReadAllText("C:\\wave\\wave3.json");
            this.Wave3 = new Wave();
            Wave3 = JsonConvert.DeserializeObject<Wave>(json);

            json = File.ReadAllText("C:\\wave\\wave4.json");
            this.Wave4 = new Wave();
            Wave4 = JsonConvert.DeserializeObject<Wave>(json);

            json = File.ReadAllText("C:\\wave\\wave5.json");
            this.Wave5 = new Wave();
            Wave5 = JsonConvert.DeserializeObject<Wave>(json);

            json = File.ReadAllText("C:\\wave\\wave6.json");
            this.Wave6 = new Wave();
            Wave6 = JsonConvert.DeserializeObject<Wave>(json);

            /*            json = File.ReadAllText("C:\\wave\\wave4.json");
                        this.Wave4 = new Wave();
                        Wave4 = JsonConvert.DeserializeObject<Wave>(json);*/

            //waveList.Add(wave1);
            //this.waves = waveList;
            // read file into a string and deserialize JSON to a type
            // Wave wave1 = JsonConvert.DeserializeObject<Wave>(json);
            //this.waveList.Add(wave1);
            // deserialize JSON directly from a file
            /*            using (StreamReader file = File.OpenText(@"C:\\wave\\output.txt"))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            Wave movie2 = (Wave)serializer.Deserialize(file, typeof(Wave));
                        }*/
        }


        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            loadTextures();//load textures to the dictionary.

            //not needed
            font = Content.Load<SpriteFont>("Name");
            heart = Content.Load<Texture2D>("Heart");
            enemyA = Content.Load<Texture2D>("EnemyA");
            enemyB = Content.Load<Texture2D>("EnemyB");
            midBoss = Content.Load<Texture2D>("MidBoss");
            finalBoss = Content.Load<Texture2D>("FinalBoss");
            basicBullet = Content.Load<Texture2D>("BasicBullet");
            midBossBullet = Content.Load<Texture2D>("MidBullet");
            finalBossBullet = Content.Load<Texture2D>("FinalBullet");
            player = Content.Load<Texture2D>("bolong");
            

            this.left = new Microsoft.Xna.Framework.Vector2(100, 50);
            this.middle = new Microsoft.Xna.Framework.Vector2(250, 50);
            this.right = new Microsoft.Xna.Framework.Vector2(400, 50);


            // Music            
            this.backgroundSong = Content.Load<Song>("Sandstorm");
            this.victorySong = Content.Load<Song>("SweetVictory");
            this.gameOver = Content.Load<Song>("GameOver");

            this.songs = new List<Song>();
            this.songs.Add(this.backgroundSong);
            this.songs.Add(this.victorySong);
            this.songs.Add(this.gameOver);

            MediaPlayer.Volume = 0.01f;

            sounds.Add(Content.Load<SoundEffect>("Laser"));
            sounds.Add(Content.Load<SoundEffect>("Bomb"));
            sounds.Add(Content.Load<SoundEffect>("CheatMode"));
            sounds.Add(Content.Load<SoundEffect>("PlayerDamage"));
            sounds.Add(Content.Load<SoundEffect>("PlayerDeath"));
            sounds.Add(Content.Load<SoundEffect>("EnemyDeath"));
            sounds.Add(Content.Load<SoundEffect>("MidBossDeath"));
            sounds.Add(Content.Load<SoundEffect>("FinalBossDeath"));
            
            container = new Container(this.GraphicsDevice);

            Vector2 V = new Vector2(1,1);
            Vector2 C = new Vector2(350, 600);
            myPlayer = new Player(8, V, C, this.GraphicsDevice);

            container.addPlayerObject(myPlayer);
        }

        // Changes background stage colors
        public void UpdateStage(Color newColor, int stage, GameTime gameTime)
        {   
            
            if (stage == 1)
            {
                GraphicsDevice.Clear(newColor);

                if (wave1 == false)
                {
                    // Adds enemies at preset locations
                    //container.addEnemyA(this.waveList[0].enemyPos[0], this.waveList[0].enemyPattern[0]);
                    //container.addEnemyA(left, 1);

                    /*int id;
public List<Enemy> enemyList;
public List<int> enemyHP;
public List<Vector2> enemyPos;
public List<int> enemyPattern;
*/
                    int index = 0;
                    int length = Wave1.enemyList.Count;//(waveList[0].enemyList).Count;
                    while (index < length)
                    {

                        container.addEnemy(this.Wave1.enemyList[index], this.Wave1.enemyHP[index], this.Wave1.enemyPos[index], this.Wave1.enemyPattern[index]);
                        index += 1;
                    }
                   

                    // Wave1 complete
                    wave1 = true;
                }
                else if(wave1 == true && wave2 == false)
                {
                    container.freeDespawns();
                    if (Convert.ToInt32(gameTime.TotalGameTime.TotalSeconds) % 4 == 0 && safety == false)
                    {
                        container.BasicEnemyShoot();
                        safety = true;
                    }
                    else if (Convert.ToInt32(gameTime.TotalGameTime.TotalSeconds) % 4 != 0)
                    {
                        safety = false;
                    }
                }

                if (wave2 == false && gameTime.TotalGameTime.TotalSeconds > 12)
                {
                    MediaPlayer.Volume = 0.05f;
                    
                    // Adds enemies at preset locations
                    
                    int index = 0;
                    int length = Wave2.enemyList.Count;//(waveList[0].enemyList).Count;
                    while (index < length)
                    {

                        container.addEnemy(this.Wave2.enemyList[index], this.Wave2.enemyHP[index], this.Wave2.enemyPos[index], this.Wave2.enemyPattern[index]);
                        index += 1;
                    }

                    // All enemies shoot at once
                    container.BasicEnemyShoot();

                    // Wave2 complete
                    wave2 = true;
                }
                else if (wave2 == true && wave3 == false)
                {
                    container.freeDespawns();
                    if (Convert.ToInt32(gameTime.TotalGameTime.TotalSeconds) % 4 == 0 && safety == false)
                    {
                        container.BasicEnemyShoot();
                        safety = true;
                    }
                    else if (Convert.ToInt32(gameTime.TotalGameTime.TotalSeconds) % 4 != 0)
                    {
                        safety = false;
                    }
                }
            }

            // Green Bug Stage
            else if (stage == 2)
            {

                GraphicsDevice.Clear(newColor);

                if (wave3 == false)
                {
                    MediaPlayer.Volume += 0.10f;
                    container.clearEnemyBullets();
                    container.clearEnemies();
                    container.addMidBoss();
                    wave3 = true;
                }
                else if (wave3 == true && wave4 == false)
                {
                    container.freeDespawns();
                    if (Convert.ToInt32(gameTime.TotalGameTime.TotalSeconds) % 4 == 0 && safety == false)
                    {                        
                        container.MidBossShoot();
                        safety = true;
                    }
                    else if (Convert.ToInt32(gameTime.TotalGameTime.TotalSeconds) % 4 != 0)
                    {
                        safety = false;
                    }
                }

            }
            
            // Midboss Stage
            else if (stage == 3)
            {
                if (wave4 == false)
                {
                    MediaPlayer.Volume = 0.10f;
                    // Adds enemies at preset locations
                    container.clearEnemyBullets();
                    container.clearEnemies();
                    int index = 0;
                    int length = Wave3.enemyList.Count;//(waveList[0].enemyList).Count;
                    while (index < length)
                    {
                        container.addEnemy(this.Wave3.enemyList[index], this.Wave3.enemyHP[index], this.Wave3.enemyPos[index], this.Wave3.enemyPattern[index]);
                        index += 1;
                    }
                    wave4 = true;
                }
                else if (wave4 == true && wave5 == false)
                {
                    container.freeDespawns();
                    if (Convert.ToInt32(gameTime.TotalGameTime.TotalSeconds) % 4 == 0 && safety == false)
                    {
                        container.MidBossShoot();
                        safety = true;
                    }
                    else if (Convert.ToInt32(gameTime.TotalGameTime.TotalSeconds) % 4 != 0)
                    {
                        safety = false;
                    }
                }

                if (wave5 == false && gameTime.TotalGameTime.TotalSeconds > 36)
                {
                    MediaPlayer.Volume = 0.05f;
                    container.clearEnemyBullets();
                    container.clearEnemies();
                    int index = 0;
                    int length = Wave5.enemyList.Count;
                    while (index < length)
                    {
                        container.addEnemy(this.Wave5.enemyList[index], this.Wave5.enemyHP[index], this.Wave5.enemyPos[index], this.Wave5.enemyPattern[index]);
                        index += 1;
                    }
                    container.BasicEnemyShoot();
                    wave5 = true;
                }
                else if (wave5 == true && wave6 == false)
                {
                    container.freeDespawns();
                    if (Convert.ToInt32(gameTime.TotalGameTime.TotalSeconds) % 4 == 0 && safety == false)
                    {
                        container.MidBossShoot();
                        safety = true;
                    }
                    else if (Convert.ToInt32(gameTime.TotalGameTime.TotalSeconds) % 4 != 0)
                    {
                        safety = false;
                    }
                }
            }

            // Intermediate Stage
            else if (stage == 0)
            {
                GraphicsDevice.Clear(newColor);
            }

            // Final Boss Stage
            else if (stage == 4)
            {
                GraphicsDevice.Clear(newColor);

                if (wave6 == false)
                {
                    MediaPlayer.Volume = 0.11f;
                    container.clearEnemyBullets();
                    container.clearEnemies();
                    int index = 0;
                    int length = Wave6.enemyList.Count;//(waveList[0].enemyList).Count;
                    while (index < length)
                    {
                        container.addEnemy(this.Wave6.enemyList[index], this.Wave6.enemyHP[index], this.Wave6.enemyPos[index], this.Wave6.enemyPattern[index]);
                        index += 1;
                    }
                    wave6 = true;
                }
                else if (wave6 == true)
                {
                    container.freeDespawns();
                    if (Convert.ToInt32(gameTime.TotalGameTime.TotalSeconds) % 4 == 0 && safety == false)
                    {
                        container.MidBossShoot();
                        safety = true;
                    }
                    else if (Convert.ToInt32(gameTime.TotalGameTime.TotalSeconds) % 4 != 0)
                    {
                        safety = false;
                    }
                }
            }
        }


        //load textures into a dictionary
        public void loadTextures()
        {
            textures["PlayerBullet"] = Content.Load<Texture2D>("PlayerBullet");
            textures["FinalBullet"] = Content.Load<Texture2D>("FinalBullet");
            textures["MidBullet"] = Content.Load<Texture2D>("MidBullet");
            textures["BasicBullet"] = Content.Load<Texture2D>("BasicBullet");
            textures["Heart"] = Content.Load<Texture2D>("Heart");
            textures["EnemyA"] = Content.Load<Texture2D>("EnemyA");
            textures["EnemyB"] = Content.Load<Texture2D>("EnemyB");
            textures["MidBoss"] = Content.Load<Texture2D>("MidBoss");
            textures["FinalBoss"] = Content.Load<Texture2D>("FinalBoss");
            textures["bolong"] = Content.Load<Texture2D>("bolong");
        }

        //get a texture for a class
        public static Texture2D getTexture(string textureName)
        {
            return textures[textureName];
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _graphics.ToggleFullScreen();

            previousState = Keyboard.GetState();

            // Update Controller
            container.Update(gameTime);

            //lower respawn time if it has a value greater than 0
            if (myPlayer.RespawnTime > 0)
            {
                myPlayer.RespawnTime--;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {

                // Fire stream of bullets
                if (bulletWaitTime <= 0)
                {
                    PlayerBullet bullet = new PlayerBullet(Game1.getTexture("PlayerBullet"));
                    SoundEffect.MasterVolume = 0.02f;
                    this.sounds[0].Play();
                    bullet.Position = new Microsoft.Xna.Framework.Vector2(container.myPlayer.position.X + 32 - bullet.Sprite.Width / 2, container.myPlayer.position.Y + 30);
                    bullet.isVisible = true;
                    container.addPlayerBullet(bullet);
                    bulletWaitTime = 15;
                }
                else
                {
                    bulletWaitTime -= 1;
                }
            }
            else
            {
                bulletWaitTime = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.C) && cheatKeyReleased == true)
            {
                if (myPlayer.CheatMode == false)
                {
                    SoundEffect.MasterVolume = 0.02f;
                    this.sounds[2].Play();
                    myPlayer.CheatMode = true;
                }
                else
                {
                    SoundEffect.MasterVolume = 0.02f;
                    this.sounds[2].Play();
                    myPlayer.CheatMode = false;
                }
                keywait = 10;
                cheatKeyReleased = false;
            }
            else
            {
                if (keywait > 0)
                {
                    keywait--;
                }
                else
                {
                    cheatKeyReleased = true;
                }

            }
      
            if (Keyboard.GetState().IsKeyDown(Keys.B))
            {
                SoundEffect.MasterVolume = 0.08f;
                this.sounds[1].Play();
                container.Bomb();
            }

            // Background Music
            if (this.game == false)
            {
                MediaPlayer.Play(songs[0]);
                game = true;
            }

            // Victory Music
            if (gameTime.TotalGameTime.TotalSeconds >= 82 && gameTime.TotalGameTime.TotalSeconds < 120 && victory == false)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(songs[1]);
                this.victory = true;
            }

            if (myPlayer.GetHealth() <= 0 && this.alive == true)
            {
                MediaPlayer.Stop();
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(songs[2]);
                this.alive = false;
            }

        }

        protected override void Draw(GameTime gameTime)
        {
            if (myPlayer.GetHealth() <= 0)
            {                
                container.ClearBoard();
                GraphicsDevice.Clear(Color.White);
                _spriteBatch.Begin();
                _spriteBatch.DrawString(font, "GAME OVER :(", new Vector2(200, 200), Color.Black);
                _spriteBatch.DrawString(font, "Final SCORE:" + container.GetScore(), new Vector2(200, 250), Color.Black);
            }
            else if (gameTime.TotalGameTime.TotalSeconds >= 82)
            {                
                container.ClearBoard();
                GraphicsDevice.Clear(Color.White);
                _spriteBatch.Begin();
                _spriteBatch.DrawString(font, "YOU WIN :)", new Vector2(200, 200), Color.Black);
                _spriteBatch.DrawString(font, "Final SCORE:" + container.GetScore(), new Vector2(200, 250), Color.Black);
            }
            else
            {
                GraphicsDevice.Clear(Color.LightGray);
                _spriteBatch.Begin();
                container.Draw(_spriteBatch);
                DrawHearts();

                //not needed
                _spriteBatch.DrawString(font, "SCORE:" + container.GetScore(), new Vector2(menuX, 40), Color.Black);

                if (gameTime.TotalGameTime.TotalSeconds < 24)
                {
                    _spriteBatch.DrawString(font, "STAGE 1", new Vector2(menuX, 20), Color.Black);
                    UpdateStage(Color.LightGray, 1, gameTime);
                }
                if (gameTime.TotalGameTime.TotalSeconds >= 24 && gameTime.TotalGameTime.TotalSeconds < 48)
                {
                    _spriteBatch.DrawString(font, "Mid Boss", new Vector2(menuX, 20), Color.Black);
                    UpdateStage(Color.Yellow, 2, gameTime);
                    _spriteBatch.DrawString(font, "The BEE", new Vector2(10, 10), Color.Black);
                    int xHeart = 100;
                    for (int hearts = 0; hearts < (container.getBossHealth() / 10); hearts++)
                    {
                        _spriteBatch.Draw(heart, new Vector2(xHeart, 20), Color.White);
                        xHeart += 10;
                    }
                }
                if (gameTime.TotalGameTime.TotalSeconds >= 48 && gameTime.TotalGameTime.TotalSeconds < 72)
                {
                    _spriteBatch.DrawString(font, "STAGE 3", new Vector2(menuX, 20), Color.Black);
                    UpdateStage(Color.Orange, 3, gameTime);
                }
                if (gameTime.TotalGameTime.TotalSeconds >= 72 && gameTime.TotalGameTime.TotalSeconds < 82)
                {
                    _spriteBatch.DrawString(font, "Final Boss", new Vector2(menuX, 20), Color.Black);
                    UpdateStage(Color.Red, 4, gameTime);
                    _spriteBatch.DrawString(font, "The Spider", new Vector2(10, 10), Color.Black);
                    int xHeart = 130;
                    for (int hearts = 0; hearts < (container.getBossHealth() / 10); hearts++)
                    {
                        _spriteBatch.Draw(heart, new Vector2(xHeart, 20), Color.White);
                        xHeart += 10;
                    }
                }

                if (myPlayer.CheatMode)
                {
                    _spriteBatch.DrawString(font, "CHEAT MODE ON", new Vector2(500, 450), Color.Black);
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void DrawHearts()
        {
            int x = menuX;
            int y = 60;
            for (int hearts = 0; hearts <= myPlayer.GetHealth(); hearts++)
            {
                _spriteBatch.Draw(heart, new Vector2(x, 60), Color.White);
                x += 10;
            }
        }        
    }
}
