using FirstMonoGame.Base._2D.Renderer;
using System.Collections.Generic;

namespace FirstMonoGame.Base._2D.Sprites
{
    public abstract class SpriteSourceBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        protected float _spriteScale;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public SpriteSourceBase(float spriteScale)
        {
            _spriteScale = spriteScale;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public abstract void GetDrawInfo(ref DrawInfo2D drawInfo, int spriteGroupNumber, int spriteNumber);
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public Dictionary<int, int> SpriteGroupSpriteCount { get; } = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}