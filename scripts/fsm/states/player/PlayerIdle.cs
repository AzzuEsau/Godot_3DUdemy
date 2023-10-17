using Godot;
using System;
using System.Collections.Generic;

[Tool]
public partial class PlayerIdle : State {
    #region Variables
		[Export] private Player player;
		[Export] private AnimationPlayer animationPlayer;
    #endregion

    #region Signals
    // [Signal] public delegate void ExampleSignalEventHandler();
    #endregion

    #region Godot Validations
		public override string[] _GetConfigurationWarnings() {
			List<string> warnings = new List<string> {
                Helperuitilies.ValidateCheckNullValue(nameof(player), player),
                Helperuitilies.ValidateCheckNullValue(nameof(animationPlayer), animationPlayer)
            };

			return Helperuitilies.ClearNullValues(warnings);
		}
    #endregion

    #region State Methods
    	public override void Enter() {
			
		}

		public override void Exit() {
			
		}
		
		public override void Update(double delta) {
			AnimatePlayer();
		}

		public override void PhysicsUpdate(double delta) {
			MovePlayer(delta);
		}

    #endregion

    #region My Methods
		private void AnimatePlayer() {
			animationPlayer.Play(GameResources.AnimationPlayerIdle);
		}

		private void MovePlayer(double delta) {
			player.Velocity = Vector3.Zero;
			player.ApplyGravity(delta);
			player.MoveAndSlide();
		}
    #endregion

    #region Events
    #endregion
}
