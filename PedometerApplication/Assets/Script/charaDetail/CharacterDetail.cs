using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDetail : MonoBehaviour {

	private GameObject petListPanel;
	public Transform petColPanel;
	public Button petButton;

	private Save save;
	private Sprite[] petSprites;
	private CommonButtonScript commonButtonScript;

	// Use this for initialization
	void Start () {
		save = GameObject.FindObjectOfType<Canvas> ().transform.GetComponent<Save> ();
		petSprites = Resources.LoadAll<Sprite> ("Image/ActRPGsprites/en");
		commonButtonScript = GameObject.Find("MenuBox").transform.GetComponent<CommonButtonScript> ();

		petListPanel = GameObject.Find ("PetListPanel");

		for (int i = 0; i < 4; i++) {
			GameObject pet = GameObject.Find ("Pet" + i);
			GameObject petListPet = GameObject.Find ("SelectPetPanel").transform.FindChild ("PetButton" + i).gameObject;
			if (i < save.selectPets.Length) {
				for (int j = 0; j < save.petNames.Length; j++) {
					if (save.selectPets [i].Equals (save.petNames [j])) {
						Sprite mainImageSprite = System.Array.Find<Sprite> (petSprites, (sprite) => sprite.name.Equals (save.mainImages [j]));
						pet.GetComponent<Image> ().sprite = mainImageSprite;
						petListPet.transform.FindChild("Image").GetComponent<Image> ().sprite = mainImageSprite;
					}
				}
			} else {
				pet.SetActive (false);
			}
		}

		Transform petColPanelClone = petColPanel;
		for (int i = 0; i < save.petNames.Length; i++) {
			if (i == 0 || i % 4 == 0) {
				// ぺット作成
				petColPanelClone = Instantiate (petColPanel, GameObject.Find ("Content").transform);
				// Object名設定
				petColPanelClone.name = "PetColPanel" + (i / 4);
			}
			Sprite mainImageSprite = System.Array.Find<Sprite> (petSprites, (sprite) => sprite.name.Equals (save.mainImages [i]));
			petColPanelClone.FindChild ("PetButton" + (i % 4)).FindChild ("Image").GetComponent<Image> ().sprite = mainImageSprite;
		}
		petListPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	// 詳細メイン画面のぺットタップ処理
	public void PetTap (Button button) {
		Debug.Log (button.GetComponent<Image> ());
		Debug.Log (button.GetComponent<Image> ().sprite);
		Debug.Log (button.GetComponent<Image> ().sprite.name);
		string mainImageName = button.GetComponent<Image> ().sprite.name;
		for(int i = 0; i < save.petNames.Length; i++){
			if (mainImageName.Equals (save.mainImages [i])) {
				GameObject.Find ("PetName").GetComponent<Text> ().text = save.petNames[i];
				GameObject.Find ("Description").GetComponent<Text> ().text = save.petDescriptions [i];
			}
		}
	}

	// 入替ボタンタップ処理
	public void PetListButtonTap () {
		petListPanel.SetActive (true);
	}

	// 入替画面の選択側ペットボタンタップ処理
	public void SelectPetPanelPetButtonTap (Button button) {
		if (button.transform.FindChild("Image").GetComponent<Image> ().sprite != null) {
			if (petButton == null) {
				petButton = button;
				petButton.transform.FindChild ("Image").GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 0.5f);
			} else if (!petButton.name.Equals (button.name)) {
				petButton.transform.FindChild ("Image").GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
				petButton = button;
				petButton.transform.FindChild ("Image").GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 0.5f);
			} else {
				petButton.transform.FindChild ("Image").GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
				petButton = null;
			}
		}
	}

	// 戻るボタンタップ処理
	public void BackButtonTap () {
		for (int i = 0; i < 4; i++) {
			GameObject petListPet = GameObject.Find ("SelectPetPanel").transform.FindChild ("PetButton" + i).gameObject;
			if (i < save.selectPets.Length) {
				for (int j = 0; j < save.petNames.Length; j++) {
					if (save.selectPets [i].Equals (save.petNames [j])) {
						Sprite mainImageSprite = System.Array.Find<Sprite> (petSprites, (sprite) => sprite.name.Equals (save.mainImages [j]));
						petListPet.transform.FindChild ("Image").GetComponent<Image> ().sprite = mainImageSprite;
					}
				}
			} else {
				petListPet.transform.FindChild ("Image").GetComponent<Image> ().sprite = null;
			}
		}
		if (petButton != null) {
			petButton.transform.FindChild ("Image").GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
			petButton = null;
		}
		petListPanel.SetActive (false);
	}

	// 決定ボタンタップ処理
	public void DecideButtonTap () {
		List<string> petNameList = new List<string>();
		foreach (Transform child in GameObject.Find("SelectPetPanel").transform) {
			for (int i = 0; i < save.mainImages.Length; i++) {
				if (child.FindChild ("Image").GetComponent<Image> ().sprite != null &&
					child.FindChild ("Image").GetComponent<Image> ().sprite.name.Equals (save.mainImages[i])) {
					petNameList.Add(save.petNames [i]);
				}
			}
		}
		string[] newSelectPets = petNameList.ToArray ();
		save.ChangeSelectPetsData (newSelectPets);
		commonButtonScript.CharacterScene ();
	}
}
