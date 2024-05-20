using FirstMonoGame.Base._2D.Actor;

namespace FirstMonoGame.Base.Character
{
    internal abstract class CharacterBase : Actor2DBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public CharacterBase()
        {

        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public override void Update(double elapsedTime)
        {
            base.Update(elapsedTime);
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