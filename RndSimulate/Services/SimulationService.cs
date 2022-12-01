using System.Diagnostics;

namespace Simulate.Services;

public static class SimulateService{
    private static readonly Random rnd = new Random();
    private static ThreadStart tstart = new ThreadStart(Simulate);
    private static Thread thread;

    static SimulateService(){
        // instantiate thread, saves adding error handling
        thread = new Thread(()=>{});
    }

    public static void Simulate(){
        System.Threading.Thread.Sleep(rnd.Next(0,10) * 1000);
    }

    public static void Start(){
        if (!isRunning()){
            thread = new Thread(tstart);
            thread.Start();
        }
    }

    public static string Progress(){
        Debug.Assert(thread != null);
        return thread.ThreadState.ToString();
    }

    public static bool isRunning(){
        Debug.Assert(thread != null);
        return thread.IsAlive;
    }
}