using FirstMonoGame.Base._2D.Renderer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace FirstMonoGame.Base._2D.Sprites
{
    public class TileMapSpriteSource : SpriteSourceBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        private Texture2D _tileMap;
        private SpriteSourceTileMapSettings _settings;
        private Dictionary<int, Dictionary<int, Rectangle>> _tileMapRectangles = new();
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public TileMapSpriteSource(Texture2D tileMap, SpriteSourceTileMapSettings settings, float spriteScale)
            : base(spriteScale)
        {
            _tileMap = tileMap;
            _settings = settings;

            int groupNumber = 1;
            foreach (var spriteGroup in settings.SpriteGroups)
            {
                var rectangles = new Dictionary<int, Rectangle>();
                for (int number = 0; number < spriteGroup.NumberOfSprites; number++)
                {
                    rectangles.Add(number, InitRectangle(spriteGroup, number));
                }
                _tileMapRectangles.Add(groupNumber, rectangles);
                SpriteGroupSpriteCount.Add(SpriteGroupSpriteCount.Count + 1, spriteGroup.NumberOfSprites);
                groupNumber++;
            }
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public override void GetDrawInfo(ref DrawInfo2D drawInfo, int spriteGroupNumber, int index)
        {
            drawInfo.SetDrawInfoTileMap(_tileMap, _tileMapRectangles[spriteGroupNumber][index], _spriteScale);
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        private static Rectangle InitRectangle(SpriteGroup spriteGroup, int number)
        {
            int row;
            int column;
            if (spriteGroup.SpriteLayout == SpriteLayouts.Horizontally)
            {
                row = number == 0 ? 0 : number / spriteGroup.NumberOfColumns;
                column = number == 0 ? 0 : number % spriteGroup.NumberOfColumns;
            }
            else
            {
                row = number % spriteGroup.NumberOfColumns;
                column = number / spriteGroup.NumberOfColumns;
            }
            int x = spriteGroup.StartPoint.X + (column * spriteGroup.SpriteWidth);
            int y = spriteGroup.StartPoint.Y + (row * spriteGroup.SpriteHeight);
            return new Rectangle(x, y, spriteGroup.SpriteWidth, spriteGroup.SpriteHeight);
        }
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