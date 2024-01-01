using FirstMonoGame.Base._2D.Renderer;
using Microsoft.Xna.Framework.Content;

namespace FirstMonoGame.Base.Sprites.Animation
{
    internal abstract class SpriteAnimationController
    {
        #region "----------------------------- Private Fields ------------------------------"
        protected ContentManager _content;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public SpriteAnimationController(ContentManager content)
        {
            _content = content;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public abstract void Tick(double time);

        public abstract void GetDrawInfoSprite(ref DrawInfo2D drawInfo);

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