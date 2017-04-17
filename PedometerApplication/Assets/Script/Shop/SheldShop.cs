using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheldShop : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		// 盾が選択されるまで、 Canvas を無効にしておく。
			gameObject.SetActive (false);
	}

	public void SelectWindowOpen() {
		gameObject.SetActive (true);
	}

	public void EtcWindowClose() {
		gameObject.SetActive (false);
	}
}
