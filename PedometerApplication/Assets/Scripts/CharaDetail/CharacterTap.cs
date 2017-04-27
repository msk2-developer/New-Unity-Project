using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTap : MonoBehaviour {
	
	// 詳細画面クラス
	private CharacterDetail characterDetail;

	// Use this for initialization
	void Start () {
		// 詳細画面クラス取得
		characterDetail = GameObject.FindObjectOfType<Canvas> ().transform.GetComponent<CharacterDetail> ();
	}

	// 入替画面の全件側のペットタップ処理
	public void PetColPanelPetButtonTap (Button button) {
		// 入れ替えるペットが選択されている時、選択ペットを入れ替える
		if (characterDetail.petButton != null &&
		    button.transform.FindChild ("Image").GetComponent<Image> ().sprite != null) {
			foreach (Transform child in GameObject.Find("SelectPetPanel").transform) {
				if (child.FindChild ("Image").GetComponent<Image> ().sprite != null &&
				    child.FindChild ("Image").GetComponent<Image> ().sprite.name.Equals (
					    button.transform.FindChild ("Image").GetComponent<Image> ().sprite.name)) {
					child.FindChild ("Image").GetComponent<Image> ().sprite =
						characterDetail.petButton.transform.FindChild ("Image").GetComponent<Image> ().sprite;
				}
			}
			characterDetail.petButton.transform.FindChild ("Image").GetComponent<Image> ().sprite =
			button.transform.FindChild ("Image").GetComponent<Image> ().sprite;
		}
	}
}
