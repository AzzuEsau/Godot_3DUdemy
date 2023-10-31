using Godot;
using System;

public partial class EnemyMovement : Node {
	#region Variables
		[Export] private NavigationAgent3D navigationAgent3D;
		[Export] private CharacterBody3D player;
	#endregion

	#region Signals
		// [Signal] public delegate void ExampleSignalEventHandler();
	#endregion

	#region Godot Methdos
		public override void _Ready() {
			
		}

		public override void _Process(double delta) {

		}
	#endregion

	#region My Methods
	#endregion

	#region Events
	#endregion
}
