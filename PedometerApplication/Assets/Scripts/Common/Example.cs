using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Example {
	
	public static int result = 0;
	public static int secondreslut = 0;
	public static int histresult = 0;
	public static String nowtime = "";
	public static String renow;


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
	//
	public static int GetReturnvalue() {
		int resval;
		resval = secondreslut;
		return resval;
	}
	//履歴取得
	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern int _ex_HistPedometer();
	#endif
	public static void ShowHistry() {
		#if UNITY_IOS && !UNITY_EDITOR
		histresult = _ex_HistPedometer();
		#endif
	}
	public static int ReturnHistValue() {
		int resval;
		resval = histresult;
		return resval;
	}
	//日付取得?
	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern String _ex_TodayStart();
	#endif
	public static void ToDayStart() {
		#if UNITY_IOS && !UNITY_EDITOR
		nowtime = _ex_TodayStart();
		#endif
	}

	public static String GetNowTime() {
		String retnow = nowtime;
		return retnow;
	}
}