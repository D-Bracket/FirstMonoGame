using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstMonoGame.Base._2D.Renderer
{
    public class DrawInfo2D
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public DrawInfo2D()
        {
            
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void SetDrawInfoTileMap(Texture2D sprite, Rectangle sourceRectancle, float spriteScale)//, Rectangle destinationRectangle)//, float xPositon, float yPosition)
        {
            IsTileMap = true;
            Sprite = sprite;
            SourceRectancle = sourceRectancle;
            SpriteScale = spriteScale;
        }


        public void SetDrawInfoSprite(Texture2D sprite, float spriteScale)//, float xPositon, float yPosition)
        {
            IsTileMap = false;
            Sprite = sprite;
            SpriteScale = spriteScale;
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public bool IsTileMap { get; private set; }
        public Texture2D Sprite { get; private set; }
        public Rectangle SourceRectancle { get; private set; }
        public Rectangle DestinationRectancle { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float SpriteScale { get; set; }
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}