using FirstMonoGame.Base.Character;

namespace FirstMonoGame.MyGame.Characters.Player
{
    internal class PlayerStates : CharacterStates
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public PlayerMovementStates PlayerMovementStates { get; set; }
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }

    public enum PlayerMovementStates
    {
        IdleLeft,
        IdleRight,
        WalkingLeft,
        WalkingRight,
        RunningLeft,
        RunningRight
    }
}