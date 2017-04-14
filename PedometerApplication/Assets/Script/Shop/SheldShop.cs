using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheldShop : MonoBehaviour {

	// エディタのインスペクタで、この変数にヒエラルキーにある Canvas を割り当ててください。
	public Canvas SheldShopWindow = null;

	// Use this for initialization
	void Start () {
		// 盾が選択されるまで、 Canvas を無効にしておく。
		if (SheldShopWindow != null)
		{
			SheldShopWindow.enabled = false;
		}
	}

	public void SelectWindowOpen() {
		SheldShopWindow.enabled = true;
	}

	public void EtcWindowClose() {
		SheldShopWindow.enabled = false;
	}
}
