using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponShop : MonoBehaviour {

	void Start () {
	}

	public void SelectWindowOpen() {
		gameObject.SetActive (true);
	}

	public void EtcWindowClose() {
		gameObject.SetActive (false);
	}
}
