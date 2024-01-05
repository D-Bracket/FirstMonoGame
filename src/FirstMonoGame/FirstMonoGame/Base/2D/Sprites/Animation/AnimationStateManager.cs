using FirstMonoGame.Base._2D.Actor;
using FirstMonoGame.Base.Sprites.Animation;
using System.Collections.Generic;

namespace FirstMonoGame.Base._2D.Sprites.Animation
{
    public abstract class AnimationStateManager
    {
        #region "----------------------------- Private Fields ------------------------------"
        protected ActorBase _actor;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        internal void Initialize(ActorBase actor)
        {
            _actor = actor;
        }

        public abstract void Update(double elapsedTime);

        public SpriteAnimation GetCurrentAnimation()
        {
            return CurrentAnimation;
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public Dictionary<string, SpriteAnimation> Animations { get; private set; } = new();

        public SpriteAnimation CurrentAnimation { get; protected set; }
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}