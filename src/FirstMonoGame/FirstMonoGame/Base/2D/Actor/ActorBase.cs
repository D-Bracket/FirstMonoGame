using FirstMonoGame.Base._2D.Actor.Components;
using FirstMonoGame.Base._2D.Renderer;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FirstMonoGame.Base._2D.Actor
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
            foreach (var component in Components)
            {
                component.Update(elapsedTime);
            }
        }

        public virtual void GetDrawInfo(ref DrawInfo2D drawInfo)
        {
            var animator = Components.FirstOrDefault(x => x.GetType() == typeof(SpriteAnimatorComponent)) as SpriteAnimatorComponent;
            animator.GetDrawInfoSprite(drawInfo);
        }

        public void AddComponent(ActorComponentBase component)
        {
            Components.Add(component);
            if (component is SpriteAnimatorComponent)
                HasToBeRendered = true;
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public bool HasToBeRendered { get; protected set; } = true;

        public IList<ActorComponentBase> Components { get; protected set; } = new List<ActorComponentBase>();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}