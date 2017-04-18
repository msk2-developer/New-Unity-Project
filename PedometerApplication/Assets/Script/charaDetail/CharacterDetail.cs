using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDetail : MonoBehaviour {

	private GameObject changeButton;
	private GameObject status2LabelObj;
	private GameObject status2Obj;
	public Text characterNameText;
	public Text status1Label;
	public Text status1Text;
	public Text descriptionText;

	// Use this for initialization
	void Start () {

		changeButton = GameObject.Find ("ChangeButton");
		status2LabelObj = GameObject.Find ("Status2Label");
		status2Obj = GameObject.Find ("Status2");

		// TODO 初回起動はキャラ名選択状態の設定にする

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
	
	// Update is called once per frame
	void Update () {
	}
}
