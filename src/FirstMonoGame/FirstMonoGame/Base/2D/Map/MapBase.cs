using FirstMonoGame.Base._2D.Cameras;
using FirstMonoGame.Base._2D.Actor;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using FirstMonoGame.Base._2D.Renderer;
using System.Diagnostics;

namespace FirstMonoGame.Base._2D.Map
{
    internal abstract class MapBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        protected Camera2D _camera;

        protected int _numberOfColumns, _numberOfRows;

        public float TileScale { get; set; } = 1.0f;
        internal Dictionary<string, Actor2DBase> _actors = new();
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

        public bool CheckForCollision(Actor2DBase movingActor, double newX, double newY)
        {
            // movingActor rectangle

            var x = (int)newX - (int)movingActor.Width;
            var y = (int)newY - (int)movingActor.Height;
            //var movingRectangle = new Microsoft.Xna.Framework.Rectangle((int)newX, (int)newY, (int)movingActor.Width, (int)movingActor.Height);
            var movingRectangle = new Microsoft.Xna.Framework.Rectangle((int)newX, (int)newY, 18, 18);

            foreach (var actor in _actors)
            {
                //if (actor.Equals(movingActor))
                //    continue;
                if (actor.Value.GetHashCode() == movingActor.GetHashCode())
                    continue;

                //x = (int)actor.Value._xPosition - (int)actor.Value.Width;
                //y = (int)actor.Value._yPosition - (int)actor.Value.Height;
                //var actorRectangle = new Microsoft.Xna.Framework.Rectangle((int)x, (int)y, (int)actor.Value.Width, (int)actor.Value.Height);                
                //var actorRectangle = new Microsoft.Xna.Framework.Rectangle((int)actor.Value._xPosition, (int)actor.Value._yPosition, (int)actor.Value.Width, (int)actor.Value.Height);                
                var actorRectangle = new Microsoft.Xna.Framework.Rectangle((int)actor.Value._xPosition, (int)actor.Value._yPosition, 18, 8);


                //actor.Value.GetDrawInfo(ref drawInfo);
                var result = actorRectangle.Intersects(movingRectangle);
                if (result)
                {
                    Debug.WriteLine("Player, collision with other actor");
                    return true;
                }
                else
                {
                    Debug.WriteLine("No collision detected: ");
                }

                //if (actor.GetHashCode() == movingActor.GetHashCode())
                //    continue;

                //var heightAndWidth = movingActor.GetWidthAndHeight();
                //var l1 = movingActor.GetPosition();
                //var r1 = new Vector2(l1.X + heightAndWidth.X, l1.Y + heightAndWidth.Y);

                //heightAndWidth = actor.Value.GetWidthAndHeight();
                //var l2 = actor.Value.GetPosition();
                //var r2 = new Vector2(l2.X + heightAndWidth.X, l2.Y + heightAndWidth.Y);
                //var result = doOverlap(l1, r1, l2, r2);
                //if (result)
                //    return true;
            }
            return false;
        }

        bool doOver(Vector2 RectA, Vector2 RectAEnd, Vector2 RectB, Vector2 RectBEnd)
        {
            //if (RectA.X < RectBEnd.X && RectAEnd.X > RectB.X &&
            //    RectA.Y > RectBEnd.Y && RectAEnd.Y < RectB.Y)
            //    return true;

            return false;
        }

        bool doOverlap(Vector2 l1, Vector2 r1, Vector2 l2, Vector2 r2)
        {
            if (l1.X > r2.X || l2.X > r1.X)
                return false;

            if (l1.Y > r2.Y || l2.Y > r1.Y)
                return false;

            return true;


            //// if rectangle has area 0, no overlap
            //if (l1.X == r1.X || l1.Y == r1.Y || r2.X == l2.X || l2.Y == r2.Y)
            //    return false;

            //// If one rectangle is on left side of other
            //if (l1.X > r2.X || l2.X > r1.X)
            //    return false;

            //// If one rectangle is above other
            //if (r1.Y > l2.Y || r2.Y > l1.Y)
            //    return false;

            //return true;
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