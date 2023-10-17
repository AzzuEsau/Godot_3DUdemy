using Godot;
using System;
using System.Collections.Generic;

public abstract partial class State : Node {
	#region Variables
		// [Export] private int vairbaleInEditor;
	#endregion

	#region Signals
		[Signal] public delegate void TransitionEventHandler(State state, string stateName);
	#endregion
	
    #region My Methods
    	public abstract void Enter();
		public abstract void Exit();
    	public abstract void Update(double delta);
    	public abstract void PhysicsUpdate(double delta);
	#endregion

	#region Events
	#endregion
}