using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {

	}
	//タイトル画面
	public void TitleStart() {
		Debug.Log("Button Push !!");
		SceneManager.LoadScene("MainView");
	}
	//メインメニュー画面
	public void MainMenuScene() {
		Debug.Log("メインメニューボタンが押下されました。");
		SceneManager.LoadScene("MainView");
	}
	//歩数計画面
	public void InformationScene() {
		Debug.Log("インフォメーションが押下されました。");
		SceneManager.LoadScene ("Information");
	}
	//ショップ画面
	public void ShopScene() {
		Debug.Log("ショップボタンが押下されました。");
		SceneManager.LoadScene ("ShopView");
	}
	//キャラクター詳細画面
	public void CharacterScene() {
		Debug.Log("キャラクター詳細ボタンが押下されました。");
		SceneManager.LoadScene ("CharacterDetailsView");
	}

	public void ShopWeponButton() {
		Debug.Log ("ショップの武器を表示");
		//GameObject.Find ("WeponShopWindow").GetComponent<Rigidbody> ().setActive = true;
	}
}
