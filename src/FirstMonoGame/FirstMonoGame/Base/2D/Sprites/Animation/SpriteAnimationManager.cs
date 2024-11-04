using FirstMonoGame.Base.Sprites.Animation;
using Microsoft.Xna.Framework.Content;

namespace FirstMonoGame.Base._2D.Sprites.Animation
{
    public class SpriteAnimationManager : AnimationStateManager
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public SpriteAnimationManager(ContentManager content, SpriteAnimation[] spriteAnimationCollection)
        {
            CurrentAnimation = spriteAnimationCollection[0];
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public override void Update(double elapsedTime)
        {

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