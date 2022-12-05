namespace adventofcode2022;

public class Day2 {
    public static void p1() {
        var lines = File.ReadAllLines("./input/day2.input");
        var totalScore = 0;
        foreach (var line in lines) {
            if (!string.IsNullOrWhiteSpace(line)) {
                var moveset = line.Split(" ");
                var opponent = moveset[0].Trim();
                var yourself = moveset[1].Trim();
                //Console.WriteLine(opponent+" "+yourself);
                switch(yourself) {
                    case "X":
                        totalScore += 1;
                        switch(opponent) {
                            case "A":
                                totalScore += 3;
                                break;
                            case "B":
                                totalScore += 0;
                                break;
                            case "C":
                                totalScore += 6;
                                break;
                        }
                        break;
                    case "Y":
                        totalScore += 2;
                        switch(opponent) {
                            case "A":
                                totalScore += 6;
                                break;
                            case "B":
                                totalScore += 3;
                                break;
                            case "C":
                                totalScore += 0;
                                break;
                        }
                        break;
                    case "Z":
                        totalScore += 3;
                        switch(opponent) {
                            case "A":
                                totalScore += 0;
                                break;
                            case "B":
                                totalScore += 6;
                                break;
                            case "C":
                                totalScore += 3;
                                break;
                        }
                        break;
                }
            }
        }
        Console.WriteLine(totalScore);
    }

    public static void p2() {
        var lines = File.ReadAllLines("./input/day2.input");
        var totalScore = 0;
        foreach (var line in lines) {
            if (!string.IsNullOrWhiteSpace(line)) {
                var moveset = line.Split(" ");
                var opponent = moveset[0].Trim();
                var desiredOutcome = moveset[1].Trim();
                //Console.WriteLine(opponent+" "+yourself);
                switch(opponent) {
                    case "A":
                        switch(desiredOutcome) {
                            case "X":
                                totalScore += 3;
                                totalScore += 0;
                                break;
                            case "Y":
                                totalScore += 1;
                                totalScore += 3;
                                break;
                            case "Z":
                                totalScore += 2;
                                totalScore += 6;
                                break;
                        }
                        break;
                    case "B":
                        switch(desiredOutcome) {
                            case "X":
                                totalScore += 1;
                                totalScore += 0;
                                break;
                            case "Y":
                                totalScore += 2;
                                totalScore += 3;
                                break;
                            case "Z":
                                totalScore += 3;
                                totalScore += 6;
                                break;
                        }
                        break;
                    case "C":
                        switch(desiredOutcome) {
                            case "X":
                                totalScore += 2;
                                totalScore += 0;
                                break;
                            case "Y":
                                totalScore += 3;
                                totalScore += 3;
                                break;
                            case "Z":
                                totalScore += 1;
                                totalScore += 6;
                                break;
                        }
                        break;
                }
            }
        }
        Console.WriteLine(totalScore);
    }
}
