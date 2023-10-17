using Godot;
using System;
using System.Collections.Generic;

[Tool]
public partial class Player : CharacterBody3D {
	#region Variables
		#region Direction Effects
			public Vector2 inputDirection {get; private set;}
			public bool inputRunning {get; private set;}
			public Vector2 inputDirectionLerp = Vector2.Zero;
			public float lerpSpeed {get; protected set;} = 2.5F;
		#endregion

		#region FSM
			private FiniteStateMachine finiteStateMachine;

			private PlayerIdle idleState;
			private PlayerMoveFloor moveOnFloorState;
		#endregion

		#region Game Manager
			private int coinsCollected = 0;
		#endregion
	#endregion

	#region Signals
		[Signal] public delegate void CoinCollectedEventHandler(int coins);
	#endregion

	#region Godot Methods
		#region Godot Validations
			public override string[] _GetConfigurationWarnings() {
				FindStateMachine();


				List<string> warnings = new List<string> {
					Helperuitilies.ValidateCheckNullValue(nameof(finiteStateMachine), finiteStateMachine),
					Helperuitilies.ValidateCheckNullValue(nameof(idleState), idleState),
					Helperuitilies.ValidateCheckNullValue(nameof(moveOnFloorState), moveOnFloorState)
				};

				return Helperuitilies.ClearNullValues(warnings);
			}

			private void FindStateMachine() {
				foreach(Node node in GetChildren())
					if(node is FiniteStateMachine) finiteStateMachine = (FiniteStateMachine)node;
				
				if(finiteStateMachine != null)
					foreach(Node node in finiteStateMachine.GetChildren()) {
						if(node is PlayerIdle) idleState = (PlayerIdle)node;
						if(node is PlayerMoveFloor) moveOnFloorState = (PlayerMoveFloor)node;
					}
			}
    #endregion


    public override void _Ready() {
        FindStateMachine(); 
    }

    public override void _PhysicsProcess(double delta) {
			if(Engine.IsEditorHint()) return;

			ReadInputs();
			ApplyLerpInput(delta);
			ChangeState();
		}
	#endregion

	#region My Methods
		#region Phyisics
			public void ApplyGravity(double delta) => Velocity = new Vector3(Velocity.X, Velocity.Y - GameResources.Gravity * (float)delta, Velocity.Z);
			private void ApplyLerpInput(double delta) =>  inputDirectionLerp = inputDirectionLerp.MoveToward(inputDirection, (float)delta * lerpSpeed);
			public void ApplyHorizontalVelocity(Vector2 direction, double delta, float multiplier = 1F) {
				direction = direction * GameResources.PlayerSpeed * multiplier * (float)delta;
				Velocity = new Vector3(direction.X, Velocity.Y, direction.Y);
			}
		#endregion

		#region Inputs
			private void ReadInputs() {
				// inputDirection = Input.GetVector(GameResources.InputLeft, GameResources.InputRight, GameResources.InputFront, GameResources.InputBack).Normalized();
				inputDirection = Input.GetVector(GameResources.InputFront, GameResources.InputBack, GameResources.InputRight, GameResources.InputLeft).Normalized();
				inputRunning = Input.IsActionPressed(GameResources.InputRun);
			}

			private bool isDirectionActive() => inputDirection != Vector2.Zero || inputDirectionLerp != Vector2.Zero;
		#endregion

		#region Finite State Machine
			private void ChangeState() {
				
				if(CanMoveOnFloor()) moveOnFloorState.EmitSignal(State.SignalName.Transition, moveOnFloorState, moveOnFloorState.Name);
				else if(CanIdle()) idleState.EmitSignal(State.SignalName.Transition, idleState, idleState.Name);
			}

			private bool CanMoveOnFloor() => isDirectionActive() && IsOnFloor();
			private bool CanIdle() => inputDirectionLerp == Vector2.Zero && IsOnFloor();
		#endregion

		#region Game Manager
			public void AddCoin(int value) {
				coinsCollected += value;
				EmitSignal(SignalName.CoinCollected, coinsCollected);
			}
		#endregion
	#endregion

	#region Events
	#endregion
}
