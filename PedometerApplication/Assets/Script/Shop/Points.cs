using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {

	public Text textPoint;
	int points = 2000;
	// Use this for initialization
	void Start () {
		//初期表示処理
		textPoint.text = this.points.ToString();		
	}

	// Update is called once per frame
	void Update () {
		textPoint.text = this.points.ToString();
	}

	public void ResultPoint(int buypoint) {

		if (this.points <= 0) {
			Debug.Log ("購入できませんでした。");
		} else {
			this.points -= buypoint;
			BuyReslut ();
		}
	}

	public void BuyReslut() {

		if (this.points <= 0) {
			Debug.Log ("購入できませんでした。");
		} else {
			Debug.Log ("アイテムを購入しました。");
			textPoint.text = this.points.ToString();
		}


	}
}
