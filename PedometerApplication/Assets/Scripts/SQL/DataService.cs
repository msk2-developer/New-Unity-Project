using SQLite4Unity3d;
using UnityEngine;

#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService
{

	private SQLiteConnection _connection;

	public DataService (string DatabaseName)
	{

		#if UNITY_EDITOR
		var dbPath = string.Format (@"Assets/StreamingAssets/{0}", DatabaseName);
		#else
		// check if file exists in Application.persistentDataPath
		var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

		if (!File.Exists(filepath))
		{
		Debug.Log("Database not in Persistent path");
		// if it doesn't ->
		// open StreamingAssets directory and load the db ->

		#if UNITY_ANDROID 
		var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
		while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
		// then save to Application.persistentDataPath
		File.WriteAllBytes(filepath, loadDb.bytes);
		#elif UNITY_IOS
		var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		#elif UNITY_WP8
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);

		#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		#else
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);

		#endif

		Debug.Log("Database written");
		}

		var dbPath = filepath;
		#endif
		_connection = new SQLiteConnection (dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
		Debug.Log ("Final PATH: " + dbPath);     

	}
	
	// いらない
	//	public void CreateDB(){
	//		_connection.DropTable<PetData> ();
	//		_connection.CreateTable<PetData> ();
	//
	//		_connection.InsertAll (new[]{
	//			new PetData{
	//				petid = 1,
	//				petname = "スライム",
	//				pettype = 0,
	//				petdescription = "bbb",
	//				petmainimage = "ccc",
	//				petwalking1image = "ddd",
	//				petwalking2image = "eee",
	//				petwalking3image = "fff",
	//				petwalking4image = "ggg"
	//			}
	//		});
	//	}

	// ペット全取得
	public IEnumerable<PetData> GetAllPetData ()
	{
		return _connection.Table<PetData> ();
	}

	// ペット所持分取得
	public IEnumerable<PetData> GetAllMyPetData ()
	{
		return _connection.Table<PetData> ().Where (petData => petData.getflag == 1);
	}

	// 取得ペット更新
	public void UpdMyPetData (int petId, int getFlag)
	{
		string sql = "UPDATE PetData SET getflag = ? WHERE petid = ?";
		_connection.Query<PetData> (sql, new object[]{ getFlag, petId });
	}

	// 選択ペット取得
	public IEnumerable<PetData> GetSelectedPetData ()
	{
		string sql = "SELECT * FROM PetData INNER JOIN SelectedPetData" +
		             " ON PetData.petid = SelectedPetData.petid";
		return _connection.Query<PetData> (sql, new object[0]);
	}

	// 選択ペット登録
	public void DelInsSelectedPetData (int[] petId)
	{
		_connection.DeleteAll<SelectedPetData> ();
		for (int i = 0; i < petId.Length; i++) {
			var selectedPetData = new SelectedPetData {
				petid = petId [i]
			};
			_connection.Insert (selectedPetData);
		}
	}

	// ユーザ情報取得
	public IEnumerable<UserData> GetUserData ()
	{
		return _connection.Table<UserData> ();
	}

	// ユーザ情報登録
	public void DelInsUserData (string userName)
	{
		_connection.DeleteAll<UserData> ();
		var userData = new UserData {
			username = userName,
			userlevel = 1
		};
		_connection.Insert (userData);
	}

	// ユーザ情報更新
	public void UpdUserData (int userId, int userLevel, int getPoint, int todayWalkingCount, int totalWalkingCount)
	{
		_connection.Update (new UserData { userid = userId, userlevel = userLevel,
			point = getPoint, todaywalkingcount = todayWalkingCount, totalwalkingcount = totalWalkingCount
		});
	}

	// ユーザ情報削除
	public void DelUserData ()
	{
		_connection.DeleteAll<UserData> ();
	}
}
