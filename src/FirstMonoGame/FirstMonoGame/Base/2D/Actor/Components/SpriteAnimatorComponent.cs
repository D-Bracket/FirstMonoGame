using FirstMonoGame.Base._2D.Renderer;
using FirstMonoGame.Base._2D.Sprites.Animation;
using FirstMonoGame.Base.Sprites.Animation;

namespace FirstMonoGame.Base._2D.Actor.Components
{
    public class SpriteAnimatorComponent : ActorComponentBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        // Remote, that sets the current animation and must be created for each character
        private AnimationStateManager _stateManager;

        private SpriteAnimation _currentAnimation;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public SpriteAnimatorComponent(ActorBase actor, AnimationStateManager stateManager) : base(actor)
        {
            _stateManager = stateManager;
            _stateManager.Initialize(actor);
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public override void Update(double elapsedTime)
        {
            _stateManager.Update(elapsedTime);
            var animation = _stateManager.GetCurrentAnimation();

            if (_currentAnimation != animation)
            {
                _currentAnimation = animation;
                _currentAnimation.Reset();
                return;
            }
            _currentAnimation?.Tick(elapsedTime);
        }

        public void GetDrawInfoSprite(DrawInfo2D drawInfo)
        {
            if (_currentAnimation is not null)
            {
                _currentAnimation.GetDrawInfoSprite(ref drawInfo);
            }
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