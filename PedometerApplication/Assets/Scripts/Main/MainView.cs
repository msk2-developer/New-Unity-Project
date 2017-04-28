using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour {

	/* ペットボタン関連 */
	private GameObject petButton;
	private GameObject petPanel;
	public Transform petAnimation;
	private Transform petAnimationClone;
	private Sprite newPetSprite;
	private List<PetData> wildPetDataList;

	/* キャラの動き関連 */
	public Transform mainCamera;

	private GameObject petWalk1;
	private GameObject petWalk2;
	private GameObject petWalk3;
	private GameObject petWalk4;

	private Canvas canvas;

	private GameObject mainmenu;

	DataService ds;

	// Use this for initialization
	void Start () {
		canvas = GameObject.FindObjectOfType<Canvas> ();
		ds = new DataService ("PedometerApplication.db");

		// データ設定
		GameObject.Find("UserName").GetComponent<Text>().text = SaveData.GetUserData().username;
		GameObject.Find("Level").GetComponent<Text>().text = SaveData.GetUserData().userlevel.ToString();
		GameObject.Find("PointCount").GetComponent<Text>().text = SaveData.GetUserData().point.ToString();
		GameObject.Find("WalkingCount").GetComponent<Text>().text = SaveData.GetUserData().todaywalkingcount.ToString();

		// メニューバーのメインメニューボタンの名称変更
		mainmenu = GameObject.Find("MainMenu");

		mainmenu.name = "menubutton";
		// ペットボタン制御
		wildPetDataList = ds.GetWildPetData ();
		petButton = GameObject.Find ("PetButton");
		if (wildPetDataList != null && 0 < wildPetDataList.Count) {
			petButton.SetActive (true);
		} else {
			petButton.SetActive (false);
		}
		petPanel = GameObject.Find("PetPanel");
		petPanel.SetActive (false);
		// ペットの設定
		for(int i = 0; i < SaveData.GetSelPetJoinAllPetDataList().Count;i++){
			// ぺット表示
			this.AddPet ("petAnimation" + i, SaveData.GetSelPetJoinAllPetDataList()[i]);
		}
		// 今日の歩数を取得
		Example.ShowHistry ();
	}
	
	// Update is called once per frame
	void Update () {
		// キャラの動き設定
		// 背景の動き
		this.BackGroundAnimation();
		// ペットの動き
		for (int i = 0; i < 4; i++) {
			if (GameObject.Find ("petAnimation" + i) != null && GameObject.Find ("petAnimation" + i).activeSelf) {
				Transform petAnimationTransform = GameObject.Find ("petAnimation" + i).transform;
				this.CharacterAnimation (petAnimationTransform.FindChild ("PetWalk1").gameObject,
					petAnimationTransform.FindChild ("PetWalk2").gameObject,
					petAnimationTransform.FindChild ("PetWalk3").gameObject,
					petAnimationTransform.FindChild ("PetWalk4").gameObject);
			} else {
				break;
			}
		}
	}

	// ペットボタンタップ処理
	public void PetButtonTap () {
		// お知らせボタンを非表示
		petButton.SetActive(false);
		// ゲット画面を表示
		petPanel.SetActive(true);
		// ランダムでペットをゲットする
		List<PetData> wildPetDataList = ds.GetWildPetData ();
		int rnd = Random.Range(0, wildPetDataList.Count);
		newPetSprite = Resources.Load<Sprite> ("Image/ActRPGsprites/" + wildPetDataList[rnd].petmainimage);
		GameObject.Find ("Pet").GetComponent<Image> ().sprite = newPetSprite;
	}

	// OKボタンタップ処理
	public void OkButtonTap () {
		// ゲット画面を非表示
		petPanel.SetActive(false);
		// ぺット表示
		string gameObjectName = null;
		for (int i = 0; i < 4; i++) {
			if (GameObject.Find ("petAnimation" + i) == null) {
				gameObjectName = "petAnimation" + i;
				break;
			}
		}
		// ペット情報登録
		int newPetId = 0;
		wildPetDataList = ds.GetWildPetData ();
		foreach (PetData c in wildPetDataList) {
			if (c.petmainimage.Equals (newPetSprite.name.Remove(newPetSprite.name.IndexOf("_")))) {
				newPetId = c.petid;
				break;
			}
		}
		ds.UpdMyPetDataByPetId (newPetId);
		SaveData.SetMyPetDataList (ds.GetAllMyPetData ());
		if (gameObjectName != null) {
			// 選択ペット登録
			List<int> petIdList = new List<int> ();
			foreach (SelPetJoinAllPetData c in SaveData.GetSelPetJoinAllPetDataList()) {
				petIdList.Add (c.petid);
			}
			petIdList.Add (newPetId);
			ds.DelInsSelectedPetData (petIdList);
			SaveData.SetSelPetJoinAllPetDataList (ds.GetSelPetJoinAllPetData());
			// 画面へのぺット追加
			this.AddPet (gameObjectName, SaveData.GetSelPetJoinAllPetDataList()[SaveData.GetSelPetJoinAllPetDataList().Count - 1]);
		}
	}

	// 画面へのぺット追加処理
	void AddPet(string petAnimationName, SelPetJoinAllPetData selPetJoinAllPetData){
		// ぺット作成
		petAnimationClone = Instantiate (petAnimation, canvas.transform, false);
		// Object名設定
		petAnimationClone.name = petAnimationName;
		// ポジション設定
		petAnimationClone.localPosition = this.getPosition (petAnimationName);
		// ヒエラルキー位置設定
		petAnimationClone.SetSiblingIndex(1);

		petWalk1 = petAnimationClone.FindChild("PetWalk1").gameObject;
		petWalk2 = petAnimationClone.FindChild("PetWalk2").gameObject;
		petWalk3 = petAnimationClone.FindChild("PetWalk3").gameObject;
		petWalk4 = petAnimationClone.FindChild("PetWalk4").gameObject;
		petWalk1.SetActive (false);
		petWalk2.SetActive (false);
		petWalk3.SetActive (false);
		petWalk4.SetActive (true);
		// 画像設定
		Sprite[] petSprites = Resources.LoadAll<Sprite> ("Image/ActRPGsprites/" + selPetJoinAllPetData.petmainimage);
		Sprite walkingSprite = System.Array.Find<Sprite>( petSprites, (sprite) => sprite.name.Equals(selPetJoinAllPetData.petwalking1image));
		petWalk1.GetComponent<Image>().sprite = walkingSprite;
		walkingSprite = System.Array.Find<Sprite>( petSprites, (sprite) => sprite.name.Equals(selPetJoinAllPetData.petwalking2image));
		petWalk2.GetComponent<Image>().sprite = walkingSprite;
		walkingSprite = System.Array.Find<Sprite>( petSprites, (sprite) => sprite.name.Equals(selPetJoinAllPetData.petwalking3image));
		petWalk3.GetComponent<Image>().sprite = walkingSprite;
		walkingSprite = System.Array.Find<Sprite>( petSprites, (sprite) => sprite.name.Equals(selPetJoinAllPetData.petwalking4image));
		petWalk4.GetComponent<Image>().sprite = walkingSprite;
	}

	// ぺット表示位置取得
	Vector3 getPosition(string petAnimationName){
		Vector3 position;
		if ("petAnimation0".Equals(petAnimationName)) {
			position = new Vector3 (133.0f, -191.0f);
		} else if ("petAnimation1".Equals(petAnimationName)) {
			position = new Vector3 (43.0f, -170.0f);
		} else if ("petAnimation2".Equals(petAnimationName)) {
			position = new Vector3 (-53.0f, -190.0f);
		} else {
			position = new Vector3 (-143.0f, -170.0f);
		}
		return position;
	}

	// 背景の動き
	void BackGroundAnimation () {
		mainCamera.Translate (0.05f, 0, 0);
		if (mainCamera.position.x > 122f ) {
			mainCamera.position = new Vector3 (100, 142.2f, -13f);
		}
	}

	// キャラ/ペットの動き
	void CharacterAnimation (GameObject walk1, GameObject walk2, GameObject walk3, GameObject walk4) {
		// 動きの設定
		if (Time.frameCount % 15 == 0) {
			if (walk1.activeSelf) {
				walk1.SetActive (false);
				walk2.SetActive (true);
				walk3.SetActive (false);
				walk4.SetActive (false);
			} else if (walk2.activeSelf) {
				walk1.SetActive (false);
				walk2.SetActive (false);
				walk3.SetActive (true);
				walk4.SetActive (false);
			} else if (walk3.activeSelf) {
				walk1.SetActive (false);
				walk2.SetActive (false);
				walk3.SetActive (false);
				walk4.SetActive (true);
			}else{
				walk1.SetActive (true);
				walk2.SetActive (false);
				walk3.SetActive (false);
				walk4.SetActive (false);
			}
		}
	}
}
