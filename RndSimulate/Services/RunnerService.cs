using RndSimulate.Models;
using System.Diagnostics;

namespace RndSimulate.Services;

public static class RunnerService{
    // Runner (consumer) manager
    // has ability to run jobs.
    // runs tasks in one thread

    private static List<Job> Jobs = new List<Job>();
    private static Thread thread;

    static RunnerService(){
        // instantiate thread to avoid error handling
        thread = new Thread(()=>{});
    }

    //public static List<Job> GetQue(){
    //    return Jobs;
    //}

    public static void Add(Job job){
        Jobs.Add(job);
    }

    public static List<Job> GetQue(){
        // return copy of jobs, "current jobs" to avoid mutating
        // list if its being accessed.
        return new List<Job>(Jobs);
    }

    public static List<Job> GetDoneJobs(){

        var CJobs = GetQue();
        List<Job> tmp = new List<Job>();

        foreach (Job job in CJobs){
            if (job.Done){
                tmp.Add(job);

            }
        }

        return tmp;
    }

    public static List<Job> GetReadyJobs(){

        var CJobs = GetQue();
        List<Job> tmp = new List<Job>();

        foreach (Job job in CJobs){
            if (!job.Done){
                tmp.Add(job);

            }
        }

        return tmp;
    }

    public static bool start(){
        // Uses one thread to avoid processing the list at 
        // the same time.

        Debug.Assert(thread != null);

        if (!thread.IsAlive){
            // use a thread to "fire and forget" processing the jobs
            thread = new Thread(new ThreadStart(Run));
            thread.Start();

            return true;
        }

        return false;
    }

    private static void Run(){
        // runs through each job and process simulate

        var CJobs = GetQue();

        foreach (Job job in CJobs){
            if (job.Done){
                // early out
                continue;
            }

            // Adds each job to the task pool
            // Task.Run(() => {
            //     Simulate(job.Value); 
            //     job.Done = true;
            // });

            var t = Task.Run(() => Simulate(job.Value));
            // wait to simulate slow runner.
            // processes each job one by one.
            t.Wait();

            job.Done = true;
        }
    }

    public static void Simulate(int s){
        System.Threading.Thread.Sleep(s * 1000 );
    }

}