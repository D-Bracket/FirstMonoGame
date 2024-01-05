using FirstMonoGame.Base._2D.Sprites;
using FirstMonoGame.Base._2D.Sprites.Animation;
using FirstMonoGame.Base.Sprites.Animation;
using FirstMonoGame.MyGame.Characters.Player;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FirstMonoGame.MyGame.Characters.Zombie
{
    internal class ZombieAnimationManager : AnimationStateManager
    {
        #region "----------------------------- Private Fields ------------------------------"
        private ZombieStates _zombieStates;

        private const string IDLE_RIGHT = "Idle_Right";
        private PlayerMovementStates _previousMovementStates;

        private float _zombieScale = 3.0f;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public ZombieAnimationManager(ContentManager content, ZombieStates zombieStates)
        {
            _zombieStates = zombieStates;

            var tileMapSettings = new SpriteSourceTileMapSettings(new SpriteGroup[1]);
            tileMapSettings.SpriteGroups[0].SpriteLayout = SpriteLayouts.Horizontally;
            tileMapSettings.SpriteGroups[0].SpriteHeight = 120;
            tileMapSettings.SpriteGroups[0].SpriteWidth = 120;
            tileMapSettings.SpriteGroups[0].StartPoint = new IntVector2(0, 0);
            tileMapSettings.SpriteGroups[0].NumberOfColumns = 10;
            tileMapSettings.SpriteGroups[0].NumberOfRows = 1;
            tileMapSettings.SpriteGroups[0].NumberOfSprites = 10;

            var tiledSource = new TileMapSpriteSource(content.Load<Texture2D>("Characters/Zombie/Zombie"), tileMapSettings, _zombieScale);
            Animations.Add(IDLE_RIGHT, new SpriteAnimation(tiledSource, 1, 100));
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public override void Update(double elapsedTime)
        {
            if (_previousMovementStates != _zombieStates.PlayerMovementStates ||
                CurrentAnimation is null)
            {
                _previousMovementStates = _zombieStates.PlayerMovementStates;
                InitNewAnimation(_zombieStates.PlayerMovementStates);
                return;
            }
            CurrentAnimation?.Tick(elapsedTime);
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        private void InitNewAnimation(PlayerMovementStates playerMovementStates)
        {
            switch (playerMovementStates)
            {
                case PlayerMovementStates.IdleRight:
                    CurrentAnimation = Animations[IDLE_RIGHT];
                    break;
                    //case PlayerMovementStates.IdleLeft:
                    //    _animation_Idle_Left.Reset();
                    //    _currentAnimation = _animation_Idle_Left;
                    //    break;

                    //case PlayerMovementStates.WalkingRight:
                    //    _animation_Walk_Right.Reset();
                    //    _currentAnimation = _animation_Walk_Right;
                    //    break;
                    //case PlayerMovementStates.WalkingLeft:
                    //    _animation_Walk_Left.Reset();
                    //    _currentAnimation = _animation_Walk_Left;
                    //    break;

                    //case PlayerMovementStates.RunningRight:
                    //    _animation_Run_Right.Reset();
                    //    _currentAnimation = _animation_Run_Right;
                    //    break;
                    //case PlayerMovementStates.RunningLeft:
                    //    _animation_Run_Left.Reset();
                    //    _currentAnimation = _animation_Run_Left;
                    //    break;
            }
            CurrentAnimation.Reset();
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