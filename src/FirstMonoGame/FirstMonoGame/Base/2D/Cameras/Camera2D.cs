using FirstMonoGame.Base._2D.Map;
using FirstMonoGame.Base._2D.Renderer;
using FirstMonoGame.Base._2D.Actor;
using Microsoft.Xna.Framework;
using System;

namespace FirstMonoGame.Base._2D.Cameras
{
    internal class Camera2D
    {
        #region "----------------------------- Private Fields ------------------------------"
        // Camera is attached to object; has bounds that are dependend on the resolution
        // Camera calls map -> give sprites to render

        // ToDo
        // Inject RenderDetails, to get Bounds
        private MapBase _map;

        private Actor2DBase _actor;

        private ResolutionSettings _resolutionSettings;

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public Camera2D(MapBase map)
        {
            _map = map;
            _resolutionSettings = ResolutionSettings.GetInstance();

            Renderer2D.RegisterCamera("Map1", this);
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void AttachCameraToActor(Actor2DBase actor)
        {
            _actor = actor;
        }

        public void RenderScene(DrawInfo2D drawInfo, Func<DrawInfo2D, bool> renderCallback)
        {
            var resolution = _resolutionSettings.CurrentResolution;
            int xLength, yLength;
            int xLength_1, yLength_1;
            Vector2 center = _actor.GetPosition();
            MapTile centerTile;
            int xStartIndex, yStartIndex;
            float xOffset, yOffset;
            float xStartPoint, yStartPoint;
            Rectangle bounds;


            CalculateRenderDimensions();
            RenderMap();
            RenderActors();


            void CalculateRenderDimensions()
            {
                // Step1: Get the Number of tiles to render + 1
                // Horizontal tiles to render + 1
                xLength = (int)(resolution.Width / resolution.SpriteScale / _map.TileXSize);
                xLength_1 = xLength + 1;
                // Vertical tiles to render + 1
                yLength = (int)(resolution.Height / resolution.SpriteScale / _map.TileYSize);
                yLength_1 = yLength + 1;

                // Step2: Find all the tile indices
                centerTile = _map.Tiles[(int)(center.X / _map.TileXSize), (int)(center.Y / _map.TileYSize)];
                xStartIndex = centerTile.XPosition - xLength / 2 - 1;
                yStartIndex = centerTile.YPosition - yLength / 2 - 1;

                // Step3: Find the StartPOINTs
                // Horizontal StartPOINT
                xOffset = center.X - centerTile.XPosition * _map.TileXSize;
                xStartPoint = -xOffset * drawInfo.SpriteScale;
                // Vertical StartPOINT
                yOffset = center.Y - centerTile.YPosition * _map.TileYSize;
                yStartPoint = -yOffset * drawInfo.SpriteScale;

                bounds = new Rectangle(
                    xStartIndex * _map.TileXSize,
                    yStartIndex * _map.TileYSize,
                    xLength_1 * _map.TileXSize,
                    yLength_1 * _map.TileYSize);
            }

            void RenderMap()
            {
                for (int i = xStartIndex; i < xStartIndex + xLength_1; i++)
                {
                    for (int j = yStartIndex; j < yStartIndex + yLength_1; j++)
                    {
                        _map.Tiles[j, i].TerrainTexture.GetDrawInfo(ref drawInfo);
                        drawInfo.DestinationRectancle = new Rectangle(
                            (int)(xStartPoint + (i - xStartIndex) * drawInfo.SourceRectancle.Width * drawInfo.SpriteScale),
                            (int)(yStartPoint + (j - yStartIndex) * drawInfo.SourceRectancle.Height * drawInfo.SpriteScale),
                            (int)(drawInfo.SourceRectancle.Width * drawInfo.SpriteScale),
                            (int)(drawInfo.SourceRectancle.Height * drawInfo.SpriteScale));
                        renderCallback(drawInfo);
                    }
                }
            }

            void RenderActors()
            {
                foreach (var actor in _map._actors.Values)
                {
                    if (!actor.HasToBeRendered)
                        continue;

                    // Check if actor is in the camera's view
                    var position = actor.GetPosition();
                    if (position.X < bounds.X || position.X > bounds.X + bounds.Width ||
                        position.Y < bounds.Y || position.Y > bounds.Y + bounds.Height)
                        continue;

                    // Render actor
                    actor.GetDrawInfo(ref drawInfo);

                    var actorX = position.X * _map.TileScale - (center.X * _map.TileScale - (resolution.Width / 2));
                    var actorY = position.Y * _map.TileScale - (center.Y * _map.TileScale - (resolution.Height / 2));

                    var actorWidth = (int)(drawInfo.SourceRectancle.Width * drawInfo.SpriteScale);
                    var actorHeight = (int)(drawInfo.SourceRectancle.Height * drawInfo.SpriteScale);
                    if (drawInfo.IsTileMap)
                    {
                        drawInfo.DestinationRectancle = new Rectangle(
                            (int)actorX - (drawInfo.SourceRectancle.Width * 2),
                            (int)actorY - (drawInfo.SourceRectancle.Height * 2),
                            actorWidth,
                            actorHeight);
                    }
                    else
                    {
                        drawInfo.XPosition = actorX - (drawInfo.Sprite.Bounds.Width * 2);
                        drawInfo.YPosition = actorY - (drawInfo.Sprite.Bounds.Height * 2);
                    }
                    renderCallback(drawInfo);
                }
            }
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"


        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public Rectangle Bounds { get; set; }
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}