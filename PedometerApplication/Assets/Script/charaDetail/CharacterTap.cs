using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTap : MonoBehaviour {

	private GameObject changeButton;
	private GameObject status2LabelObj;
	private GameObject status2Obj;
	public Text characterNameText;
	public Text status1Label;
	public Text status1Text;
	public Text status2Text;
	public Text descriptionText;

	// Use this for initialization
	void Start () {
		changeButton = GameObject.Find ("ChangeButton");
		status2LabelObj = GameObject.Find ("Status2Label");
		status2Obj = GameObject.Find ("Status2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// キャラクタータップ
	public void WeaponMyselfTap () {
		// キャラ名を表示
		characterNameText.text = "桃太郎";
		// 変更ボタンを非表示
		changeButton.SetActive(false);
		// ステータス1をHP表示
		status1Label.text = "HP";
		status1Text.text = "100";
		// ステータス2を非表示
		status2LabelObj.SetActive(false);
		status2Obj.SetActive(false);
		// 詳細を表示
		descriptionText.text = "主人公";
	}

	// 右手装備タップ
	public void WeaponRightTap () {
		// 右手装備名を表示
		characterNameText.text = "斧";
		// 変更ボタンを表示
		changeButton.SetActive(true);
		// ステータス1を攻撃力表示
		status1Label.text = "攻撃力";
		status1Text.text = "5";
		// ステータス2を防御力表示
		status2LabelObj.SetActive(true);
		status2Obj.SetActive(true);
		status2Text.text = "2";
		// 詳細を表示
		descriptionText.text = "ただの斧";
	}

	// 左手装備タップ
	public void WeaponLeftTap () {
		// 右手装備名を表示
		characterNameText.text = "ナイフ";
		// 変更ボタンを表示
		changeButton.SetActive(true);
		// ステータス1を攻撃力表示
		status1Label.text = "攻撃力";
		status1Text.text = "3";
		// ステータス2を防御力表示
		status2LabelObj.SetActive(true);
		status2Obj.SetActive(true);
		status2Text.text = "0";
		// 詳細を表示
		descriptionText.text = "ただのナイフ";
	}
}
