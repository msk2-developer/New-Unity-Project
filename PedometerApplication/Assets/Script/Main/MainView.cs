using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour {

	/* ペットボタン関連 */
	public GameObject petButton;
	public GameObject petPanel;
	public Transform pet1Animation;
	public GameObject pet1AnimationClone;

	/* 対戦ボタン関連 */
	public GameObject battlePanel;
	public GameObject battleButton;
	public Text battleButtonText;
	public float battleEndTime;

	/* キャラの動き関連 */
	public GameObject charaWalk1;
	public GameObject charaWalk2;
	public GameObject charaWalk3;
	public GameObject charaWalk4;

	public GameObject pet1Walk1;
	public GameObject pet1Walk2;
	public GameObject pet1Walk3;
	public GameObject pet1Walk4;

	// Use this for initialization
	void Start () {
		// ペットボタン制御
		petButton = GameObject.Find ("PetButton");
		petPanel = GameObject.Find("PetPanel");
		battleButton = GameObject.Find ("BattleButton");
		petPanel.SetActive (false);

		// 対戦ボタン制御
		petButton = GameObject.Find("PetButton");
		battlePanel = GameObject.Find("BattlePanel");
		battleButton = GameObject.Find("BattleButton");
		battlePanel.SetActive (false);

		// キャラの動き制御
		// 主要キャラの動き
		charaWalk1 = GameObject.Find("CharaWalk1");
		charaWalk2 = GameObject.Find("CharaWalk2");
		charaWalk3 = GameObject.Find("CharaWalk3");
		charaWalk4 = GameObject.Find("CharaWalk4");
		charaWalk1.SetActive (false);
		charaWalk2.SetActive (false);
		charaWalk3.SetActive (false);
		charaWalk4.SetActive (true);
		// ペット1の設定
		// TODO ペットがいる場合
//		pet1Walk1 = GameObject.Find("Pet1Walk1");
//		pet1Walk2 = GameObject.Find("Pet1Walk2");
//		pet1Walk3 = GameObject.Find("Pet1Walk3");
//		pet1Walk4 = GameObject.Find("Pet1Walk4");
//		pet1Walk1.SetActive (false);
//		pet1Walk2.SetActive (false);
//		pet1Walk3.SetActive (false);
//		pet1Walk4.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		// 対戦ボタン設定
		this.ChangeBattleButtonText();

		// キャラの動き設定
		// 背景の動き
		this.BackGroundAnimation();
		// 主要キャラの動き
		this.CharacterAnimation (charaWalk1, charaWalk2, charaWalk3, charaWalk4);
		// ペット1の動き
		if (pet1AnimationClone != null && pet1AnimationClone.activeSelf) {
			this.CharacterAnimation (pet1Walk1, pet1Walk2, pet1Walk3, pet1Walk4);
		}
	}

	// ペットボタンタップ処理
	public void PetButtonTap () {
		// お知らせボタンを非表示
		petButton.SetActive(false);
		// 対戦ボタンを非表示
		battleButton.SetActive(false);
		// ゲット画面を表示
		petPanel.SetActive(true);
	}

	// OKボタンタップ処理
	public void OkButtonTap () {
		// ゲット画面を非表示
		petPanel.SetActive(false);
		// 対戦ボタンを表示
		battleButton.SetActive(true);
		Instantiate (pet1Animation);
		pet1AnimationClone = GameObject.Find ("Pet1Animation(Clone)");
		Canvas canvas = GameObject.FindObjectOfType<Canvas> ();
		pet1AnimationClone.transform.SetParent (canvas.transform, false);
		pet1Walk1 = GameObject.Find("Pet1Walk1");
		pet1Walk2 = GameObject.Find("Pet1Walk2");
		pet1Walk3 = GameObject.Find("Pet1Walk3");
		pet1Walk4 = GameObject.Find("Pet1Walk4");
		pet1Walk1.SetActive (false);
		pet1Walk2.SetActive (false);
		pet1Walk3.SetActive (false);
		pet1Walk4.SetActive (true);
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

	// 対戦ボタンテキスト差し替え処理
	void ChangeBattleButtonText () {
		if (battleButtonText.text == "対戦中") {
			battleEndTime += Time.deltaTime;
		}
		if(battleEndTime > 5.0f && battleButtonText.text == "対戦中"){
			battleButtonText.text = "対戦済";
			battleEndTime = 0;
		}
	}

	// 背景の動き
	void BackGroundAnimation () {
		transform.Translate (0.05f, 0, 0);
		if (transform.position.x > 22f ) {
			transform.position = new Vector3 (0, 2.2f, -13f);
		}
	}

	// キャラ/ペットの動き
	void CharacterAnimation (GameObject walk1, GameObject walk2, GameObject walk3, GameObject walk4) {
		// 動きの設定
		if (Time.frameCount % 15 == 0) {
			if (walk1.activeSelf) {
				walk1.SetActive (false);
				walk2.SetActive (true);
				walk3.SetActive (false);
				walk4.SetActive (false);
			} else if (walk2.activeSelf) {
				walk1.SetActive (false);
				walk2.SetActive (false);
				walk3.SetActive (true);
				walk4.SetActive (false);
			} else if (walk3.activeSelf) {
				walk1.SetActive (false);
				walk2.SetActive (false);
				walk3.SetActive (false);
				walk4.SetActive (true);
			}else{
				walk1.SetActive (true);
				walk2.SetActive (false);
				walk3.SetActive (false);
				walk4.SetActive (false);
			}
		}
	}
}
