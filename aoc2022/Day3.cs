namespace adventofcode2022;

public class Day3 {

    public static void p1() {
        var lines = File.ReadAllLines("./input/day3.input");
        var totalScore = 0;
        foreach (var line in lines) {
            if (!string.IsNullOrWhiteSpace(line)) {
                var b0 = line.Substring(0,line.Count()/2);
                var b1 = line.Substring(line.Count()/2,line.Count()/2);
                
                int Work() {
                    foreach (char c0 in b0) {
                        foreach (char c1 in b1) {
                            if (c0 == c1) {
                                var score = 0;
                                if (c0 > 96) {
                                    score += c0 - 96;
                                } else {
                                    score += c0 - 64 + 26;
                                }   
                                return score;
                            }
                        }
                    }
                    return 0;
                }
                
                var score = Work();
                
                Console.WriteLine(score);
                totalScore += score;
            }
        }
        Console.WriteLine(totalScore);
    }

    public static void p2() {
        var lines = File.ReadAllLines("./input/day3.input");
        var totalScore = 0;
        for (var i = 0; i < lines.Count(); i+=3) {
            var tmpList = new List<char>();
            string[] elfs = {
                lines[i], 
                lines[i+1],
                lines[i+2]
            };

            for (int j = 0; j < elfs[0].Count(); j++) {
                for (int x = 0; x < elfs[1].Count(); x++) {
                    if (elfs[0][j] == elfs[1][x]) {
                        tmpList.Add(elfs[0][j]);
                    }
                }
            }
            var distList = tmpList.Distinct();

            int Work() {
                foreach (char c0 in distList) {
                    foreach (char c1 in elfs[2]) {
                        if (c0 == c1) {
                            var score = 0;
                            if (c0 > 96) {
                                score += c0 - 96;
                            } else {
                                score += c0 - 64 + 26;
                            }   
                            return score;
                        }
                    }
                }
                return 0;
            }
            var score = Work();
            totalScore += score;
        }
        
        Console.WriteLine(totalScore);
    }
}
