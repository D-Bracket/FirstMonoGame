using FirstMonoGame.Base._2D.Renderer;

namespace FirstMonoGame.Base._2D.Sprites
{
    public class TileMapSprite
    {
        #region "----------------------------- Private Fields ------------------------------"
        private TileMapSpriteSource _tileMapSpriteSource;
        private int _groupNumber;
        private int _spriteIndex;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public TileMapSprite(TileMapSpriteSource tileMapSpriteSource, int groupNumber, int index)
        {
            _tileMapSpriteSource = tileMapSpriteSource;
            _groupNumber = groupNumber;
            _spriteIndex = index;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void GetDrawInfo(ref DrawInfo2D drawInfo)
        {
            _tileMapSpriteSource.GetDrawInfo(ref drawInfo, _groupNumber, _spriteIndex);
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