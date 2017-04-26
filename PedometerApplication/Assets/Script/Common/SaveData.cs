using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour {

	// セーブ関連クラス
	public static Save save;
	// 最大選択ペット数
	private static int maxSelectPetCount = 4;
	// 選択ペット数
	private static int selectPetCount = 0;
	// 選択ぺット名
	private static List<string> selectPets = new List<string>();
	// ぺット詳細説明
	private static List<string> petDescriptions = new List<string>();
	// 正面のスプライト
	private static List<string> mainImages = new List<string>();
	// 歩いている時のスプライト1
	private static List<string> walking1Images = new List<string>();
	// 歩いている時のスプライト2
	private static List<string> walking2Images = new List<string>();
	// 歩いている時のスプライト3
	private static List<string> walking3Images = new List<string>();
	// 歩いている時のスプライト4
	private static List<string> walking4Images = new List<string>();

	// 選択ペット数 getter
	public static int GetMaxSelectPetCount() {
		return maxSelectPetCount;
	}

	// 選択ペット数 getter
	public static int GetSelectPetCount() {
		return selectPetCount;
	}
	// 選択ペット数 setter
	public static void SetSelectPetCount(int setSelectPetCount) {
		selectPetCount = setSelectPetCount;
	}

	// 選択ペット名 getter
	public static List<string> GetSelectPets() {
		return selectPets;
	}
	// 選択ペット名 setter
	public static void SetSelectPets(List<string> setSelectPets) {
		selectPets = setSelectPets;
	}

	// ペット詳細説明 getter
	public static List<string> GetPetDescriptions() {
		return petDescriptions;
	}
	// ペット詳細説明 setter
	public static void SetPetDescriptions(List<string> setPetDescriptions) {
		petDescriptions = setPetDescriptions;
	}

	// 正面のスプライト getter
	public static List<string> GetMainImages() {
		return mainImages;
	}
	// 正面のスプライト setter
	public static void SetMainImages(List<string> setMainImages) {
		mainImages = setMainImages;
	}

	// 歩いている時のスプライト1 getter
	public static List<string> GetWalking1Images() {
		return walking1Images;
	}
	// 歩いている時のスプライト1 setter
	public static void SetWalking1Images(List<string> setWalking1Images) {
		walking1Images = setWalking1Images;
	}

	// 歩いている時のスプライト2 getter
	public static List<string> GetWalking2Images() {
		return walking2Images;
	}
	// 歩いている時のスプライト2 setter
	public static void SetWalking2Images(List<string> setWalking2Images) {
		walking2Images = setWalking2Images;
	}

	// 歩いている時のスプライト3 getter
	public static List<string> GetWalking3Images() {
		return walking3Images;
	}
	// 歩いている時のスプライト3 setter
	public static void SetWalking3Images(List<string> setWalking3Images) {
		walking3Images = setWalking3Images;
	}

	// 歩いている時のスプライト4 getter
	public static List<string> GetWalking4Images() {
		return walking4Images;
	}
	// 歩いている時のスプライト4 setter
	public static void SetWalking4Images(List<string> setWalking4Images) {
		walking4Images = setWalking4Images;
	}

	// 選択ペットの単純な追加処理
	public static void AddSelectPet(string newSelectPetName, string newPetDescription, string newMainImage,
		string newWalkingImage1, string newWalkingImage2, string newWalkingImage3, string newWalkingImage4) {
		selectPetCount = selectPetCount + 1;
		selectPets.Add(newSelectPetName);
		petDescriptions.Add(newPetDescription);
		mainImages.Add(newMainImage);
		walking1Images.Add(newWalkingImage1);
		walking2Images.Add(newWalkingImage2);
		walking3Images.Add(newWalkingImage3);
		walking4Images.Add(newWalkingImage4);
	}

	// Use this for initialization
	void Start () {
		// 初期設定
		save = GameObject.Find("Canvas").transform.GetComponent<Save> ();
		SetSelectPetCount (save.selectPets.Length);
		if (0 < GetSelectPetCount ()) {
			selectPets.AddRange (save.selectPets);
			petDescriptions.AddRange (save.petDescriptions);
			List<string> mainImagesTmp = new List<string> ();
			List<string> walking1ImagesTmp = new List<string> ();
			List<string> walking2ImagesTmp = new List<string> ();
			List<string> walking3ImagesTmp = new List<string> ();
			List<string> walking4ImagesTmp = new List<string> ();
			for (int i = 0; i < GetSelectPetCount (); i++) {
				for (int j = 0; j < save.petNames.Length; j++) {
					if (GetSelectPets () [i].Equals (save.petNames [j])) {
						mainImagesTmp.Add (save.mainImages [j]);
						walking1ImagesTmp.Add (save.walking1Images [j]);
						walking2ImagesTmp.Add (save.walking2Images [j]);
						walking3ImagesTmp.Add (save.walking3Images [j]);
						walking4ImagesTmp.Add (save.walking4Images [j]);
					}
				}
			}
			SetMainImages (mainImagesTmp);
			SetWalking1Images (walking1ImagesTmp);
			SetWalking2Images (walking2ImagesTmp);
			SetWalking3Images (walking3ImagesTmp);
			SetWalking4Images (walking4ImagesTmp);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
