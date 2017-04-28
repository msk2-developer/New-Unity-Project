using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{

	public Text textPoint;
	int walkpoints;
	int todayPoint;
	//int gamePoints;
	string nowtime;
	public Text walkCount;
	// Use this for initialization
	void Start ()
	{
		Example.ToDayStart ();
		Example.Call_workadd();
		Example.ReturnHistValue();
		//日付取得
		Debug.Log (todayPoint);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Example.Pedovalue ();
		walkpoints = Example.GetReturnvalue();
		//Debug.Log ("現在のポイントとか¥n"+points);
		//walkCount.text = walkpoints.ToString();
	}
	//今日の歩数を取得する
	public void hist() {
		Example.ShowHistry ();
		todayPoint = Example.Returnvalue ();
		Debug.Log (todayPoint);
		nowtime = Example.GetNowTime();
		Debug.Log (nowtime);

	}
	//ポイントに変更
	void ChangePoints() {
		
		//gamePoints = (walkpoints / 3);
		//textPoint.text = gamePoints.ToString();
	}
}
