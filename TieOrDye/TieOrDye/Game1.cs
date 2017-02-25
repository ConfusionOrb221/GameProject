using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

/*
TieOrDye Game Class
*/

namespace TieOrDye
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Keyboard State Object
        KeyboardState kbState;

        //P1's sprite (Temporary)
        Texture2D p1TempImg;
        //P1's location attributes
        float p1PosX;
        float p1PosY;
        Vector2 p1Pos;
        //Player 1 object
        Player p1;

        //P2's sprite (Temporary)
        Texture2D p2TempImg;
        //P2's location attributes
        float p2PosX;
        float p2PosY;
        Vector2 p2Pos;
        //Player 2 object
        Player p2;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Changes resolution - Default resolution is 800x480 -- This code changes it to 1000x800
            graphics.PreferredBackBufferWidth = 1000;  
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //P1's initial location
            p1PosX = 0;
            p1PosY = 0;

            //P2's initial location
            p2PosX = 900;
            p2PosY = 0;

            //P1 Object
            p1 = new Player(true);

            //P2 Object
            p2 = new Player(false);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load temporary p1 image
            p1TempImg = Content.Load<Texture2D>("p1Temp");
            //Load temporary p2 image
            p2TempImg = Content.Load<Texture2D>("p2Temp");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //Checks input per update
            CheckInput();

            //Update p1 location
            p1Pos = new Vector2(p1PosX, p1PosY);
            //Send p1 location to player class
            p1.GetPos(p1PosX, p1PosY);
       
            //Update p2 location
            p2Pos = new Vector2(p2PosX, p2PosY);
            //Send p2 location to player class
            p2.GetPos(p2PosX, p2PosY);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //Start spritebatch
            spriteBatch.Begin();
            //Draw p1 at their current position
            spriteBatch.Draw(p1TempImg, p1Pos, Color.White);
            spriteBatch.Draw(p2TempImg, p2Pos, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        //Check for player input
        public void CheckInput()
        {
            //Keyboard object
            KeyboardState kbState = Keyboard.GetState();
            //WASD - P1 Movement
            //Currently changes float by 1, can replace the 1 with a movement increment variable
            //P1 Up
            if (kbState.IsKeyDown(Keys.W))
            {
                p1Pos = new Vector2(p1PosX, p1PosY -= 1);
            }
            //P1 Left
            if (kbState.IsKeyDown(Keys.A))
            {
                p1Pos = new Vector2(p1PosX -= 1, p1PosY);
            }
            //P1 Down
            if (kbState.IsKeyDown(Keys.S))
            {
                p1Pos = new Vector2(p1PosX, p1PosY += 1);
            }
            //P1 Right
            if (kbState.IsKeyDown(Keys.D))
            {
                p1Pos = new Vector2(p1PosX += 1, p1PosY);
            }
            //Arrow Keys - P2 Movement
            //P2 Up
            if (kbState.IsKeyDown(Keys.Up))
            {
                p2Pos = new Vector2(p2PosX, p2PosY -= 1);
            }
            //P2 Left
            if (kbState.IsKeyDown(Keys.Left))
            {
                p2Pos = new Vector2(p2PosX -= 1, p2PosY);
            }
            //P2 Down
            if (kbState.IsKeyDown(Keys.Down))
            {
                p2Pos = new Vector2(p2PosX, p2PosY += 1);
            }
            //P2 Right
            if (kbState.IsKeyDown(Keys.Right))
            {
                p2Pos = new Vector2(p2PosX += 1, p2PosY);
            }
        }

    }
}
