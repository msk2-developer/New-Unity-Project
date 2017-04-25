using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{

	public Text textPoint;
	int points;
	// Use this for initialization
	void Start ()
	{
//		textPoint.text = this.points.ToString();
		Example.Call_workadd();
		points = Example.Returnvalue ();
		Debug.Log ("ポイントは"+points+"です");
	}
	
	// Update is called once per frame
	void Update ()
	{
		Example.Pedovalue ();
		points = Example.SecondReturnvalue();
		Debug.Log ("現在のポイントとか¥n"+points);
		textPoint.text = this.points.ToString();
	}


}
