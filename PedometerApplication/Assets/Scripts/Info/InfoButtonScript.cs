using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	//インフォメーション画面のユーザー情報を押された時
	public void UserInfo() {
		Debug.Log ("ユーザー情報が押下されました。");
	}

	//歩数計に使うツールを押下された時
	public void PedometerToolPush() {
		Debug.Log ("歩数計に使うツールが押下されました。");
	}

	//SNSの共有機能が押下された時
	public void SnsLink() {
		Debug.Log ("SNSに共有が押下されました。");
	}

	//称号が押下された時
	public void GetMedalList() {
		Debug.Log ("称号が押下されました。");
	}

	//ペットコレクションが押下された時
	public void PetCollection() {
		Debug.Log ("ペットコレクションが押下されました。");
	}

	//課金ブースト
	public void BillingBoost() {
		Debug.Log ("課金ブーストが押下されました。");
	}

	//武器/盾コレクション
	public void WeponsCollection() {
		Debug.Log ("装備コレクションが押下されました。");
	}

}
