using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedometerTitle : MonoBehaviour {

	public Canvas userInputCanvas;

	private Save save;
	private CommonButtonScript commonButtonScript;

	// Use this for initialization
	void Start () {
		save = GameObject.Find("Canvas").transform.GetComponent<Save> ();
		commonButtonScript = GameObject.Find("Canvas").transform.GetComponent<CommonButtonScript> ();
		save.DeleteData ();
	}

	// Update is called once per frame
	void Update () {

	}

	// ログイン処理
	public void StartTap () {
		// ユーザ登録がされていない場合、登録ダイアログを表示する
		if (save.userName == null || save.userName.Trim().Length <= 0) {
			userInputCanvas.enabled = true;
		} else {
			commonButtonScript.MainMenuScene ();
		}
	}

	// 完了ボタンタップ処理
	public void OkButtonTap () {
		string userName = GameObject.Find ("InputField").GetComponent<InputField> ().text;
		// ユーザ名を入力した時、メイン画面に遷移する
		if (userName != null && 0 < userName.Trim().Length) {
			save.AddUserData (userName);
			save.AdduserLevelData ("1");
			save.AddPointCountData ("10000");
			save.AddPetData("スライム", "ただのスライム", "en_15", "en_14", "en_15", "en_16", "en_17");
			commonButtonScript.MainMenuScene ();
			SaveData.AddSelectPet("スライム", "ただのスライム", "en_15", "en_14", "en_15", "en_16", "en_17");
			commonButtonScript.MainMenuScene ();
		}
	}
}
