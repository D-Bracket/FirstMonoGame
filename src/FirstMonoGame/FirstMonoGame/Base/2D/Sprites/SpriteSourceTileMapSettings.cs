namespace FirstMonoGame.Base._2D.Sprites
{
    public class SpriteSourceTileMapSettings
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public SpriteSourceTileMapSettings(SpriteGroup[] spriteGroups)
        {
            SpriteGroups = spriteGroups;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public SpriteGroup[] SpriteGroups { get; }
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }

    /// <summary>Describes a group of sprites on a tilemap</summary>
    public struct SpriteGroup
    {
        public IntVector2 StartPoint { get; set; }
        public int NumberOfSprites { get; set; }
        public int SpriteWidth { get; set; }
        public int SpriteHeight { get; set; }
        public int NumberOfColumns { get; set; }
        public int NumberOfRows { get; set; }
        public SpriteLayouts SpriteLayout { get; set; }
    }

    public struct IntVector2
    {
        public IntVector2(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public enum SpriteLayouts
    {
        Horizontally,
        Vertically
    }
}
