using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainView : MonoBehaviour {

//	private GameObject petButton;
	private GameObject petPanel;
	private GameObject battlePanel;

	// Use this for initialization
	void Start () {
		// ボタン等の設定

//		petButton = GameObject.Find("PetButton");
		petPanel = GameObject.Find("PetPanel");

		petPanel.SetActive (false);
		battlePanel = GameObject.Find("BattlePanel");
		battlePanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		// ボタン表示、非表示
//		petButton.SetActive (true);
	}
}
