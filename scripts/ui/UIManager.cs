using Godot;
using System;
using System.Collections.Generic;

[Tool]
public partial class UIManager : Control {
	#region Variables
		[Export] private Label coinsLabel;
		[Export] private Player player;
	#endregion

	#region Signals
		// [Signal] public delegate void ExampleSignalEventHandler();
	#endregion

	#region Godot Methdos
		public override string[] _GetConfigurationWarnings() {
			List<string> warnings = new List<string> {
				Helperuitilies.ValidateCheckNullValue(nameof(coinsLabel), coinsLabel),
				Helperuitilies.ValidateCheckNullValue(nameof(player), player),
			};

			return Helperuitilies.ClearNullValues(warnings);
		}

		public override void _Ready() {
			player.CoinCollected += Player_CoinCollected;
		}
	#endregion

	#region My Methods
		public void UpdateCoinLabel(int newValue) => coinsLabel.Text = newValue.ToString();
	#endregion

	#region Events
		private void Player_CoinCollected(int coins) => UpdateCoinLabel(coins);
	#endregion
}
