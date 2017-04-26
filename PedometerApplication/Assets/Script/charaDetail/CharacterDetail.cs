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

	// 画像
	private Sprite[] petSprites;
	// 遷移用のボタンクラス
	private CommonButtonScript commonButtonScript;

	// Use this for initialization
	void Start () {
		// 画像読み込み
		petSprites = Resources.LoadAll<Sprite> ("Image/ActRPGsprites/en");
		// 登録用に遷移ボタンクラス取得
		commonButtonScript = GameObject.Find("MenuBox").transform.GetComponent<CommonButtonScript> ();
		// 入替画面オブジェクト取得
		petListPanel = GameObject.Find ("PetListPanel");

		// メイン画面ペット表示、入替画面の選択ペット表示
		for (int i = 0; i < SaveData.GetMaxSelectPetCount(); i++) {
			GameObject pet = GameObject.Find ("Pet" + i);
			GameObject petListPet = GameObject.Find ("SelectPetPanel").transform.FindChild ("PetButton" + i).gameObject;
			if (i < SaveData.GetSelectPetCount()) {
				Sprite mainImageSprite = System.Array.Find<Sprite> (petSprites, (sprite) => sprite.name.Equals (SaveData.GetMainImages() [i]));
				pet.GetComponent<Image> ().sprite = mainImageSprite;
				petListPet.transform.FindChild("Image").GetComponent<Image> ().sprite = mainImageSprite;
			} else {
				pet.SetActive (false);
			}
		}

		// 入替画面全ペット表示
		Transform petColPanelClone = petColPanel;
		for (int i = 0; i < SaveData.save.petNames.Length; i++) {
			if (i == 0 || i % 4 == 0) {
				// ぺット作成
				petColPanelClone = Instantiate (petColPanel, GameObject.Find ("Content").transform);
				// Object名設定
				petColPanelClone.name = "PetColPanel" + (i / 4);
			}
			Sprite mainImageSprite = System.Array.Find<Sprite> (petSprites, (sprite) => sprite.name.Equals (SaveData.save.mainImages [i]));
			petColPanelClone.FindChild ("PetButton" + (i % 4)).FindChild ("Image").GetComponent<Image> ().sprite = mainImageSprite;
		}
		petListPanel.SetActive (false);
	}

	// メイン画面のぺットタップ処理
	public void PetTap (Button button) {
		// ペット名、説明を切り替える
		string mainImageName = button.GetComponent<Image> ().sprite.name;
		for(int i = 0; i < SaveData.GetSelectPetCount(); i++){
			if (mainImageName.Equals (SaveData.GetMainImages() [i])) {
				GameObject.Find ("PetName").GetComponent<Text> ().text = SaveData.GetSelectPets()[i];
				GameObject.Find ("Description").GetComponent<Text> ().text = SaveData.GetPetDescriptions() [i];
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
			if (i < SaveData.GetSelectPetCount()) {
				Sprite mainImageSprite =
					System.Array.Find<Sprite> (petSprites, (sprite) => sprite.name.Equals (SaveData.GetMainImages() [i]));
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
		int childCount = 0;
		List<string> selectPetsTmp = new List<string>();
		List<string> petDescriptionsTmp = new List<string>();
		List<string> mainImagesTmp = new List<string>();
		List<string> walking1ImagesTmp = new List<string>();
		List<string> walking2ImagesTmp = new List<string>();
		List<string> walking3ImagesTmp = new List<string>();
		List<string> walking4ImagesTmp = new List<string>();
		foreach (Transform child in GameObject.Find("SelectPetPanel").transform) {
			if (child.FindChild ("Image").GetComponent<Image> ().sprite != null) {
				// メイン画像セット
				mainImagesTmp.Add (child.FindChild ("Image").GetComponent<Image> ().sprite.name);
				// 全メイン画像と突合し、その他情報もセットする
				for (int i = 0; i < SaveData.save.mainImages.Length; i++) {
					if (mainImagesTmp [childCount].Equals (SaveData.save.mainImages [i])) {
						selectPetsTmp.Add (SaveData.save.petNames [i]);
						petDescriptionsTmp.Add (SaveData.save.petDescriptions [i]);
						walking1ImagesTmp.Add (SaveData.save.walking1Images [i]);
						walking2ImagesTmp.Add (SaveData.save.walking2Images [i]);
						walking3ImagesTmp.Add (SaveData.save.walking3Images [i]);
						walking4ImagesTmp.Add (SaveData.save.walking4Images [i]);
					}
				}
			}
			childCount++;
		}
		SaveData.SetSelectPetCount (selectPetsTmp.Count);
		SaveData.SetSelectPets (selectPetsTmp);
		SaveData.SetPetDescriptions (petDescriptionsTmp);
		SaveData.SetMainImages (mainImagesTmp);
		SaveData.SetWalking1Images (walking1ImagesTmp);
		SaveData.SetWalking2Images (walking2ImagesTmp);
		SaveData.SetWalking3Images (walking3ImagesTmp);
		SaveData.SetWalking4Images (walking4ImagesTmp);
		SaveData.save.ChangeSelectPetsData (SaveData.GetSelectPets().ToArray());
		commonButtonScript.CharacterScene ();
	}
}
