using FirstMonoGame.Base._2D.Cameras;
using FirstMonoGame.MyGame.Characters.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMonoGame.Base._2D.Renderer
{
    internal class Renderer2D
    {
        #region "----------------------------- Private Fields ------------------------------"
        // This is not good, but I'm leaving it for now, until I know, what else I need to complete the architecture
        private static Dictionary<string, Camera2D> _cameraList = new();


        private SpriteBatch _spriteBatch;
        private DrawInfo2D _drawInfo = new DrawInfo2D();
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public Renderer2D(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public static void RegisterCamera(string name, Camera2D camera)
        {
            _cameraList.Add(name, camera);
        }

        public void UnregisterCamera(string name)
        {
            _cameraList.Remove(name);
        }

        public void RenderCameraScene()
        {

            _spriteBatch.Begin();

            foreach (var camera in _cameraList)
            {
                camera.Value.RenderScene(_drawInfo, RenderContent);
            }

            _spriteBatch.End();
        }

        private bool RenderContent(DrawInfo2D drawInfo)
        {
            if (drawInfo.IsTileMap)
            {
                //drawInfo.DestinationRectancle =
                //    new Rectangle(
                //        drawInfo.DestinationRectancle.X,
                //        drawInfo.DestinationRectancle.Y,
                //        drawInfo.SourceRectancle.Width * 4,
                //        drawInfo.SourceRectancle.Height * 4);
                _spriteBatch.Draw(drawInfo.Sprite, drawInfo.DestinationRectancle, drawInfo.SourceRectancle, Color.White);
            }
            else
            {
                var t = new Rectangle(0, 0, 120, 120);
                var effect = new SpriteEffects();
                //var scale = 4.0f;
                _spriteBatch.Draw(drawInfo.Sprite, new Vector2(drawInfo.XPosition, drawInfo.YPosition), t, Color.White, 0, new Vector2(0, 0), drawInfo.SpriteScale, effect, 1);
            }
            return true;
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