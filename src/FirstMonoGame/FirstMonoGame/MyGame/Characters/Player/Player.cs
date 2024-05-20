using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using FirstMonoGame.Base.Character;
using Microsoft.Xna.Framework;
using FirstMonoGame.Base._2D.Actor.Components;
using FirstMonoGame.Base._2D.Map;

namespace FirstMonoGame.MyGame.Characters.Player
{
    internal class Player : CharacterBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        private float _speed = 2.0f;

        private PlayerStates _playerStates;
        private PlayerAnimationManager _animationManager;

        private bool _lastRight = true;

        private SpriteAnimatorComponent _spriteAnimatorComponent;

        private MapBase _map;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public Player(MapBase map)
        {
            _map = map;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void Init(ContentManager content, float xPosition = 0.0f, float yPosition = 0.0f)
        {
            _playerStates = new PlayerStates();
            _animationManager = new PlayerAnimationManager(content, _playerStates);
            AddComponent(new SpriteAnimatorComponent(this, _animationManager));
            _xPosition = xPosition;
            _yPosition = yPosition;
        }

        public override void Update(double elapsedTime)
        {
            var xPosition = 0.0f;
            var yPosition = 0.0f;

            var kstate = Keyboard.GetState();
            var noMovement = true;
            if (kstate.IsKeyDown(Keys.D) && !kstate.IsKeyDown(Keys.A))
            {
                if (kstate.IsKeyDown(Keys.LeftShift))
                {
                    xPosition = _xPosition +/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ (_speed * 3.0f);
                    _playerStates.PlayerMovementStates = PlayerMovementStates.RunningRight;
                    _lastRight = true;
                    noMovement = false;
                }
                else
                {
                    xPosition = _xPosition +/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ (_speed * 1.0f);
                    _playerStates.PlayerMovementStates = PlayerMovementStates.WalkingRight;
                    _lastRight = true;
                    noMovement = false;
                }
            }
            else if (kstate.IsKeyDown(Keys.A) && !kstate.IsKeyDown(Keys.D))
            {
                if (kstate.IsKeyDown(Keys.LeftShift))
                {
                    xPosition = _xPosition -/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ (_speed * 3.0f);
                    _playerStates.PlayerMovementStates = PlayerMovementStates.RunningLeft;
                    _lastRight = false;
                    noMovement = false;
                }
                else
                {
                    xPosition = _xPosition -/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ (_speed * 1.0f);
                    _playerStates.PlayerMovementStates = PlayerMovementStates.WalkingLeft;
                    _lastRight = false;
                    noMovement = false;
                }
            }

            if (kstate.IsKeyDown(Keys.W))
            {
                if (kstate.IsKeyDown(Keys.LeftShift))
                {
                    yPosition = _yPosition -/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ 3.0f;
                    _playerStates.PlayerMovementStates = _lastRight ? PlayerMovementStates.RunningRight : PlayerMovementStates.RunningLeft;
                    noMovement = false;
                }
                else
                {
                    yPosition = _yPosition -/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ 1.0f;
                    _playerStates.PlayerMovementStates = _lastRight ? PlayerMovementStates.WalkingRight : PlayerMovementStates.WalkingLeft;
                    noMovement = false;
                }
            }
            else if (kstate.IsKeyDown(Keys.S))
            {
                if (kstate.IsKeyDown(Keys.LeftShift))
                {
                    yPosition = _yPosition +/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ 3.0f;
                    _playerStates.PlayerMovementStates = _lastRight ? PlayerMovementStates.RunningRight : PlayerMovementStates.RunningLeft;
                    noMovement = false;
                }
                else
                {
                    yPosition = _yPosition +/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ 1.0f;
                    _playerStates.PlayerMovementStates = _lastRight ? PlayerMovementStates.WalkingRight : PlayerMovementStates.WalkingLeft;
                    noMovement = false;
                }
            }

            if (noMovement)
            {
                if (_lastRight)
                {
                    _playerStates.PlayerMovementStates = PlayerMovementStates.IdleRight;
                }
                else
                {
                    _playerStates.PlayerMovementStates = PlayerMovementStates.IdleLeft;
                }
            }
            else
            {
                var xCollision = xPosition == 0 ? _xPosition : xPosition;
                var yCollision = yPosition == 0 ? _yPosition : yPosition;
                var result = _map.CheckForCollision(this, xCollision, yCollision);
                if (!result)
                {
                    if (xPosition != 0.0f)
                        _xPosition = xPosition;

                    if (yPosition != 0.0f)
                        _yPosition = yPosition;
                }
            }
            base.Update(elapsedTime);
        }

        public override Vector2 GetPosition()
        {
            return new Vector2(_xPosition, _yPosition);
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"

        #endregion

        #region "--------------------------------- Events ----------------------------------"
        private enum WalkingStates
        {
            Idle,
            Left,
            Up,
            Right,
            Down
        }
        #endregion
        #endregion
    }
}