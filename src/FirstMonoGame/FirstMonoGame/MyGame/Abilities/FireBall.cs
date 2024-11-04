using FirstMonoGame.Base._2D.Actor.Components;
using FirstMonoGame.Base._2D.Sprites;
using FirstMonoGame.Base._2D.Sprites.Animation;
using FirstMonoGame.Base.Sprites.Animation;
using FirstMonoGame.PlugIns.AbilitySystem;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FirstMonoGame.MyGame.Abilities
{
    internal class FireBall : AbilityBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        private static SpriteAnimation _spriteSource;
        private static bool _init = false;

        private float _spriteScale = 3.0f;

        private double _timeLeft = 3000.0;

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public FireBall(ContentManager content)
        {
            if (_init == false)
            {
                _init = true;
                var tileMapSettings = new SpriteSourceTileMapSettings(new SpriteGroup[1]);
                tileMapSettings.SpriteGroups[0].SpriteLayout = SpriteLayouts.Horizontally;
                tileMapSettings.SpriteGroups[0].SpriteHeight = 100;
                tileMapSettings.SpriteGroups[0].SpriteWidth = 100;
                tileMapSettings.SpriteGroups[0].StartPoint = new IntVector2(0, 0);
                tileMapSettings.SpriteGroups[0].NumberOfColumns = 1;
                tileMapSettings.SpriteGroups[0].NumberOfRows = 1;
                tileMapSettings.SpriteGroups[0].NumberOfSprites = 1;

                var tiledSource = new TileMapSpriteSource(content.Load<Texture2D>("Effects/Magic/fireball"), tileMapSettings, _spriteScale);
                _spriteSource = new(tiledSource, 1, 100);
            }

            var t = new SpriteAnimationManager(content, new SpriteAnimation[1] { _spriteSource });
            AddComponent(new SpriteAnimatorComponent(this, t));

            //AddComponent(new Collider2DComponent());
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public override void Update(double elapsedTime)
        {
            base.Update(elapsedTime);

            _timeLeft = _timeLeft - elapsedTime;
            if (_timeLeft < 0)
                Destroy();
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        private void Destroy()
        {
            Game1.CurrentMap.DestroyActor(this);
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