using Godot;
using System;
using System.Collections.Generic;

[Tool]
public partial class Enemy : CharacterBody3D {
	#region Variables
		// [Export] private int vairbaleInEditor;
		#region FSM
			private FiniteStateMachine finiteStateMachine;
   		#endregion
    #endregion

    #region Signals
    // [Signal] public delegate void ExampleSignalEventHandler();
    #endregion

    #region Godot Methdos
		#region Validations
		public override string[] _GetConfigurationWarnings() {
			List<string> warnings = new List<string> {
				Helperuitilies.ValidateCheckNullValue(nameof(finiteStateMachine), finiteStateMachine),
			};

			return Helperuitilies.ClearNullValues(warnings);
		}
		#endregion

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
