using FirstMonoGame.Base._2D.Renderer;
using FirstMonoGame.Base.Actor;
using FirstMonoGame.Base.Sprites.Animation;

namespace FirstMonoGame.Base.Character
{
    internal abstract class CharacterBase : ActorBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        protected SpriteAnimationController _animationController;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public CharacterBase()
        {

        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public override void Update(double elapsedTime)
        {
            _animationController.Tick(elapsedTime);
        }


        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        protected void SetAnimationController(SpriteAnimationController animationController)
        {
            _animationController = animationController;
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        //public CharacterStates CharacterStates { get; protected set; }
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}