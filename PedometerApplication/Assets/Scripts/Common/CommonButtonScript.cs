using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class CommonButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
		SceneManager.LoadScene ("PetShop");
	}
	//キャラクター詳細画面
	public void CharacterScene() {
		Debug.Log("キャラクター詳細ボタンが押下されました。");
		SceneManager.LoadScene ("CharacterDetailsView");
	}
}
