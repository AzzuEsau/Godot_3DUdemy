using Godot;
using System;
using System.Collections.Generic;

public static class Helperuitilies{
    #region Validations
        public static string ValidateCheckNullValue(string fieldName, Node objectToCheck) {
            string warning = null;
            if(objectToCheck == null) warning = fieldName + " is null and must contain value in object";
            return warning;
        }



        public static string[] ClearNullValues(List<string> strings) {
            while(strings.Contains(null))
				strings.Remove(null);
			
			return strings.ToArray();
        }

        public static float GetShortestAngleDistance(float fromAngle, float toAngle) {
            float angleDifference = toAngle - fromAngle;
            if (angleDifference > 180.0) angleDifference -= 360.0F;
            else if (angleDifference < -180.0) angleDifference += 360.0F;

            return Math.Abs(angleDifference);
        }
    #endregion
}