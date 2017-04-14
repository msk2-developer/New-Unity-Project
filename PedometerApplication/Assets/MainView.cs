using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainView : MonoBehaviour {

	GameObject petButton;


	// Use this for initialization
	void Start () {
		// ボタン等の設定
		petButton = GameObject.Find("PetButton");
//		petButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		// ボタン表示、非表示
//		petButton.SetActive (true);
	}
}
