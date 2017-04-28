using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDetail : MonoBehaviour {

	// 入替画面
	private GameObject petListPanel;
	// 入替画面の全ペット側の列
	public Transform petColPanel;
	// メイン画面のペット
	public Button petButton;

	// 遷移用のボタンクラス
	private CommonButtonScript commonButtonScript;

	// Use this for initialization
	void Start () {
		// 登録用に遷移ボタンクラス取得
		commonButtonScript = GameObject.Find("MenuBox").transform.GetComponent<CommonButtonScript> ();
		// 入替画面オブジェクト取得
		petListPanel = GameObject.Find ("PetListPanel");

		// メイン画面ペット表示、入替画面の選択ペット表示
		for (int i = 0; i < SaveData.GetMaxSelectPetCount(); i++) {
			GameObject pet = GameObject.Find ("Pet" + i);
			GameObject petListPet = GameObject.Find ("SelectPetPanel").transform.FindChild ("PetButton" + i).gameObject;
			if (i < SaveData.GetSelPetJoinAllPetDataList().Count) {
				// 画像読み込み
				Sprite mainImageSprite = Resources.Load<Sprite> ("Image/ActRPGsprites/" + SaveData.GetSelPetJoinAllPetDataList()[i].petmainimage);
//				Sprite mainImageSprite = System.Array.Find<Sprite> (petSprites, (sprite) => sprite.name.Equals (SaveData.GetSelPetJoinAllPetDataList()[i].petmainimage));
				pet.GetComponent<Image> ().sprite = mainImageSprite;
				petListPet.transform.FindChild("Image").GetComponent<Image> ().sprite = mainImageSprite;
			} else {
				pet.SetActive (false);
			}
		}

		// 入替画面全ペット表示
		Transform petColPanelClone = petColPanel;
		int count = 0;
		foreach (PetData c in SaveData.GetMyPetDataList()) {
			Debug.Log (c.ToString ());
			if (count == 0 || count % 4 == 0) {
				// ぺット作成
				petColPanelClone = Instantiate (petColPanel, GameObject.Find ("Content").transform);
				// Object名設定
				petColPanelClone.name = "PetColPanel" + (count / 4);
			}
			Sprite mainImageSprite = Resources.Load<Sprite> ("Image/ActRPGsprites/" + c.petmainimage);
//			Sprite mainImageSprite = System.Array.Find<Sprite> (petSprites, (sprite) => sprite.name.Equals (c.petmainimage));
			petColPanelClone.FindChild ("PetButton" + (count % 4)).FindChild ("Image").GetComponent<Image> ().sprite = mainImageSprite;
			count++;
		}
		petListPanel.SetActive (false);
	}

	// メイン画面のぺットタップ処理
	public void PetTap (Button button) {
		// ペット名、説明を切り替える
		string mainImageName = button.GetComponent<Image> ().sprite.name;
		foreach(SelPetJoinAllPetData c in SaveData.GetSelPetJoinAllPetDataList()){
			if (mainImageName.Equals (c.petmainimage)) {
				GameObject.Find ("PetName").GetComponent<Text> ().text = c.petname;
				GameObject.Find ("Description").GetComponent<Text> ().text = c.petdescription;
			}
		}
	}

	// メイン画面の入替ボタンタップ処理
	public void PetListButtonTap () {
		// 入替画面を表示する
		petListPanel.SetActive (true);
	}

	// 入替画面の選択側ペットタップ処理
	public void SelectPetPanelPetButtonTap (Button button) {
		// 入れ替えるペットを選択する (選択中のペットは半透明)
		if (button.transform.FindChild("Image").GetComponent<Image> ().sprite != null) {
			if (petButton == null) {
				petButton = button;
				petButton.transform.FindChild ("Image").GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 0.5f);
			} else if (!petButton.name.Equals (button.name)) {
				petButton.transform.FindChild ("Image").GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
				petButton = button;
				petButton.transform.FindChild ("Image").GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 0.5f);
			} else {
				petButton.transform.FindChild ("Image").GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
				petButton = null;
			}
		}
	}

	// 入替画面の戻るボタンタップ処理
	public void BackButtonTap () {
		// 入替画面の情報を初期状態に戻して、メイン画面に戻る
		for (int i = 0; i < SaveData.GetMaxSelectPetCount(); i++) {
			// 入れ替えたペットを戻す
			GameObject petListPet = GameObject.Find ("SelectPetPanel").transform.FindChild ("PetButton" + i).gameObject;
			if (i < SaveData.GetSelPetJoinAllPetDataList().Count) {
				Sprite mainImageSprite = Resources.Load<Sprite> ("Image/ActRPGsprites/" + SaveData.GetSelPetJoinAllPetDataList() [i].petmainimage);
//				Sprite mainImageSprite =
//					System.Array.Find<Sprite> (petSprites, (sprite) => sprite.name.Equals (SaveData.GetSelPetJoinAllPetDataList() [i].petmainimage));
				petListPet.transform.FindChild ("Image").GetComponent<Image> ().sprite = mainImageSprite;
			} else {
				petListPet.transform.FindChild ("Image").GetComponent<Image> ().sprite = null;
			}
		}
		if (petButton != null) {
			// 選択中状態を解除する
			petButton.transform.FindChild ("Image").GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
			petButton = null;
		}
		// 入替画面を閉じる
		petListPanel.SetActive (false);
	}

	// 入替画面の決定ボタンタップ処理
	public void DecideButtonTap () {
		// 選択したペットを登録し、メイン画面を再表示する
		List<int> petIdList = new List<int>();
		foreach (Transform child in GameObject.Find("SelectPetPanel").transform) {
			if (child.FindChild ("Image").GetComponent<Image> ().sprite != null) {
				// メイン画像セット
				string petMainImage = child.FindChild ("Image").GetComponent<Image> ().sprite.name;
				petMainImage = petMainImage.Remove(petMainImage.IndexOf('_'));
				// その他情報もセットする
				foreach (PetData c in SaveData.GetMyPetDataList()) {
					if (petMainImage.Equals (c.petmainimage)) {
						petIdList.Add (c.petid);
					}
				}
			}
		}
		var ds = new DataService ("PedometerApplication.db");
		ds.DelInsSelectedPetData (petIdList);
		SaveData.SetSelPetJoinAllPetDataList (ds.GetSelPetJoinAllPetData ());
		commonButtonScript.CharacterScene ();
	}
}
