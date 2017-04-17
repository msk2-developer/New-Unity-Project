using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour {

	public Transform help;
	GameObject helpClone;

	public void HelpButtonTap () {
		if (helpClone == null) {
			Instantiate (help);
			helpClone = GameObject.Find ("Help(Clone)");
			Canvas canvas = GameObject.FindObjectOfType<Canvas> ();
			helpClone.transform.SetParent (canvas.transform, false);
			//			Canvas canvas = GameObject.FindObjectOfType<Canvas>();
			//			GameObject obj = (GameObject)Resources.Load ("Prefabs/Help");
			//			GameObject prefab = (GameObject)Instantiate (obj);
			//			prefab.transform.SetParent (canvas.transform,false);
		} else {
			Destroy (helpClone);
		}
	}
}
