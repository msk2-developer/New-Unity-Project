using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour {

	/* ペットボタン関連 */
	public GameObject petButton;
	public GameObject petPanel;
	public Transform pet1Animation;
	public Transform pet1AnimationClone;

	/* 対戦ボタン関連 */
	// TODO 対応予定
//	public GameObject battlePanel;
//	public GameObject battleButton;
//	public Text battleButtonText;
//	public float battleEndTime;

	/* キャラの動き関連 */
	public Transform mainCamera;

//	public GameObject charaWalk1;
//	public GameObject charaWalk2;
//	public GameObject charaWalk3;
//	public GameObject charaWalk4;

	public GameObject pet1Walk1;
	public GameObject pet1Walk2;
	public GameObject pet1Walk3;
	public GameObject pet1Walk4;

	private Save save;
	private Sprite[] petSprites;
	private Canvas canvas;

	// Use this for initialization
	void Start () {

		save = GameObject.FindObjectOfType<Canvas> ().transform.GetComponent<Save> ();
		petSprites = Resources.LoadAll<Sprite> ("Image/ActRPGsprites/en");
		canvas = GameObject.FindObjectOfType<Canvas> ();

		// ペットボタン制御
		petButton = GameObject.Find ("PetButton");
		petPanel = GameObject.Find("PetPanel");
		petPanel.SetActive (false);

		// 対戦ボタン制御
		// TODO 対応予定
//		petButton = GameObject.Find("PetButton");
//		battlePanel = GameObject.Find("BattlePanel");
//		battleButton = GameObject.Find("BattleButton");
//		battlePanel.SetActive (false);

		// キャラの動き制御
		// 主要キャラの動き
//		charaWalk1 = GameObject.Find("CharaWalk1");
//		charaWalk2 = GameObject.Find("CharaWalk2");
//		charaWalk3 = GameObject.Find("CharaWalk3");
//		charaWalk4 = GameObject.Find("CharaWalk4");
//		charaWalk1.SetActive (false);
//		charaWalk2.SetActive (false);
//		charaWalk3.SetActive (false);
//		charaWalk4.SetActive (true);
		// ペット1の設定
		for(int i = 0; i < save.petCount;i++){
			// ぺット表示
			Vector3 position;
			if (i == 0) {
				position = new Vector3 (195.0f, 73.0f);
			} else if (i == 1) {
				position = new Vector3 (140.0f, 85.0f);
			} else if (i == 2) {
				position = new Vector3 (85.0f, 73.0f);
			} else {
				position = new Vector3 (30.0f, 85.0f);
			}
			Debug.Log (save.walking1Images [i]+save.walking2Images [i]+save.walking3Images [i]+save.walking4Images [i]);
			this.DrawPet("petAnimation" + i, position, save.walking1Images[i],
				save.walking2Images[i], save.walking3Images[i], save.walking4Images[i]);
//			pet1AnimationClone = Instantiate (pet1Animation);
//			pet1AnimationClone.name = "test1";
//			Canvas canvas = GameObject.FindObjectOfType<Canvas> ();
//			pet1AnimationClone.SetParent (canvas.transform, false);
//			pet1AnimationClone.SetSiblingIndex(1);
//			pet1Walk1 = GameObject.Find("Pet1Walk1");
//			pet1Walk2 = GameObject.Find("Pet1Walk2");
//			pet1Walk3 = GameObject.Find("Pet1Walk3");
//			pet1Walk4 = GameObject.Find("Pet1Walk4");
//			pet1Walk1.SetActive (false);
//			pet1Walk2.SetActive (false);
//			pet1Walk3.SetActive (false);
//			pet1Walk4.SetActive (true);
//			Sprite walkingSprite = System.Array.Find<Sprite>( petSprites, (sprite) => sprite.name.Equals(save.walking1Images[i]));
//			pet1Walk1.GetComponent<Image>().sprite = walkingSprite;
//			walkingSprite = System.Array.Find<Sprite>( petSprites, (sprite) => sprite.name.Equals(save.walking2Images[i]));
//			pet1Walk2.GetComponent<Image>().sprite = walkingSprite;
//			walkingSprite = System.Array.Find<Sprite>( petSprites, (sprite) => sprite.name.Equals(save.walking3Images[i]));
//			pet1Walk3.GetComponent<Image>().sprite = walkingSprite;
//			walkingSprite = System.Array.Find<Sprite>( petSprites, (sprite) => sprite.name.Equals(save.walking4Images[i]));
//			pet1Walk4.GetComponent<Image>().sprite = walkingSprite;
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
	}
	
	// Update is called once per frame
	void Update () {
		// 対戦ボタン設定
		// TODO 対応予定
//		this.ChangeBattleButtonText();

		// キャラの動き設定
		// 背景の動き
		this.BackGroundAnimation();
		// 主要キャラの動き
//		this.CharacterAnimation (charaWalk1, charaWalk2, charaWalk3, charaWalk4);
		// ペットの動き
		for (int i = 0; i < 4; i++) {
			if (GameObject.Find ("petAnimation" + i) != null && GameObject.Find ("petAnimation" + i).activeSelf) {
				Transform petAnimationTransform = GameObject.Find ("petAnimation" + i).transform;
				this.CharacterAnimation (petAnimationTransform.FindChild ("Pet1Walk1").gameObject,
					petAnimationTransform.FindChild ("Pet1Walk2").gameObject,
					petAnimationTransform.FindChild ("Pet1Walk3").gameObject,
					petAnimationTransform.FindChild ("Pet1Walk4").gameObject);
			} else {
				break;
			}
		}
	}

	// ペットボタンタップ処理
	public void PetButtonTap () {
		// お知らせボタンを非表示
		petButton.SetActive(false);
		// 対戦ボタンを非表示
		// TODO 対応予定
//		battleButton.SetActive(false);
		// ゲット画面を表示
		petPanel.SetActive(true);
	}

	// OKボタンタップ処理
	public void OkButtonTap () {
		// ゲット画面を非表示
		petPanel.SetActive(false);
		// 対戦ボタンを表示
		// TODO 対応予定
//		battleButton.SetActive(true);
		// ぺット表示
		string gameObjectName = null;
		Vector3 position = new Vector3();
		if (GameObject.Find ("petAnimation0") == null) {
			gameObjectName = "petAnimation0";
			position.Set (195.0f, 73.0f, 0.0f);
		} else if (GameObject.Find ("petAnimation1") == null) {
			gameObjectName = "petAnimation1";
			position.Set (140.0f, 85.0f, 0.0f);
		} else if (GameObject.Find ("petAnimation2") == null) {
			gameObjectName = "petAnimation2";
			position.Set (85.0f, 73.0f, 0.0f);
		} else if (GameObject.Find ("petAnimation3") == null) {
			gameObjectName = "petAnimation3";
			position.Set (30.0f, 85.0f, 0.0f);
		}
		if (gameObjectName != null) {
			this.DrawPet (gameObjectName, position, "en_115",
				"en_116", "en_117", "en_118");
			// セーブ
			save.AddPetData ("ドクロ", "en_106", pet1Walk1.GetComponent<Image> ().sprite.name, 
				pet1Walk2.GetComponent<Image> ().sprite.name, pet1Walk3.GetComponent<Image> ().sprite.name, 
				"en_118");
		}
	}

	// 画面へのぺット描画処理
	void DrawPet(string gameObjectName, Vector3 position, string walkingImage1, string walkingImage2, string walkingImage3, string walkingImage4){
		pet1AnimationClone = Instantiate (pet1Animation, position, Quaternion.identity, canvas.transform);
		pet1AnimationClone.name = gameObjectName;
		pet1AnimationClone.SetSiblingIndex(1);
		pet1Walk1 = pet1AnimationClone.FindChild("Pet1Walk1").gameObject;
		pet1Walk2 = pet1AnimationClone.FindChild("Pet1Walk2").gameObject;
		pet1Walk3 = pet1AnimationClone.FindChild("Pet1Walk3").gameObject;
		pet1Walk4 = pet1AnimationClone.FindChild("Pet1Walk4").gameObject;
		pet1Walk1.SetActive (false);
		pet1Walk2.SetActive (false);
		pet1Walk3.SetActive (false);
		pet1Walk4.SetActive (true);
		Sprite walkingSprite = System.Array.Find<Sprite>( petSprites, (sprite) => sprite.name.Equals(walkingImage1));
		pet1Walk1.GetComponent<Image>().sprite = walkingSprite;
		walkingSprite = System.Array.Find<Sprite>( petSprites, (sprite) => sprite.name.Equals(walkingImage2));
		pet1Walk2.GetComponent<Image>().sprite = walkingSprite;
		walkingSprite = System.Array.Find<Sprite>( petSprites, (sprite) => sprite.name.Equals(walkingImage3));
		pet1Walk3.GetComponent<Image>().sprite = walkingSprite;
		walkingSprite = System.Array.Find<Sprite>( petSprites, (sprite) => sprite.name.Equals(walkingImage4));
		pet1Walk4.GetComponent<Image>().sprite = walkingSprite;
		Debug.Log (pet1Walk4.GetComponent<Image> ().sprite);
	}

	// 対戦ボタンタップ処理
	// TODO 対応予定
//	public void BattleButtonTap () {
//		if (battleButtonText.text == "対戦") {
//			// お知らせボタンを非表示
//			petButton.SetActive (false);
//			// 対戦ボタンを非表示
//			battleButton.SetActive (false);
//			// 対戦確認画面を表示
//			battlePanel.SetActive (true);
//		} else if (battleButtonText.text == "対戦中") {
//			Debug.Log ("対戦中");
//		} else {
//			Debug.Log ("対戦完了");
//			battleButtonText.text = "対戦";
//		}
//	}
//
//	// 対人戦ボタンタップ処理
//	public void NpcBattleButtonTap () {
//		// TODO 対人戦実装
//		battleButtonText.text = "対戦中";
//		// 対戦確認画面を非表示
//		battlePanel.SetActive (false);
//		// お知らせボタンを表示
//		petButton.SetActive(true);
//		// 対戦ボタンを表示
//		battleButton.SetActive (true);
//	}
//
//	// CPU戦ボタンタップ処理
//	public void CpuBattleButtonTap () {
//		// TODO CPU戦実装
//		// 対戦確認画面を非表示
//		battlePanel.SetActive (false);
//		// お知らせボタンを表示
//		petButton.SetActive(true);
//		// 対戦ボタンを表示
//		battleButton.SetActive (true);
//
//		Debug.Log ("CPU戦");
//	}
//
//	// 戻るボタンタップ処理
//	public void CancelButtonTap () {
//		// 対戦確認画面を非表示
//		battlePanel.SetActive (false);
//		// お知らせボタンを表示
//		petButton.SetActive(true);
//		// 対戦ボタンを表示
//		battleButton.SetActive (true);
//
//		Debug.Log ("戻る");
//	}
//
//	// 対戦ボタンテキスト差し替え処理
//	void ChangeBattleButtonText () {
//		if (battleButtonText.text == "対戦中") {
//			battleEndTime += Time.deltaTime;
//		}
//		if(battleEndTime > 5.0f && battleButtonText.text == "対戦中"){
//			battleButtonText.text = "対戦済";
//			battleEndTime = 0;
//		}
//	}

	// 背景の動き
	void BackGroundAnimation () {
		mainCamera.Translate (0.05f, 0, 0);
		if (mainCamera.position.x > 22f ) {
			mainCamera.position = new Vector3 (0, 2.2f, -13f);
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
