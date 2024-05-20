namespace FirstMonoGame.Base
{
    internal class ResolutionSettings
    {
        #region "----------------------------- Private Fields ------------------------------"
        private static ResolutionSettings _instance;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        private ResolutionSettings()
        {
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public static ResolutionSettings GetInstance()
        {
            if (_instance is null)
                _instance = new ResolutionSettings();
            return _instance;
        }

        public void SetResolution(int width, int height, float spriteScale)
        {
            CurrentResolution = new ResolutionInfo(width, height, spriteScale);
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public ResolutionInfo CurrentResolution { get; private set; } 
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }

    public struct ResolutionInfo
    {
        public ResolutionInfo(int width, int height, float spriteScale)
        {
            Width = width; 
            Height = height; 
            SpriteScale = spriteScale;
        }
        public int Width { get; }
        public int Height { get; }
        public float SpriteScale { get; }
    }
}