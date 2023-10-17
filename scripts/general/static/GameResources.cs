using Godot;
using System;

public static class GameResources {
	#region Variables
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
			// public static string AnimationPlayerWalk = "walk";
		#endregion

		#region Player
			public static float PlayerSpeed = 4F;
			public static float PlayerRunnigMultiplier = 1.75F;
		#endregion
	#endregion
}
