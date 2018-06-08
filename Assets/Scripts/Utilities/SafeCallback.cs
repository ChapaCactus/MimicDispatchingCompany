using System;

using UnityEngine.Assertions;

namespace CCG
{
	public static class SafeCallback
	{
		public static void SafeCall(this Action action)
		{
			if (action == null) return;

			action();
		}

		public static void SafeCall<T>(this Action<T> action, T arg)
		{
			if (action == null) return;

			action(arg);
		}

		public static void SafeCall<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2)
		{
			if (action == null) return;

			action(arg1, arg2);
		}
	}
}