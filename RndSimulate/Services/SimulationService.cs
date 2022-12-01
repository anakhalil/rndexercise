using System.Diagnostics;

namespace Simulate.Services;

public static class SimulateService{
    private static readonly Random rnd = new Random();

    public static void Simulate(){
        System.Threading.Thread.Sleep(rnd.Next(0,10) * 1000);
    }
}