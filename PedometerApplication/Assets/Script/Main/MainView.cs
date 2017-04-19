using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainView : MonoBehaviour {

//	private GameObject petButton;
	public GameObject petPanel;
	public GameObject battlePanel;

	// Use this for initialization
	void Start () {
		// ボタン等の設定

//		petButton = GameObject.Find("PetButton");
		petPanel = GameObject.Find("PetPanel");
		battlePanel = GameObject.Find("BattlePanel");
	}
	
	// Update is called once per frame
	void Update () {
		// ボタン表示、非表示
//		petButton.SetActive (true);
	}
}
