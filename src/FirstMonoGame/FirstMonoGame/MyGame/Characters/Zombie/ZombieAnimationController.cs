using FirstMonoGame.Base._2D.Renderer;
using FirstMonoGame.Base._2D.Sprites;
using FirstMonoGame.Base.Sprites.Animation;
using FirstMonoGame.MyGame.Characters.Player;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace FirstMonoGame.MyGame.Characters.Zombie
{
    //internal class ZombieAnimationController : SpriteAnimationController
    //{
    //    #region "----------------------------- Private Fields ------------------------------"
    //    private ZombieStates _zombieStates;

    //    private SpriteAnimation _animation_Idle_Right;

    //    private SpriteAnimation _currentAnimation;
    //    private PlayerMovementStates _previousMovementStates;

    //    private float _zombieScale = 3.0f;
    //    #endregion



    //    #region "------------------------------ Constructor --------------------------------"
    //    public ZombieAnimationController(ContentManager content, ZombieStates zombieStates) : base(content)
    //    {
    //        _zombieStates = zombieStates;

    //        var tileMapSettings = new SpriteSourceTileMapSettings(new SpriteGroup[1]);
    //        tileMapSettings.SpriteGroups[0].SpriteLayout = SpriteLayouts.Horizontally;
    //        tileMapSettings.SpriteGroups[0].SpriteHeight = 120;
    //        tileMapSettings.SpriteGroups[0].SpriteWidth = 120;
    //        tileMapSettings.SpriteGroups[0].StartPoint = new IntVector2(0, 0);
    //        tileMapSettings.SpriteGroups[0].NumberOfColumns = 10;
    //        tileMapSettings.SpriteGroups[0].NumberOfRows = 1;
    //        tileMapSettings.SpriteGroups[0].NumberOfSprites = 10;

    //        var tiledSource = new TileMapSpriteSource(_content.Load<Texture2D>("Characters/Zombie/Zombie"), tileMapSettings, _zombieScale);
    //        _animation_Idle_Right = new(tiledSource, 1, 100);
    //    }
    //    #endregion



    //    #region "--------------------------------- Methods ---------------------------------"
    //    #region "----------------------------- Public Methods ------------------------------"
    //    public override void Tick(double time)
    //    {
    //        if (_previousMovementStates != _zombieStates.PlayerMovementStates ||
    //            _currentAnimation is null)
    //        {
    //            _previousMovementStates = _zombieStates.PlayerMovementStates;
    //            InitNewAnimation(_zombieStates.PlayerMovementStates);
    //            return;
    //        }
    //        _currentAnimation?.Tick(time);
    //    }

    //    public override void GetDrawInfoSprite(ref DrawInfo2D drawInfo)
    //    {
    //        if (_currentAnimation is null)
    //            Tick(0);

    //        _currentAnimation.GetDrawInfoSprite(ref drawInfo);
    //    }
    //    #endregion

    //    #region "----------------------------- Private Methods -----------------------------"
    //    private void InitNewAnimation(PlayerMovementStates playerMovementStates)
    //    {
    //        switch (playerMovementStates)
    //        {
    //            case PlayerMovementStates.IdleRight:
    //                _animation_Idle_Right.Reset();
    //                _currentAnimation = _animation_Idle_Right;
    //                break;
    //            //case PlayerMovementStates.IdleLeft:
    //            //    _animation_Idle_Left.Reset();
    //            //    _currentAnimation = _animation_Idle_Left;
    //            //    break;

    //            //case PlayerMovementStates.WalkingRight:
    //            //    _animation_Walk_Right.Reset();
    //            //    _currentAnimation = _animation_Walk_Right;
    //            //    break;
    //            //case PlayerMovementStates.WalkingLeft:
    //            //    _animation_Walk_Left.Reset();
    //            //    _currentAnimation = _animation_Walk_Left;
    //            //    break;

    //            //case PlayerMovementStates.RunningRight:
    //            //    _animation_Run_Right.Reset();
    //            //    _currentAnimation = _animation_Run_Right;
    //            //    break;
    //            //case PlayerMovementStates.RunningLeft:
    //            //    _animation_Run_Left.Reset();
    //            //    _currentAnimation = _animation_Run_Left;
    //            //    break;
    //        }
    //    }
    //    #endregion

    //    #region "------------------------------ Event Handling -----------------------------"

    //    #endregion
    //    #endregion



    //    #region "--------------------------- Public Propterties ----------------------------"
    //    #region "------------------------------- Properties --------------------------------"

    //    #endregion

    //    #region "--------------------------------- Events ----------------------------------"

    //    #endregion
    //    #endregion
    //}
}