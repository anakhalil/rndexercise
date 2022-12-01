using Microsoft.AspNetCore.Mvc;
using Simulate.Services;


[ApiController]
[Route("[controller]")]
public class SimulationController : ControllerBase{
    [HttpGet("simulate")]
    public void Sim(){
        SimulateService.Simulate();
    }

    [HttpGet("start")]
    public void Start(){
        // Tries to start the sim runner
        SimulateService.Start();
    }

    [HttpGet("progress")]
    public string Progress(){
        // state of runner
        return SimulateService.Progress();
    }

    [HttpGet("result")]
    public bool Result(){
        // Returns if the sim is running
        return SimulateService.isRunning();
    }
}