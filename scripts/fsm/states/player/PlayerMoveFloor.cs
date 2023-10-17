using Godot;
using System;
using System.Collections.Generic;

[Tool]
public partial class PlayerMoveFloor : State {
	#region Variables
		[Export] private Player player;
		[Export] private AnimationPlayer animationPlayer;
		[Export] private Node3D visualNode;

		[Export] private GpuParticles3D foostepVFX;
	#endregion

	#region Signals
		// [Signal] public delegate void ExampleSignalEventHandler();
	#endregion

	#region Godot Validations
		public override string[] _GetConfigurationWarnings() {
			List<string> warnings = new List<string> {
                Helperuitilies.ValidateCheckNullValue(nameof(player), player),
                Helperuitilies.ValidateCheckNullValue(nameof(animationPlayer), animationPlayer),
                Helperuitilies.ValidateCheckNullValue(nameof(visualNode), visualNode),
                Helperuitilies.ValidateCheckNullValue(nameof(foostepVFX), foostepVFX)
            };

			return Helperuitilies.ClearNullValues(warnings);
		}
    #endregion

	#region States Methdos
		public override void Enter() {

		}

		public override void Exit() {
			foostepVFX.Emitting = false;
		}

		public override void Update(double delta) {
			AnimatePlayer();
		}

		public override void PhysicsUpdate(double delta) {
			MovePlayer(delta);
			RotatePlayer(delta);
			PlayParticles();
    	}
    #endregion

    #region My Methods
		private void MovePlayer(double delta) {
			float speedMultiplier = 1F;
			if(player.inputRunning) speedMultiplier = GameResources.PlayerRunnigMultiplier;

			player.ApplyGravity(delta);
			player.ApplyHorizontalVelocity(player.inputDirectionLerp, delta, speedMultiplier);
			player.MoveAndSlide();
		}

		private void RotatePlayer(double delta) {
			if(player.inputDirection != Vector2.Zero) {
				Vector2 updated = new Vector2(-player.inputDirection.X, player.inputDirection.Y);
				float angle = updated.Angle() + Mathf.DegToRad(90);
				float targetAngle = Mathf.LerpAngle(visualNode.Rotation.Y, angle, (float)delta * 5F);

				visualNode.Rotation = new Vector3(0, targetAngle, 0);
			}

		}

		private void PlayParticles() {
			foostepVFX.Emitting = true;
		}


		private void AnimatePlayer() {
			if(player.inputRunning) animationPlayer.Play(GameResources.AnimationPlayerRun);
			else animationPlayer.Play(GameResources.AnimationPlayerWalk);
		}
    #endregion

    #region Events
    #endregion
}
