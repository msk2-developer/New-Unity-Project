using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBuy : MonoBehaviour {

	// エディタのインスペクタで、この変数にヒエラルキーにある Canvas を割り当ててください。
	public Canvas dialogCanvas = null;

	// Use this for initialization
	void Start() {
		// ダイアログを表示するときまで、 Canvas を無効にしておく。
		if (dialogCanvas != null)
		{
			dialogCanvas.enabled = false;
		}
	}

	// クリックされた
	public void OnMouseUpAsButton()
	{
		confirmAllHoshiDelete();
	}

	// ダイアログを表示
	public void confirmAllHoshiDelete()
	{
		// Canvas を有効にする
		if (dialogCanvas != null)
		{
			dialogCanvas.enabled = true;
		}
	}

	// Yes ボタンと関連づけたイベントハンドラ関数
	public void onButtonYes()
	{
		// Canvas を無効にする。(ダイアログを閉じる)
		dialogCanvas.enabled = false;

		// アイテムの削除処理(省略)
	}

	// No ボタンと関連づけたイベントハンドラ関数
	public void onButtonNo()
	{
		// Canvas を無効にする。(ダイアログを閉じる)
		dialogCanvas.enabled = false;
	}

}
