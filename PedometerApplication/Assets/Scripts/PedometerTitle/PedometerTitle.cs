using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PedometerTitle : MonoBehaviour {

	public Canvas userInputCanvas;

	private CommonButtonScript commonButtonScript;
	private DataService ds;

	// Use this for initialization
	void Start () {
		ds = new DataService ("PedometerApplication.db");
		commonButtonScript = GameObject.Find("Canvas").transform.GetComponent<CommonButtonScript> ();
		ds.DelUserData();
		ds.DelSelectedPetData ();
	}

	// Update is called once per frame
	void Update () {

	}

	// ログイン処理
	public void StartTap () {
		// ユーザ登録がされていない場合、登録ダイアログを表示する
		if (SaveData.GetUserData() == null) {
			userInputCanvas.enabled = true;
		} else {
			SceneManager.LoadScene("MainView");
		}
	}

	// 完了ボタンタップ処理
	public void OkButtonTap () {
		string userName = GameObject.Find ("InputField").GetComponent<InputField> ().text;
		// ユーザ名を入力した時、メイン画面に遷移する
		if (userName != null && 0 < userName.Trim().Length) {
			ds.DelInsUserData (userName);
			SaveData.SetUserData(ds.GetUserData ());
			// TODO テスト用にポイント付与
			ds.UpdUserData (SaveData.GetUserData ().userid, SaveData.GetUserData().username,SaveData.GetUserData ().userlevel, 10000,
				SaveData.GetUserData ().todaywalkingcount, SaveData.GetUserData ().totalwalkingcount);
			SaveData.SetUserData (ds.GetUserData ());
			ds.UpdMyPetDataByPetId (1);
			SaveData.SetMyPetDataList (ds.GetAllMyPetData ());
			List<int> petIdList = new List<int> ();
			petIdList.Add (1);
			ds.DelInsSelectedPetData (petIdList);
			SaveData.SetSelPetJoinAllPetDataList (ds.GetSelPetJoinAllPetData ());
			SceneManager.LoadScene("MainView");
		}
	}
}
