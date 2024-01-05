using FirstMonoGame.Base._2D.Sprites;
using FirstMonoGame.Base._2D.Sprites.Animation;
using FirstMonoGame.Base.Sprites.Animation;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FirstMonoGame.MyGame.Characters.Player
{
    internal class PlayerAnimationManager : AnimationStateManager
    {
        #region "----------------------------- Private Fields ------------------------------"
        private PlayerStates _playerStates;

        private SpriteAnimation _animation_Idle_Right;
        private SpriteAnimation _animation_Idle_Left;
        private SpriteAnimation _animation_Walk_Right;
        private SpriteAnimation _animation_Walk_Left;
        private SpriteAnimation _animation_Run_Right;
        private SpriteAnimation _animation_Run_Left;

        public PlayerMovementStates _previousPlayerMovementStates { get; protected set; }


        private float _playerScale = 3.0f;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public PlayerAnimationManager(ContentManager content, PlayerStates playerStates)
        {
            _playerStates = playerStates;

            var source = new SpriteSource(_playerScale);

            var tileMapSettings = new SpriteSourceTileMapSettings(new SpriteGroup[1]);
            tileMapSettings.SpriteGroups[0].SpriteLayout = SpriteLayouts.Horizontally;
            tileMapSettings.SpriteGroups[0].SpriteHeight = 120;
            tileMapSettings.SpriteGroups[0].SpriteWidth = 120;
            tileMapSettings.SpriteGroups[0].StartPoint = new IntVector2(0, 0);
            tileMapSettings.SpriteGroups[0].NumberOfColumns = 10;
            tileMapSettings.SpriteGroups[0].NumberOfRows = 1;
            tileMapSettings.SpriteGroups[0].NumberOfSprites = 10;

            var tiledSource = new TileMapSpriteSource(content.Load<Texture2D>("Characters/Dark Knight/Idle/Right/Idle"), tileMapSettings, _playerScale);
            _animation_Idle_Right = new(tiledSource, 1, 100);

            source = new SpriteSource(_playerScale);
            source.AddSpriteGroup(new Texture2D[]
            {
                content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-1"),
                content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-2"),
                content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-3"),
                content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-4"),
                content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-5"),
                content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-6"),
                content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-7"),
                content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-8"),
                content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-9"),
                content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-10"),
            });
            _animation_Idle_Left = new(source, 1, 100);

            source = new SpriteSource(_playerScale);
            source.AddSpriteGroup(new Texture2D[]
            {
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-1"),
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-2"),
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-3"),
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-4"),
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-5"),
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-6"),
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-7"),
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-8"),
            });
            _animation_Walk_Right = new(source, 1, 100);
            source = new SpriteSource(_playerScale);
            source.AddSpriteGroup(new Texture2D[]
            {
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-1"),
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-2"),
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-3"),
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-4"),
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-5"),
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-6"),
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-7"),
                content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-8"),
            });
            _animation_Walk_Left = new(source, 1, 100);

            source = new SpriteSource(_playerScale);
            source.AddSpriteGroup(new Texture2D[]
            {
                content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-1"),
                content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-2"),
                content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-3"),
                content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-4"),
                content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-5"),
                content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-6"),
                content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-7"),
                content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-8"),
            });
            _animation_Run_Right = new(source, 1, 100);
            source = new SpriteSource(_playerScale);
            source.AddSpriteGroup(new Texture2D[]
            {
                content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-1"),
                content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-2"),
                content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-3"),
                content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-4"),
                content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-5"),
                content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-6"),
                content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-7"),
                content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-8"),
            });
            _animation_Run_Left = new(source, 1, 100);
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public override void Update(double elapsedTime)
        {
            if (_previousPlayerMovementStates != _playerStates.PlayerMovementStates ||
                CurrentAnimation is null)
            {
                _previousPlayerMovementStates = _playerStates.PlayerMovementStates;
                InitNewAnimation(_playerStates.PlayerMovementStates);
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
                    _animation_Idle_Right.Reset();
                    CurrentAnimation = _animation_Idle_Right;
                    break;
                case PlayerMovementStates.IdleLeft:
                    _animation_Idle_Left.Reset();
                    CurrentAnimation = _animation_Idle_Left;
                    break;

                case PlayerMovementStates.WalkingRight:
                    _animation_Walk_Right.Reset();
                    CurrentAnimation = _animation_Walk_Right;
                    break;
                case PlayerMovementStates.WalkingLeft:
                    _animation_Walk_Left.Reset();
                    CurrentAnimation = _animation_Walk_Left;
                    break;

                case PlayerMovementStates.RunningRight:
                    _animation_Run_Right.Reset();
                    CurrentAnimation = _animation_Run_Right;
                    break;
                case PlayerMovementStates.RunningLeft:
                    _animation_Run_Left.Reset();
                    CurrentAnimation = _animation_Run_Left;
                    break;
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