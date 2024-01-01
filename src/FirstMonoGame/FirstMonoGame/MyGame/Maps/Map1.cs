using FirstMonoGame.Base;
using FirstMonoGame.Base._2D.Map;
using FirstMonoGame.Base._2D.Renderer;
using FirstMonoGame.Base._2D.Sprites;
using FirstMonoGame.MyGame.Characters.Player;
using FirstMonoGame.MyGame.Characters.Zombie;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace FirstMonoGame.MyGame.Maps
{
    internal class Map1 : TopDownMap
    {
        #region "----------------------------- Private Fields ------------------------------"
        private Player _player;
        private Zombie _zombie;

        private TileMapSpriteSource _floorTiles;
        private TileMapSprite _floorTile1;
        private TileMapSprite _floorTile2;


        private ResolutionSettings _resolutionSettings;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public Map1(int xSize, int ySize, int numberOfColumns, int numberOfRows) : base(xSize, ySize, numberOfColumns, numberOfRows)
        {
            TileXSize = xSize / numberOfColumns; // Rounding Error!!!
            TileYSize = ySize / numberOfRows;

            TileScale = 3.0f;

            _resolutionSettings = ResolutionSettings.GetInstance();
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public override void LoadContent(ContentManager content)
        {
            var tileMapSettings = new SpriteSourceTileMapSettings(new SpriteGroup[2]);
            tileMapSettings.SpriteGroups[0].SpriteLayout = SpriteLayouts.Horizontally;
            tileMapSettings.SpriteGroups[0].SpriteHeight = 32;
            tileMapSettings.SpriteGroups[0].SpriteWidth = 32;
            //tileMapSettings.SpriteGroups[0].StartPoint = new IntVector2(544, 32);
            tileMapSettings.SpriteGroups[0].StartPoint = new IntVector2(545, 33);
            tileMapSettings.SpriteGroups[0].NumberOfColumns = 1;
            tileMapSettings.SpriteGroups[0].NumberOfRows = 1;
            tileMapSettings.SpriteGroups[0].NumberOfSprites = 1;

            tileMapSettings.SpriteGroups[1].SpriteLayout = SpriteLayouts.Horizontally;
            tileMapSettings.SpriteGroups[1].SpriteHeight = 32;
            tileMapSettings.SpriteGroups[1].SpriteWidth = 32;
            tileMapSettings.SpriteGroups[1].StartPoint = new IntVector2(577, 33);
            tileMapSettings.SpriteGroups[1].NumberOfColumns = 1;
            tileMapSettings.SpriteGroups[1].NumberOfRows = 1;
            tileMapSettings.SpriteGroups[1].NumberOfSprites = 1;

            _floorTiles = new TileMapSpriteSource(content.Load<Texture2D>("Terrain/Old Prison/Tileset-Terrain-old prison"), tileMapSettings, TileScale);

            var rnd = new Random();
            for (int i = 0; i < _numberOfRows; i++)
            {
                for (int j = 0; j < _numberOfColumns; j++)
                {
                    int t = rnd.Next(1, 100);
                    if (t < 51)
                        t = 1;
                    else
                        t = 2;

                    Tiles[i, j].TerrainTexture = new TileMapSprite(_floorTiles, t, 0);
                }
            }

            _player = new Player();
            _player.Init(content, Width / 2, Height / 2);
            _camera.AttachCameraToActor(_player);
            _actors.Add("Player", _player);

            _zombie = new Zombie();
            _zombie.Init(content, Width / 2 -300, Height / 2 -300);
            _actors.Add("Zombie", _zombie);
        }

        public override void Update(double elapsedTime)
        {
            base.Update(elapsedTime);
        }

        //public void GetDrawInfo(ref DrawInfo2D drawInfo)
        //{
        //    _floorTiles.GetDrawInfo(ref drawInfo, 1, 0);
        //    drawInfo.DestinationRectancle = new Rectangle(0, 0, drawInfo.SourceRectancle.Width, drawInfo.SourceRectancle.Height);
        //}

        //public override void GetRenderDetails(Vector2 center, Rectangle bounds, DrawInfo2D drawInfo, Func<DrawInfo2D, bool> drawCallBack)
        //{
        //    _player.GetDrawInfo(ref drawInfo);
        //    var playerWidth = (int)(drawInfo.SourceRectancle.Width * drawInfo.SpriteScale);
        //    var playerHeight = (int)(drawInfo.SourceRectancle.Height * drawInfo.SpriteScale);
        //    if (drawInfo.IsTileMap)
        //    {
        //        drawInfo.DestinationRectancle = new Rectangle(
        //            (int)_resolutionSettings.CurrentResolution.Width / 2 - 240,
        //            (int)_resolutionSettings.CurrentResolution.Height / 2 - 240,
        //            playerWidth,
        //            playerHeight);
        //    }
        //    else
        //    {
        //        drawInfo.XPosition = _resolutionSettings.CurrentResolution.Width / 2 - 240;
        //        drawInfo.YPosition = _resolutionSettings.CurrentResolution.Height / 2 - 240;
        //    }
        //    drawCallBack(drawInfo);



        //    _zombie.GetDrawInfo(ref drawInfo);
        //    playerWidth = (int)(drawInfo.SourceRectancle.Width * drawInfo.SpriteScale);
        //    playerHeight = (int)(drawInfo.SourceRectancle.Height * drawInfo.SpriteScale);
        //                if (drawInfo.IsTileMap)
        //    {
        //        drawInfo.DestinationRectancle = new Rectangle(
        //            100,
        //            100,
        //            playerWidth,
        //            playerHeight);
        //    }
        //    else
        //    {
        //        drawInfo.XPosition = 100;
        //        drawInfo.YPosition = 100;
        //    }
        //    drawCallBack(drawInfo);
        //}

        //public override void GetActorRenderInformation(Vector2 center, DrawInfo2D drawInfo, Func<DrawInfo2D, bool> drawCallBack)
        //{
        //    base.GetActorRenderInformation(center, drawInfo, drawCallBack);
        //}
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