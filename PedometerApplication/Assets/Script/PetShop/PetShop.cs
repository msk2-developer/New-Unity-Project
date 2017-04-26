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
		pointCount.GetComponent<Text>().text = SaveData.save.pointCount.ToString();
		foreach (Transform child in GameObject.Find("WeaponShop").transform){
			for (int i = 0; i < SaveData.save.petCount; i++) {
				if (child.FindChild ("PetName").GetComponent<Text> ().text.Equals (SaveData.save.petNames[i])) {
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
			SaveData.save.AddPointCountData (pointCountText.text);
			SaveData.AddSelectPet (petButton.FindChild ("PetName").GetComponent<Text> ().text,
				"色々なペットの説明",
				petButton.FindChild ("PetImage").GetComponent<Image> ().sprite.name,
				"en_115", "en_116", "en_117", "en_118");
			SaveData.save.AddPetData (petButton.FindChild ("PetName").GetComponent<Text> ().text,
				"色々なペットの説明",
				petButton.FindChild ("PetImage").GetComponent<Image> ().sprite.name,
				"en_115", "en_116", "en_117", "en_118");
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
