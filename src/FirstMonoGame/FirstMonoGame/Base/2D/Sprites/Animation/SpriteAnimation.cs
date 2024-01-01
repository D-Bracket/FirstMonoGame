using FirstMonoGame.Base._2D.Renderer;
using FirstMonoGame.Base._2D.Sprites;

namespace FirstMonoGame.Base.Sprites.Animation
{
    internal class SpriteAnimation
    {
        #region "----------------------------- Private Fields ------------------------------"
        private SpriteSourceBase _spriteSource;
        private int _index;
        private double _frameDelay;

        private double _timeSpentInFrame;

        private int _spriteGroupNumber;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public SpriteAnimation(SpriteSourceBase spriteSource, int spriteGroupNumber, double frameDelay)
        {
            _spriteSource = spriteSource;
            _spriteGroupNumber = spriteGroupNumber;
            _frameDelay = frameDelay;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void Tick(double time)
        {
            _timeSpentInFrame += time;
            if (_timeSpentInFrame > _frameDelay)
            {
                _timeSpentInFrame = 0;
                _index++;
            }
            if (_index >= _spriteSource.SpriteGroupSpriteCount[_spriteGroupNumber])
                _index = 0;
        }

        public void GetDrawInfoSprite(ref DrawInfo2D drawInfo)
        {
            _spriteSource.GetDrawInfo(ref drawInfo, _spriteGroupNumber, _index);
        }

        public void Reset()
        {
            _timeSpentInFrame = 0;
            _index = 0;
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