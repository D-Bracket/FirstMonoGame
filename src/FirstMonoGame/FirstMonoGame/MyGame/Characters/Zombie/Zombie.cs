using FirstMonoGame.Base._2D.Actor.Components;
using FirstMonoGame.Base.Character;
using FirstMonoGame.MyGame.Characters.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace FirstMonoGame.MyGame.Characters.Zombie
{
    internal class Zombie : CharacterBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        private float _speed = 7.0f;

        private ZombieStates _states;
        private ZombieAnimationManager _animationManager;

        private bool _lastRight = true;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public Zombie()
        {
            
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void Init(ContentManager content, float xPosition = 0.0f, float yPosition = 0.0f)
        {
            _states = new ZombieStates();
            _animationManager = new ZombieAnimationManager(content, _states);
            AddComponent(new SpriteAnimatorComponent(this, _animationManager));
            _xPosition = xPosition;
            _yPosition = yPosition;
        }

        public override void Update(double elapsedTime)
        {
            // var kstate = Keyboard.GetState();
            // var noMovement = true;
            // if (kstate.IsKeyDown(Keys.D) && !kstate.IsKeyDown(Keys.A))
            // {
            //     if (kstate.IsKeyDown(Keys.LeftShift))
            //     {
            //         _xPosition +=/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ 3.0f;
            //         _playerStates.PlayerMovementStates = PlayerMovementStates.RunningRight;
            //         _lastRight = true;
            //         noMovement = false;
            //     }
            //     else
            //     {
            //         _xPosition +=/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ 1.0f;
            //         _playerStates.PlayerMovementStates = PlayerMovementStates.WalkingRight;
            //         _lastRight = true;
            //         noMovement = false;
            //     }
            // }
            // else if (kstate.IsKeyDown(Keys.A) && !kstate.IsKeyDown(Keys.D))
            // {
            //     if (kstate.IsKeyDown(Keys.LeftShift))
            //     {
            //         _xPosition -=/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ 3.0f;
            //         _playerStates.PlayerMovementStates = PlayerMovementStates.RunningLeft;
            //         _lastRight = false;
            //         noMovement = false;
            //     }
            //     else
            //     {
            //         _xPosition -=/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ 1.0f;
            //         _playerStates.PlayerMovementStates = PlayerMovementStates.WalkingLeft;
            //         _lastRight = false;
            //         noMovement = false;
            //     }
            // }

            // if (kstate.IsKeyDown(Keys.W))
            // {
            //     if (kstate.IsKeyDown(Keys.LeftShift))
            //     {
            //         _yPosition -=/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ 3.0f;
            //         _playerStates.PlayerMovementStates = _lastRight ? PlayerMovementStates.RunningRight : PlayerMovementStates.RunningLeft;
            //         noMovement = false;
            //     }
            //     else
            //     {
            //         _yPosition -=/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ 1.0f;
            //         _playerStates.PlayerMovementStates = _lastRight ? PlayerMovementStates.WalkingRight : PlayerMovementStates.WalkingLeft;
            //         noMovement = false;
            //     }
            // }
            // else if (kstate.IsKeyDown(Keys.S))
            // {
            //     if (kstate.IsKeyDown(Keys.LeftShift))
            //     {
            //         _yPosition +=/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ 3.0f;
            //         _playerStates.PlayerMovementStates = _lastRight ? PlayerMovementStates.RunningRight : PlayerMovementStates.RunningLeft;
            //         noMovement = false;
            //     }
            //     else
            //     {
            //         _yPosition +=/* MathF.Round(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds) +*/ 1.0f;
            //         _playerStates.PlayerMovementStates = _lastRight ? PlayerMovementStates.WalkingRight : PlayerMovementStates.WalkingLeft;
            //         noMovement = false;
            //     }
            // }

            // if (noMovement)
            // {
            //     if (_lastRight)
            //     {
            //         _playerStates.PlayerMovementStates = PlayerMovementStates.IdleRight;
            //     }
            //     else
            //     {
            //         _playerStates.PlayerMovementStates = PlayerMovementStates.IdleLeft;
            //     }
            // }
            _states.PlayerMovementStates = PlayerMovementStates.IdleRight;
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

        #endregion
        #endregion
    }
}