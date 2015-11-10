using System;

namespace Level
{
	public class Helpers
	{
		public static bool IsStrictEqual(int value, params int[] against)
		{
			for (int i = 0; i < against.Length; i++) 
			{
				if (value != against[i])
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsBetween(int value, int min, int max)
		{
			if (min <= value && value <= max) 
			{
				return true;
			}
			return false;
		}
		
		public static bool NotEqualStrict(int value, params int[] against)
		{
			for (int i = 0; i < against.Length; i++) 
			{
				if (value == against[i])
				{
					return false;
				}
			}
			return true;
		}
		
		public static bool IsLooselyEqual(int value, params int[] against)
		{
			for (int i = 0; i < against.Length; i++) 
			{
				if (value == against[i])
				{
					return true;
				}
			}
			return false;
		}
	}
}

