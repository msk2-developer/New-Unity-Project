using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetShop : MonoBehaviour {

	private GameObject pointCount;
	public Canvas buyCanvas;
	public Canvas alertCanvas;
	private Text petPointCountText;
	private Transform petButton;

	// Use this for initialization
	void Start () {
		pointCount = GameObject.Find ("PointCount");

		// データ設定
		pointCount.GetComponent<Text>().text = SaveData.GetUserData().point.ToString();
		foreach (Transform child in GameObject.Find("WeaponShop").transform){
			foreach (PetData petData in SaveData.GetMyPetDataList()) {
				if (child.FindChild ("PetName").GetComponent<Text> ().text.Equals (petData.petname)) {
					child.FindChild ("CostValue").GetComponent<Text> ().text = "購入済";
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	// ぺット商品タップ処理
	public void BoughtPetButtonTap (Transform button) {
		petButton = button;
		// 金額取得
		petPointCountText = button.FindChild("CostValue").gameObject.GetComponent<Text> ();

		// 購入済の場合、何もしない
		if (petPointCountText.text.Equals ("購入済")) {
			return;
		}

		// 所持ポイント
		Text pointCountText = pointCount.GetComponent<Text> ();
		int pointCountInt = int.Parse (pointCountText.text);
		// ぺット金額
		int petPointCountInt = int.Parse(petPointCountText.text);

		// 計算
		pointCountInt -= petPointCountInt;
		if (pointCountInt < 0) {
			// 購入不可ダイアログ表示
			alertCanvas.enabled = true;
		} else {
			// 購入確認ダイアログ表示
			buyCanvas.enabled = true;
		}
	}

	// Yes ボタンと関連づけたイベントハンドラ関数
	public void YesButtonTap(){
		// 所持ポイント
		Text pointCountText = pointCount.GetComponent<Text> ();
		int pointCountInt = int.Parse (pointCountText.text);
		// ぺット金額
		int petPointCountInt = int.Parse(petPointCountText.text);

		// 計算
		pointCountInt -= petPointCountInt;
		if (pointCountInt < 0) {
			Debug.Log ("ポイントが足りません");
		} else {
			pointCountText.text = pointCountInt.ToString ();
			petPointCountText.text = "購入済";
			var ds = new DataService ("PedometerApplication.db");
			ds.UpdUserData (SaveData.GetUserData ().userid, SaveData.GetUserData().username,SaveData.GetUserData ().userlevel, pointCountInt,
				SaveData.GetUserData ().todaywalkingcount, SaveData.GetUserData ().totalwalkingcount);
			SaveData.SetUserData (ds.GetUserData ());
			ds.UpdMyPetDataByPetId (int.Parse(petButton.FindChild ("PetId").GetComponent<Text> ().text));
			SaveData.SetMyPetDataList (ds.GetAllMyPetData ());
			if (SaveData.GetSelPetJoinAllPetDataList ().Count < 4) {
				// 選択ペット登録
				List<int> petIdList = new List<int> ();
				foreach (SelPetJoinAllPetData c in SaveData.GetSelPetJoinAllPetDataList()) {
					petIdList.Add (c.petid);
				}
				petIdList.Add (int.Parse(petButton.FindChild ("PetId").GetComponent<Text> ().text));
				ds.DelInsSelectedPetData (petIdList);
				SaveData.SetSelPetJoinAllPetDataList (ds.GetSelPetJoinAllPetData());
			}
		}
		// Canvas を無効にする。(ダイアログを閉じる)
		buyCanvas.enabled = false;
	}

	// No ボタンと関連づけたイベントハンドラ関数
	public void NoButtonTap(Canvas canvas){
		// Canvas を無効にする。(ダイアログを閉じる)
		canvas.enabled = false;
	}
}
