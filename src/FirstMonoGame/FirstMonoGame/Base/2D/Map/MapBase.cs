using FirstMonoGame.Base._2D.Cameras;
using FirstMonoGame.Base._2D.Actor;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace FirstMonoGame.Base._2D.Map
{
    internal abstract class MapBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        protected Camera2D _camera;

        protected int _numberOfColumns, _numberOfRows;

        public float TileScale { get; set; } = 1.0f;
        internal Dictionary<string, ActorBase> _actors = new();
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public MapBase(int width, int height, int numberOfColumns, int numberOfRows)
        {
            _camera = new Camera2D(this);
            Width = width;
            Height = height;
            _numberOfColumns = numberOfColumns;
            _numberOfRows = numberOfRows;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public abstract void LoadContent(ContentManager content);

        //public abstract void GetRenderDetails(Vector2 center, Rectangle bounds, DrawInfo2D drawInfo, Func<DrawInfo2D, bool> drawCallBack);

        public virtual void Update(double elapsedTime)
        {
            foreach (var actor in _actors.Values)
            {
                actor.Update(elapsedTime);
            }
        }

        //public virtual void GetActorRenderInformation(Vector2 center, DrawInfo2D drawInfo, Func<DrawInfo2D, bool> drawCallBack)
        //{

        //}
        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public int Width { get; private set; }
        public int Height { get; private set; }

        public int TileXSize { get; protected set; }
        public int TileYSize { get; protected set; }

        public MapTile[,] Tiles { get; set; }
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion

    }
}