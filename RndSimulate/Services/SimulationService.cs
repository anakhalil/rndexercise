using RndSimulate.Models;

namespace RndSimulate.Services;

public static class SimulateService{
    // message broker, comunicates between endpoint (Controller)
    // and runner service

    private static readonly Random rnd = new Random();
    private static int MinSleep = 0;
    private static int MaxSleep = 30;

    public static int Create(){
        Job j = new Job(RunnerService.GetQue().Count + 1);
        j.Value = rnd.Next(MinSleep,MaxSleep);
        RunnerService.Add(j);

        return j.Id;
    }

    public static bool Start(){
        return RunnerService.start();
    }

    public static void Simulate(){
        RunnerService.Simulate(rnd.Next(MinSleep,MaxSleep));
    }

    public static List<Job> GetAll() => RunnerService.GetQue();

    public static Job? Get(int id) => (
        RunnerService.GetQue()).FirstOrDefault(J => J.Id == id);
    
    public static String Progress(){
        var total = RunnerService.GetQue().Count;
        double ready = RunnerService.GetReadyJobs().Count;
        double done = RunnerService.GetDoneJobs().Count;

        double p = 0;
        if (total != 0){
            p = (done/total)*100;
            p = Math.Round(p, 2);
        }

        return $"{total} total jobs" +
            $"\n{ready} waiting to run" +
            $"\n{done} jobs complete" +
            $"\n{p} % completion";

    }

}