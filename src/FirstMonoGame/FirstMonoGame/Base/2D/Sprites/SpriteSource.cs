using FirstMonoGame.Base._2D.Renderer;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace FirstMonoGame.Base._2D.Sprites
{
    internal class SpriteSource : SpriteSourceBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        private Dictionary<int, Texture2D[]> _spriteCollection = new();
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public SpriteSource(float spriteScale)
            : base(spriteScale)
        {

        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void AddSpriteGroup(Texture2D[] spriteGroup)
        {
            _spriteCollection.Add(_spriteCollection.Count + 1, spriteGroup);
            SpriteGroupSpriteCount.Add(SpriteGroupSpriteCount.Count + 1, spriteGroup.Length);
        }

        public override void GetDrawInfo(ref DrawInfo2D drawInfo, int spriteGroupNumber, int spriteNumber)
        {
            drawInfo.SetDrawInfoSprite(_spriteCollection[spriteGroupNumber][spriteNumber], _spriteScale);
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