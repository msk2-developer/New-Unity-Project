using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetButton : MonoBehaviour {

	private GameObject petButton;
	private GameObject petPanel;

	// Use this for initialization
	void Start () {
		petButton = GameObject.Find ("PetButton");
		petPanel = GameObject.Find("PetPanel");
	}

	public void PetButtonTap () {
		// お知らせボタンを消す
		petButton.SetActive(false);
		// ゲット画面を開く
		petPanel.SetActive(true);
	}

	public void OkButtonTap () {
		// ゲット画面を消す
		petPanel.SetActive(false);
	}
}
