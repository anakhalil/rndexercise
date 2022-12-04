namespace RndSimulate.Models;

public class Job{
	// model to represent a job submission

    public int Id { get; set; }
    public int Value { get; set; } // value in seconds
    public bool Done { get; set; }

    public Job(int id){
    	Id = id;
    	Value = 0;
    	Done = false;
    }
}