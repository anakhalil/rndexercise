using Microsoft.AspNetCore.Mvc;
using Simulate.Services;


[ApiController]
[Route("[controller]")]
public class SimulationController : ControllerBase{
    [HttpGet("simulate")]
    public void Sim(){
        SimulateService.Simulate();
    }
}