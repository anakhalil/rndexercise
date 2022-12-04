using Microsoft.AspNetCore.Mvc;
using RndSimulate.Services;
using RndSimulate.Models;


[ApiController]
[Route("[controller]")]
public class SimulationController : ControllerBase{

    [HttpGet("simulate")]
    public void Sim(){
        // run sim function
        // sleeps 0 - 10 seconds
        SimulateService.Simulate();
    }

    [HttpPost]
    public IActionResult Create(){
        // submit sim job to que with random sleep time
        // returns id of submitted job
        int id = SimulateService.Create();
        return CreatedAtAction(nameof(Create), new { id });
    }

    [HttpGet("start")]
    public bool Start(){
        // Tries to start the job runner
        // returns true on success
        return SimulateService.Start();
    }

    [HttpGet("que")]
    // returns list of job que
    public ActionResult<List<Job>> GetAll() =>
        SimulateService.GetAll();

    [HttpGet("{id}")]
    // get specific job submission with id
    // returns single job
    public ActionResult<Job> Get(int id){
        var job = SimulateService.Get(id);

        if(job == null)
            return NotFound();

        return job;
    }

    [HttpGet("progress")]
    // get a summary of jobs
    public String Progress() =>
        SimulateService.Progress();

}