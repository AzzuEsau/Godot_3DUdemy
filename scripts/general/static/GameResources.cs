using Godot;
using System;

public static class GameResources {
	#region Variables
		#region Physiscs
			public static float Gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
		#endregion

		#region Groups
			public static string GroupPlayer = "Player";
		#endregion

		// [Export] private int vairbaleInEditor;
		#region Inputs
			public static string InputFront = "front";
			public static string InputBack = "back";
			public static string InputLeft = "left";
			public static string InputRight = "right";
			public static string InputRun = "run";
		#endregion

		#region Animations
			public static string AnimationPlayerIdle = "idle";
			public static string AnimationPlayerWalk = "walk";
			public static string AnimationPlayerRun = "run";
			public static string AnimationPlayerRoll = "roll";
			public static string AnimationPlayerHurt = "hurt";
			public static string AnimationPlayerDead = "dead";
			public static string AnimationPlayerAttack1 = "attack_1";
			public static string AnimationPlayerAttack2 = "attack_2";
			public static string AnimationPlayerAttack3 = "attack_3";
		#endregion

		#region Player
			public static float PlayerSpeed = 250F;
			public static float PlayerRunnigMultiplier = 1.75F;
		#endregion
	#endregion
}
