using SQLite4Unity3d;

public class UserData {
	[PrimaryKey, AutoIncrement]
	public int userid { get; set; }
	public string username { get; set; }
	public int userlevel { get; set; }
	public int point { get; set; }
	public int todaywalkingcount { get; set; }
	public int totalwalkingcount { get; set; }

	public UserData(){
	}

	public UserData(string userName){
		username = userName;
	}

	public override string ToString ()
	{
		return string.Format ("[pets: username={0}, userlevel={1}, point={2}, todaywalkingcount={3}, totalwalkingcount={4},",
			username, userlevel, point, todaywalkingcount, totalwalkingcount);
	}
}