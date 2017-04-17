using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetButton : MonoBehaviour {

	private GameObject petButton;

	public void PetButtonTap () {
		// お知らせボタンを消す
		petButton = GameObject.Find ("PetButton");
		petButton.SetActive(false);
		// ゲット画面を開く

	}
}
