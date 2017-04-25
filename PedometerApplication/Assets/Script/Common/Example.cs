using System.Runtime.InteropServices;

public class Example {
	
	public static int result = 0;
	public static int secondreslut = 0;
	//歩数カウント
	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern int _ex_addpedo();
	#endif
	public static void Call_workadd() {
		#if UNITY_IOS && !UNITY_EDITOR
		result = _ex_addpedo();
		#endif
	}
	public static int Returnvalue() {
		int resval;
		resval = result;
		return resval;
	}
	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern int _ex_returnval();
	#endif
	public static void Pedovalue() {
		#if UNITY_IOS && !UNITY_EDITOR
		secondreslut = _ex_returnval();
		#endif
	}
	public static int SecondReturnvalue() {
		int resval;
		resval = secondreslut;
		return resval;
	}
}