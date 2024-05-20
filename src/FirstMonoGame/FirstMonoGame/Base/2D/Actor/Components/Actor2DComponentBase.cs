namespace FirstMonoGame.Base._2D.Actor.Components
{
    public abstract class Actor2DComponentBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        protected Actor2DBase _actor;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public Actor2DComponentBase(Actor2DBase actor)
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