using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{

	public Text textPoint;
	int points;
	int todayPoint;
	public Text walkCount;
	// Use this for initialization
	void Start ()
	{
		Example.ShowHistry ();
		todayPoint = Example.Returnvalue ();
		Example.Call_workadd();
		Debug.Log (todayPoint);
		walkCount.text = todayPoint.ToString();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Example.Pedovalue ();
		points = Example.GetReturnvalue();
		//Debug.Log ("現在のポイントとか¥n"+points);
		textPoint.text = points.ToString();
	}

	public void hist() {
		Example.ShowHistry ();
		todayPoint = Example.Returnvalue ();
		Debug.Log (todayPoint);
	}

}
