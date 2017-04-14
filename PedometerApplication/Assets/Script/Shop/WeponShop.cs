using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponShop : MonoBehaviour {

	// エディタのインスペクタで、この変数にヒエラルキーにある Canvas を割り当ててください。
	public Canvas WeponShopWindow = null;


	// Use this for initialization
	void Start () {
		
	}
	
	public void SelectWindowOpen() {
		WeponShopWindow.enabled = true;
	}

	public void EtcWindowClose() {
		WeponShopWindow.enabled = false;
	}
}
