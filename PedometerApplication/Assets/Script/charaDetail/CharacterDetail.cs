using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDetail : MonoBehaviour {

	private GameObject changeButton;
	private GameObject hitPoint;
	private GameObject attack;
	private GameObject guard;

	// Use this for initialization
	void Start () {
		// 変更ボタンを消す
		changeButton = GameObject.Find ("ChangeButton");
		changeButton.SetActive(false);
		// TODO キャラが選択されている場合、攻撃力/防御力を消す (HPを表示)
		attack = GameObject.Find ("Attack");
		attack.SetActive(false);
		guard = GameObject.Find ("Guard");
		guard.SetActive(false);
		// TODO 装備/ペットが選択されている場合、HPを消す (攻撃力/防御力を表示)
	}
	
	// Update is called once per frame
	void Update () {
		// TODO 装備が選択されている時、変更ボタンを表示する
	}
}
