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
	public List<PetData> GetAllPetData ()
	{
		IEnumerable<PetData> petData = _connection.Table<PetData> ();
		List<PetData> result = new List<PetData> ();
		foreach (var c in petData) {
			result.Add (c);
		}

		return result;
	}

	// 野生の(所持しておらず、ショップに売っていない)ペット取得
	public List<PetData> GetWildPetData ()
	{
		IEnumerable<PetData> petData = _connection.Table<PetData> ().Where (p => p.getflag == 0 && p.goodsflag == 0);
		List<PetData> result = new List<PetData> ();
		foreach (var c in petData) {
			result.Add (c);
		}

		return result;
	}

	// ペット所持分取得
	public List<PetData> GetAllMyPetData ()
	{
		IEnumerable<PetData> petData = _connection.Table<PetData> ().Where (p => p.getflag == 1);
		List<PetData> result = new List<PetData> ();
		foreach (var c in petData) {
			result.Add (c);
		}
		return result;
	}

	// 取得ペット更新 (IDで)
	public void UpdMyPetDataByPetId (int petId)
	{
		string sql = "UPDATE PetData SET getflag = 1 WHERE petid = ?";
		_connection.Query<PetData> (sql, new object[]{ petId });
	}

	// 取得ペット更新 (ペット名で)
	public void UpdMyPetDataByPetName (string petName)
	{
		string sql = "UPDATE PetData SET getflag = 1 WHERE petname = ?";
		_connection.Query<PetData> (sql, new object[]{ petName });
	}

	// 選択ペット取得 (PetDataとJoin済)
	public List<SelPetJoinAllPetData> GetSelPetJoinAllPetData ()
	{
		string sql = "SELECT * FROM PetData INNER JOIN SelectedPetData" +
		             " ON PetData.petid = SelectedPetData.petid ORDER BY SelectedPetData.sortnum";
		IEnumerable<SelPetJoinAllPetData> petData = _connection.Query<SelPetJoinAllPetData> (sql, new object[0]);
		List<SelPetJoinAllPetData> result = new List<SelPetJoinAllPetData> ();
		foreach (var c in petData) {
			result.Add (c);
		}
		return result;
	}

	// 選択ペット登録
	public void DelInsSelectedPetData (List<int> petIdList)
	{
		_connection.DeleteAll<SelectedPetData> ();
		foreach (int c in petIdList) {
			var selectedPetData = new SelectedPetData {
				petid = c
			};
			_connection.Insert (selectedPetData);
		}
	}

	// ユーザ情報取得
	public UserData GetUserData ()
	{
		IEnumerable<UserData> userData = _connection.Table<UserData> ();
		UserData result = null;
		foreach (var c in userData) {
			result = c;
			break;
		}
		return result;
	}

	// ユーザ情報登録
	public void DelInsUserData (string userName)
	{
		_connection.DeleteAll<UserData> ();
		var userData = new UserData {
			username = userName,
			userlevel = 1,
			point = 0,
			todaywalkingcount = 0,
			totalwalkingcount = 0
		};
		_connection.Insert (userData);
	}

	// ユーザ情報更新
	public void UpdUserData (int userId, string userName, int userLevel, int getPoint, int todayWalkingCount, int totalWalkingCount)
	{
		_connection.Update (new UserData { userid = userId, username = userName, userlevel = userLevel,
			point = getPoint, todaywalkingcount = todayWalkingCount, totalwalkingcount = totalWalkingCount
		});
	}

	// ユーザ情報削除
	public void DelUserData ()
	{
		_connection.DeleteAll<UserData> ();
	}

	// 選択ペット削除
	public void DelSelectedPetData ()
	{
		_connection.DeleteAll<SelectedPetData> ();
		string sql = "UPDATE PetData SET getflag = 0";
		_connection.Query<PetData> (sql, new object[0]);
	}
}
