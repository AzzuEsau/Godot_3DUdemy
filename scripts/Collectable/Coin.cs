using Godot;
using System;
using System.Collections.Generic;

[Tool]
public partial class Coin : Node3D {
	#region Variables
		[Export] private Node3D visualCoin;
		[Export] private Area3D area;
		[Export] private GpuParticles3D vfxParticle;
		[Export] private AnimationPlayer animationPlayer;

		private float rotateSpeed = 1F;
    #endregion

    #region Signals
    // [Signal] public delegate void ExampleSignalEventHandler();
    #endregion

    #region Godot Methdos
    public override string[] _GetConfigurationWarnings() {
        List<string> warnings = new List<string>{
			Helperuitilies.ValidateCheckNullValue(nameof(visualCoin), visualCoin),
			Helperuitilies.ValidateCheckNullValue(nameof(area), area),
			Helperuitilies.ValidateCheckNullValue(nameof(vfxParticle), vfxParticle),
			Helperuitilies.ValidateCheckNullValue(nameof(animationPlayer), animationPlayer),
		};

		return Helperuitilies.ClearNullValues(warnings);
    }

    public override void _Ready() {
			if(Engine.IsEditorHint()) return;

			area.BodyEntered += Area_BodyEntered;
		}

		public override void _Process(double delta) {
			if(Engine.IsEditorHint()) return;

			visualCoin.RotateY(rotateSpeed * (float)delta);

			if(visualCoin.Visible == false && vfxParticle.Emitting == false)
				QueueFree();
		}
	#endregion

	#region My Methods
	#endregion

	#region Events
		private void Area_BodyEntered(Node3D node) {
			if(node.IsInGroup(GameResources.GroupPlayer) && node is Player) {
				animationPlayer.Play("collected");
				area.QueueFree();
				// vfxParticle.Emitting = true;
				// QueueFree();
				((Player)node).AddCoin(1);
			}
		}
	#endregion
}
