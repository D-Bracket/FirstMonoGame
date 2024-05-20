using FirstMonoGame.Base._2D.Actor.Components;
using FirstMonoGame.Base._2D.Renderer;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FirstMonoGame.Base._2D.Actor
{
    public abstract class Actor2DBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        internal float _xPosition;
        internal float _yPosition;
        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public virtual Vector2 GetPosition()
        {
            return new Vector2(_xPosition, _yPosition);
        }

        public Vector2 GetWidthAndHeight()
        {
            if (HasToBeRendered)
            {
                var animator = Components.FirstOrDefault(x => x.GetType() == typeof(SpriteAnimatorComponent)) as SpriteAnimatorComponent;
                var drawInfo = new DrawInfo2D();
                animator.GetDrawInfoSprite(drawInfo);

                return new Vector2(drawInfo.SourceRectancle.Width*drawInfo.SpriteScale, drawInfo.SourceRectancle.Height * drawInfo.SpriteScale);
            }
            else
            {
                return new Vector2();
            }
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

        public void AddComponent(Actor2DComponentBase component)
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

        public double Width
        {
            get
            {
                if (HasToBeRendered)
                {
                    var animator = Components.FirstOrDefault(x => x.GetType() == typeof(SpriteAnimatorComponent)) as SpriteAnimatorComponent;
                    var drawInfo = new DrawInfo2D();
                    animator.GetDrawInfoSprite(drawInfo);

                    return drawInfo.SourceRectancle.Width;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double Height
        {
            get
            {
                if (HasToBeRendered)
                {
                    var animator = Components.FirstOrDefault(x => x.GetType() == typeof(SpriteAnimatorComponent)) as SpriteAnimatorComponent;
                    var drawInfo = new DrawInfo2D();
                    animator.GetDrawInfoSprite(drawInfo);

                    return drawInfo.SourceRectancle.Height;
                }
                else
                {
                    return 0;
                }
            }
        }

        public IList<Actor2DComponentBase> Components { get; protected set; } = new List<Actor2DComponentBase>();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}