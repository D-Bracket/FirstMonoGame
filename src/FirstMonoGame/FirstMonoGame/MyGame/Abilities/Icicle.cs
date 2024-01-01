using FirstMonoGame.Base._2D.Renderer;
using FirstMonoGame.Base._2D.Sprites;
using FirstMonoGame.Base.Sprites.Animation;
using FirstMonoGame.PlugIns.AbilitySystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMonoGame.MyGame.Abilities
{
    internal class Icicle : AbilityBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        private SpriteAnimation _spriteSource;

        private float _spriteScale = 3.0f;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public Icicle(ContentManager content)
        {
            var tileMapSettings = new SpriteSourceTileMapSettings(new SpriteGroup[1]);
            tileMapSettings.SpriteGroups[0].SpriteLayout = SpriteLayouts.Horizontally;
            tileMapSettings.SpriteGroups[0].SpriteHeight = 96;
            tileMapSettings.SpriteGroups[0].SpriteWidth = 64;
            tileMapSettings.SpriteGroups[0].StartPoint = new IntVector2(0, 0);
            tileMapSettings.SpriteGroups[0].NumberOfColumns = 23;
            tileMapSettings.SpriteGroups[0].NumberOfRows = 1;
            tileMapSettings.SpriteGroups[0].NumberOfSprites = 23;

            var tiledSource = new TileMapSpriteSource(content.Load<Texture2D>("Effects/Magic/ice_b1_tileset"), tileMapSettings, _spriteScale);
            _spriteSource = new(tiledSource, 1, 100);
        }

        public override void GetDrawInfo(ref DrawInfo2D drawInfo)
        {
            
        }

        public override Vector2 GetPosition()
        {
            throw new NotImplementedException();
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

        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}