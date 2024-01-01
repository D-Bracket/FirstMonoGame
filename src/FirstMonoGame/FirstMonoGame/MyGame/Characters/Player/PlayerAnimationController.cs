using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using FirstMonoGame.Base._2D.Renderer;
using FirstMonoGame.Base._2D.Sprites;
using FirstMonoGame.Base.Sprites.Animation;

namespace FirstMonoGame.MyGame.Characters.Player
{
    internal class PlayerAnimationController : SpriteAnimationController
    {
        #region "----------------------------- Private Fields ------------------------------"
        private PlayerStates _playerStates;

        private SpriteAnimation _animation_Idle_Right;
        private SpriteAnimation _animation_Idle_Left;
        private SpriteAnimation _animation_Walk_Right;
        private SpriteAnimation _animation_Walk_Left;
        private SpriteAnimation _animation_Run_Right;
        private SpriteAnimation _animation_Run_Left;

        private SpriteAnimation _currentAnimation;
        private PlayerMovementStates _previousPlayerMovementStates;

        private float _playerScale = 3.0f;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public PlayerAnimationController(ContentManager content, PlayerStates playerStates) : base(content)
        {
            _playerStates = playerStates;

            var source = new SpriteSource(_playerScale);

            var tileMapSettings = new SpriteSourceTileMapSettings(new SpriteGroup[1]);
            tileMapSettings.SpriteGroups[0].SpriteLayout = SpriteLayouts.Horizontally;
            tileMapSettings.SpriteGroups[0].SpriteHeight = 120;
            tileMapSettings.SpriteGroups[0].SpriteWidth = 120;
            tileMapSettings.SpriteGroups[0].StartPoint = new IntVector2(0,0);
            tileMapSettings.SpriteGroups[0].NumberOfColumns = 10;
            tileMapSettings.SpriteGroups[0].NumberOfRows = 1;
            tileMapSettings.SpriteGroups[0].NumberOfSprites = 10;

            var tiledSource = new TileMapSpriteSource(_content.Load<Texture2D>("Characters/Dark Knight/Idle/Right/Idle"), tileMapSettings, _playerScale);
            _animation_Idle_Right = new(tiledSource, 1, 100);

            source = new SpriteSource(_playerScale);
            source.AddSpriteGroup(new Texture2D[]
            {
                _content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-1"),
                _content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-2"),
                _content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-3"),
                _content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-4"),
                _content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-5"),
                _content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-6"),
                _content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-7"),
                _content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-8"),
                _content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-9"),
                _content.Load<Texture2D>("Characters/Dark Knight/Idle/Left/Idle-Left-10"),
            });
            _animation_Idle_Left = new(source, 1, 100);

            source = new SpriteSource(_playerScale);
            source.AddSpriteGroup(new Texture2D[]
            {
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-1"),
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-2"),
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-3"),
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-4"),
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-5"),
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-6"),
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-7"),
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Right/Walk-Right-8"),
            });
            _animation_Walk_Right = new(source, 1, 100);
            source = new SpriteSource(_playerScale);
            source.AddSpriteGroup(new Texture2D[]
            {
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-1"),
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-2"),
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-3"),
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-4"),
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-5"),
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-6"),
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-7"),
                _content.Load<Texture2D>("Characters/Dark Knight/Walk/Left/Walk-Left-8"),
            });
            _animation_Walk_Left = new(source, 1, 100);

            source = new SpriteSource(_playerScale);
            source.AddSpriteGroup(new Texture2D[]
            {
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-1"),
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-2"),
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-3"),
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-4"),
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-5"),
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-6"),
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-7"),
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Right/Run-Right-8"),
            });
            _animation_Run_Right = new(source, 1, 100);
            source = new SpriteSource(_playerScale);
            source.AddSpriteGroup(new Texture2D[]
            {
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-1"),
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-2"),
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-3"),
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-4"),
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-5"),
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-6"),
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-7"),
                _content.Load<Texture2D>("Characters/Dark Knight/Run/Left/Run-Left-8"),
            });
            _animation_Run_Left = new(source, 1, 100);
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public override void Tick(double time)
        {
            if (_previousPlayerMovementStates != _playerStates.PlayerMovementStates ||
                _currentAnimation is null)
            {
                _previousPlayerMovementStates = _playerStates.PlayerMovementStates;
                InitNewAnimation(_playerStates.PlayerMovementStates);
                return;
            }
            _currentAnimation?.Tick(time);
        }

        public override void GetDrawInfoSprite(ref DrawInfo2D drawInfo)
        {
            _currentAnimation.GetDrawInfoSprite(ref drawInfo);
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        private void InitNewAnimation(PlayerMovementStates playerMovementStates)
        {
            switch (playerMovementStates)
            {
                case PlayerMovementStates.IdleRight:
                    _animation_Idle_Right.Reset();
                    _currentAnimation = _animation_Idle_Right;
                    break;
                case PlayerMovementStates.IdleLeft:
                    _animation_Idle_Left.Reset();
                    _currentAnimation = _animation_Idle_Left;
                    break;

                case PlayerMovementStates.WalkingRight:
                    _animation_Walk_Right.Reset();
                    _currentAnimation = _animation_Walk_Right;
                    break;
                case PlayerMovementStates.WalkingLeft:
                    _animation_Walk_Left.Reset();
                    _currentAnimation = _animation_Walk_Left;
                    break;

                case PlayerMovementStates.RunningRight:
                    _animation_Run_Right.Reset();
                    _currentAnimation = _animation_Run_Right;
                    break;
                case PlayerMovementStates.RunningLeft:
                    _animation_Run_Left.Reset();
                    _currentAnimation = _animation_Run_Left;
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