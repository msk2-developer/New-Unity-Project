using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetButton : MonoBehaviour {

	private GameObject petButton;

	public void PetButtonTap () {
		petButton = GameObject.Find ("PetButton");
		petButton.SetActive(false);
	}
}
