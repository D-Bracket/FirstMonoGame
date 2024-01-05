namespace FirstMonoGame.Base._2D.Actor.Components
{
    public abstract class ActorComponentBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        protected ActorBase _actor;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public ActorComponentBase(ActorBase actor)
        {
            _actor = actor;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public abstract void Update(double elapsedTime);
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