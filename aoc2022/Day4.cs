namespace adventofcode2022;

public class Day4 {
    private static readonly string _INPUT_FILE = "./input/day4.input";

    public static void p1() {
        var lines = File.ReadAllLines(_INPUT_FILE);
        var totalScore = 0;
        foreach (var line in lines) {
            if (!string.IsNullOrWhiteSpace(line)) {
                var ranges = line.Split(",");
                string[] range0str = ranges[0].Split("-");
                string[] range1str = ranges[1].Split("-");

                int[] range0 = { int.Parse(range0str[0]), int.Parse(range0str[1])};
                int[] range1 = { int.Parse(range1str[0]), int.Parse(range1str[1])};

                if (range0[0] < range1[0]) {
                    if (range0[1] >= range1[1]) {
                        totalScore++;
                    }
                } else if (range0[0] > range1[0]) {
                    if (range0[1] <= range1[1]) {
                        totalScore++;
                    }
                } else {
                    totalScore++;
                }
            }
        }
        Console.WriteLine(totalScore);
    }

    public static void p2() {
        var lines = File.ReadAllLines(_INPUT_FILE);
        var totalScore = 0;
        foreach (var line in lines) {
            if (!string.IsNullOrWhiteSpace(line)) {
                var ranges = line.Split(",");
                string[] range0str = ranges[0].Split("-");
                string[] range1str = ranges[1].Split("-");

                int[] range0 = { int.Parse(range0str[0]), int.Parse(range0str[1])};
                int[] range1 = { int.Parse(range1str[0]), int.Parse(range1str[1])};

                if (range0[0] < range1[0]) {
                    if (range0[1] >= range1[0]) {
                        totalScore++;
                    }
                } else if (range0[0] > range1[0]) {
                    if (range0[0] <= range1[1]) {
                        totalScore++;
                    }
                } else {
                    totalScore++;
                }
            }
        }
        Console.WriteLine(totalScore);
    }
}