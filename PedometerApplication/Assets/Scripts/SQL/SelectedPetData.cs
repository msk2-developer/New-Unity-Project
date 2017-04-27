using SQLite4Unity3d;

public class SelectedPetData {
	[PrimaryKey, AutoIncrement]
	public int sortnum { get; set; }
	public int petid { get; set; }

	public SelectedPetData(){
	}

	public SelectedPetData(int petId){
		petid = petId;
	}

	public override string ToString ()
	{
		return string.Format ("[SelectedPetData: sortnum={0}, petid={1}", sortnum, petid);
	}
}