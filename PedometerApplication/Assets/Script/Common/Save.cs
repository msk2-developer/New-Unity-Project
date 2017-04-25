using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save : MonoBehaviour {

	// ユーザ名
	public string userName;
	// ユーザレベル
	public int userLevel;
	// 所持ポイント
	public int pointCount;
	// 今日の歩数
	public int todayWalkingCount;
	// 総歩数
	public int totalWalkingCount;
	// 取得ぺット数
	public int petCount;
	// Main画面表示ぺット (とりあえずぺット名を入れる)
	public string[] selectPets;
	// ぺット名
	public string[] petNames;
	// ぺットタイプ (飛行など)
	public string[] petTypes;
	// ぺット詳細説明
	public string[] petDescriptions;
	// 正面のスプライト
	public string[] mainImages;
	// 歩いている時のスプライト1
	public string[] walking1Images;
	// 歩いている時のスプライト2
	public string[] walking2Images;
	// 歩いている時のスプライト3
	public string[] walking3Images;
	// 歩いている時のスプライト4
	public string[] walking4Images;

	// Use this for initialization
	void Start () {
		this.LoadData ();
	}

	// データのロード
	string LoadData(){
		if (PlayerPrefs.HasKey ("PlayerData")) {
			string data = PlayerPrefs.GetString ("PlayerData");
			JsonUtility.FromJsonOverwrite (data, this);
			return this.GetJsonData ();
		} else {
			return "";
		}
	}

	// ユーザ情報追加
	public void AddUserData(string newUserName){
		// ユーザ登録
		this.userName = newUserName;
		PlayerPrefs.SetString("PlayerData", this.GetJsonData());
	}

	// レベル情報追加
	public void AdduserLevelData(string userLevel){
		// レベル登録
		this.userLevel = int.Parse(userLevel);
		PlayerPrefs.SetString("PlayerData", this.GetJsonData());
	}

	// ポイント情報追加
	public void AddPointCountData(string pointCount){
		// ポイント登録
		this.pointCount = int.Parse(pointCount);
		PlayerPrefs.SetString("PlayerData", this.GetJsonData());
	}

	// 歩数情報追加
	public void AddWalkingData(string newWalkingCountStr){
		int newWalkingCountInt = int.Parse (newWalkingCountStr);
		// 歩数登録
		this.todayWalkingCount = newWalkingCountInt;
		this.totalWalkingCount += newWalkingCountInt;
		PlayerPrefs.SetString("PlayerData", this.GetJsonData());
	}

	// ぺット情報追加
	public void AddPetData(string newPetName, string newPetDescription, string newMainImage,
		string newWalkingImage1, string newWalkingImage2, string newWalkingImage3, string newWalkingImage4){
		this.petNames = setArray (this.petNames, newPetName);
		this.petDescriptions = setArray (this.petDescriptions, newPetDescription);
		this.mainImages = setArray (this.mainImages, newMainImage);
		this.walking1Images = setArray (this.walking1Images, newWalkingImage1);
		this.walking2Images = setArray (this.walking2Images, newWalkingImage2);
		this.walking3Images = setArray (this.walking3Images, newWalkingImage3);
		this.walking4Images = setArray (this.walking4Images, newWalkingImage4);
		this.petCount += 1;
		if (this.selectPets.Length < 4) {
			this.selectPets = setArray (this.selectPets, newPetName);
		}
		PlayerPrefs.SetString("PlayerData", this.GetJsonData());
	}

	//　データの削除
	public void DeleteData() {
		PlayerPrefs.DeleteAll();
	}

	//　データの登録
	public void SaveData() {
		PlayerPrefs.Save();
	}

	// JSONデータ取得
	string GetJsonData() {
		return JsonUtility.ToJson(this);
	}

	// 配列に要素を追加する
	string[] setArray(string[] realArray, string newStr){
		string[] resultArray;
		if (realArray != null && 0 < realArray.Length) {
			resultArray = new string[realArray.Length + 1];
			for (int i = 0; i < realArray.Length; i++) {
				resultArray [i] = realArray [i];
			}
			resultArray [resultArray.Length - 1] = newStr;
		} else {
			resultArray = new string[1]{newStr};
		}

		return resultArray;
	}
}
