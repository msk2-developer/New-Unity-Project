using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {

	public GameObject petButton;
	public GameObject battlePanel;
	public GameObject battleButton;
	public Text battleButtonText;
	public float battleEndTime;

	// Use this for initialization
	void Start () {
		petButton = GameObject.Find("PetButton");
		battlePanel = GameObject.Find("BattlePanel");
		battleButton = GameObject.Find("BattleButton");
		battlePanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (battleButtonText.text == "対戦中") {
			battleEndTime += Time.deltaTime;
		}
		if(battleEndTime > 5.0f && battleButtonText.text == "対戦中"){
			battleButtonText.text = "対戦済";
			battleEndTime = 0;
		}
	}

	// 対戦ボタンタップ処理
	public void BattleButtonTap () {
		if (battleButtonText.text == "対戦") {
			// お知らせボタンを非表示
			petButton.SetActive (false);
			// 対戦ボタンを非表示
			battleButton.SetActive (false);
			// 対戦確認画面を表示
			battlePanel.SetActive (true);
		} else if (battleButtonText.text == "対戦中") {
			Debug.Log ("対戦中");
		} else {
			Debug.Log ("対戦完了");
			battleButtonText.text = "対戦";
		}
	}

	// 対人戦ボタンタップ処理
	public void NpcBattleButtonTap () {
		// TODO 対人戦実装
		battleButtonText.text = "対戦中";
		// 対戦確認画面を非表示
		battlePanel.SetActive (false);
		// お知らせボタンを表示
		petButton.SetActive(true);
		// 対戦ボタンを表示
		battleButton.SetActive (true);
	}

	// CPU戦ボタンタップ処理
	public void CpuBattleButtonTap () {
		// TODO CPU戦実装
		// 対戦確認画面を非表示
		battlePanel.SetActive (false);
		// お知らせボタンを表示
		petButton.SetActive(true);
		// 対戦ボタンを表示
		battleButton.SetActive (true);

		Debug.Log ("CPU戦");
	}

	// 戻るボタンタップ処理
	public void CancelButtonTap () {
		// 対戦確認画面を非表示
		battlePanel.SetActive (false);
		// お知らせボタンを表示
		petButton.SetActive(true);
		// 対戦ボタンを表示
		battleButton.SetActive (true);

		Debug.Log ("戻る");
	}

}
