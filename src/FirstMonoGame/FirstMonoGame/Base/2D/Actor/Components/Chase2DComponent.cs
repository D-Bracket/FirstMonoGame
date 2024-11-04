using FirstMonoGame.Base._2D.Sprites.Animation;
using Microsoft.Xna.Framework;
using System;

namespace FirstMonoGame.Base._2D.Actor.Components
{
    public class Chase2DComponent : Actor2DComponentBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        private Actor2DBase _actorToChase;
        private Actor2DBase _self;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public Chase2DComponent(Actor2DBase actor) : base(actor)
        {
            _self = actor;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void SetTarget(Actor2DBase actorToChase)
        {
            _actorToChase = actorToChase;
        }

        public override void Update(double elapsedTime)
        {
            if (_actorToChase is null)
                return;

            var maxDistance = 0.2f * (float)elapsedTime; // speed * eleapsed time
            var newLocation = MovePoint(new Vector2(_self._xPosition, _self._yPosition), new Vector2(_actorToChase._xPosition, _actorToChase._yPosition), maxDistance);
            _self._xPosition = newLocation.X;
            _self._yPosition = newLocation.Y;
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        private Vector2 MovePoint(Vector2 source, Vector2 target, float maxDistance)
        {
            // # Calculate the distance between source and target
            float distance = (float)Math.Sqrt(Math.Pow((target.X - source.X), 2) + Math.Pow((target.Y - source.Y), 2));

            // If the target is within reach, return the target
            if (distance <= maxDistance)
                return target;

            // Otherwise move source to target
            float directionX = (target.X - source.X) / distance;
            float directionY = (target.Y - source.Y) / distance;

            Vector2 newPoint = new Vector2(
                source.X + directionX * maxDistance,
                source.Y + directionY * maxDistance
                );

            return newPoint;
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