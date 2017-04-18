using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetButton : MonoBehaviour {

	private GameObject petButton;
	private GameObject petPanel;
	private GameObject battleButton;

	// Use this for initialization
	void Start () {
		petButton = GameObject.Find ("PetButton");
		petPanel = GameObject.Find("PetPanel");
		battleButton = GameObject.Find ("BattleButton");
	}

	public void PetButtonTap () {
		// お知らせボタンを非表示
		petButton.SetActive(false);
		// 対戦ボタンを非表示
		battleButton.SetActive(false);
		// ゲット画面を表示
		petPanel.SetActive(true);
	}

	public void OkButtonTap () {
		// ゲット画面を非表示
		petPanel.SetActive(false);
		// 対戦ボタンを表示
		battleButton.SetActive(true);
	}
}
