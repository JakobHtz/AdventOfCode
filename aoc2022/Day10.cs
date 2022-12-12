using System.Diagnostics.Metrics;
using System.Security;
using System.Threading.Tasks.Dataflow;

namespace adventofcode2022;

public class Day10 {
    private static readonly string _INPUT_FILE = "./input/day10.input";

    public static void p1() {
        var lines = File.ReadAllLines(_INPUT_FILE);
        var x = 1;
        var cycles = 0;
        var firstCycle = 20;
        var interval = 40;
        var signalStrengthList = new List<int>();
        var count = 6;
        var sum = 0;

        foreach (var line in lines) {
            if (!string.IsNullOrWhiteSpace(line)) {
                var instruction = line.Split(" ")[0];
                void CheckCycle() {
                    if (firstCycle == (cycles%interval)) {
                        var signalStrength = x * cycles;
                        signalStrengthList.Add(signalStrength);
                        //Console.WriteLine(cycles + " " + signalStrength);
                    }
                }
                cycles++;
                CheckCycle();

                if (instruction == "addx") {
                    cycles ++;
                    CheckCycle();
                    x += int.Parse(line.Split(" ")[1].Trim());
                }
            }
        }
        for (var i = 0; i < count; i++) {
            sum+= signalStrengthList[i];
        }
        Console.WriteLine(sum);
    }
    
    public static void p2() {
        var lines = File.ReadAllLines(_INPUT_FILE);
        var x = 1;
        var cycles = 0;
        var interval = 40;
        var output = new List<string>();

        foreach (var line in lines) {
            if (!string.IsNullOrWhiteSpace(line)) {
                var instruction = line.Split(" ")[0];
                void CheckCycle() {
                    if ((cycles%interval)-1 >= x-1  && (cycles%interval)-1 <= x+1) {
                        output.Add("#");
                    } else {
                        output.Add(".");
                    }
                }
                cycles++;
                CheckCycle();

                if (instruction.Trim() == "addx") {
                    cycles ++;
                    CheckCycle();
                    x += int.Parse(line.Split(" ")[1].Trim());
                }
            }
        }
        for (int i = 0; i < output.Count(); i++) {
            Console.Write(output[i]);
            if (i%interval == interval-1) {
                Console.Write("\n");
            }
        }
    }
}