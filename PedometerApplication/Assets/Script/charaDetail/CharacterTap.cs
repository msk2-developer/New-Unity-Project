using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTap : MonoBehaviour {

	private CharacterDetail characterDetail;

	// Use this for initialization
	void Start () {
		characterDetail = GameObject.FindObjectOfType<Canvas> ().transform.GetComponent<CharacterDetail> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// 入替画面の一覧側ペットボタンタップ処理
	public void PetColPanelPetButtonTap (Button button) {
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
