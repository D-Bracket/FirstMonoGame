using FirstMonoGame.Base;
using FirstMonoGame.Base._2D.Renderer;
using FirstMonoGame.MyGame.Characters.Player;
using FirstMonoGame.MyGame.Maps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstMonoGame
{
    // Sprite Cutting https://www.piskelapp.com/p/create/sprite

    // ToDo - Base:
    // Implement Actor Components
    // Collision
    // UI
    // Sound


    public class Game1 : Game
    {
        #region "----------------------------- Private Fields ------------------------------"
        private GraphicsDeviceManager _graphics;
        private static SpriteBatch _spriteBatch;

        private DrawInfo2D _drawInfo = new DrawInfo2D();
        private ResolutionSettings _resolutionSettings;

        private Renderer2D _renderer;
        private Player _player;
        private Map1 _map;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _resolutionSettings = ResolutionSettings.GetInstance();
            _resolutionSettings.SetResolution(1920, 1080, 1.0f);


            //_graphics.PreferredBackBufferHeight = 256;
            //_graphics.PreferredBackBufferWidth = 224;            
            _graphics.PreferredBackBufferHeight = _resolutionSettings.CurrentResolution.Height;
            _graphics.PreferredBackBufferWidth = _resolutionSettings.CurrentResolution.Width;
            _graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _renderer = new Renderer2D(_spriteBatch);
            _map = new Map1(3200, 3200, 100, 100);
            //_player = new Player(_map);

            base.Initialize();
        }

        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here
            //_player.Init(Content);
            _map.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _map.Update(gameTime.ElapsedGameTime.TotalMilliseconds);
            //_player.Update(gameTime.ElapsedGameTime.TotalMilliseconds);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //_spriteBatch.Begin();

            _renderer.RenderCameraScene();
            //_map.GetDrawInfo(ref _drawInfo);
            //DrawThisShit();
            //_player.GetDrawInfo(ref _drawInfo);
            //DrawThisShit();

            //_spriteBatch.End();

            base.Draw(gameTime);



            void DrawThisShit()
            {
                if (_drawInfo.IsTileMap)
                {
                    _drawInfo.DestinationRectancle = 
                        new Rectangle(
                            _drawInfo.DestinationRectancle.X,
                            _drawInfo.DestinationRectancle.Y,
                            _drawInfo.SourceRectancle.Width*4,
                            _drawInfo.SourceRectancle.Height*4);
                    _spriteBatch.Draw(_drawInfo.Sprite, _drawInfo.DestinationRectancle, _drawInfo.SourceRectancle, Color.White);
                }
                else
                {
                    var t = new Rectangle(0, 0, 120, 120);
                    var effect = new SpriteEffects();
                    var scale = 4.0f;
                    _spriteBatch.Draw(_drawInfo.Sprite, new Vector2(_drawInfo.XPosition, _drawInfo.YPosition), t, Color.White,0,new Vector2(0,0), scale, effect, 1);
                }
            }
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"

        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}