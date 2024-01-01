using FirstMonoGame.Base._2D.Renderer;
using Microsoft.Xna.Framework;

namespace FirstMonoGame.Base.Actor
{
    public abstract class ActorBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        protected float _xPosition;
        protected float _yPosition;
        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public virtual Vector2 GetPosition()
        {
            return new Vector2(_xPosition, _yPosition);
        }

        public virtual void Update(double elapsedTime)
        {

        }

        public abstract void GetDrawInfo(ref DrawInfo2D drawInfo);

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public bool HasToBeRendered { get; protected set; } = true;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}