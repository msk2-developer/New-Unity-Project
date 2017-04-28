using SQLite4Unity3d;

public class PetData {
	[PrimaryKey, AutoIncrement]
	public int petid { get; set; }
	public int getflag { get; set; }
	public int goodsflag { get; set; }
	public string petname { get; set; }
	public int pettype { get; set; }
	public string petdescription { get; set; }
	public string petmainimage { get; set; }
	public string petwalking1image { get; set; }
	public string petwalking2image { get; set; }
	public string petwalking3image { get; set; }
	public string petwalking4image { get; set; }

	public PetData(){
	}

	public PetData(string name){
		petname = name;
	}

	public override string ToString ()
	{
		return string.Format ("[PetData: petid={0}, getflag={1}, goodsflag={2}, petname={3}, pettype={4}, petdescription={5}," +
			" petmainimage={6}, petwalking1Image={7}, petwalking2Image={8}, petwalking3Image={9}, petwalking4Image={10}",
			petid, getflag, goodsflag, petname, pettype, petdescription, petmainimage, petwalking1image, petwalking2image,
			petwalking3image, petwalking4image);
	}
}