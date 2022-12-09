namespace adventofcode2022;

public class Day8 {
    private static readonly string _INPUT_FILE = "./input/day8.input";

    public static void p1() {
        var lines = File.ReadAllLines(_INPUT_FILE);
        var treeGrid = new List<int>();
        int gridSize = lines[0].Length;
        int totalVisibleTrees = 2*gridSize;

        foreach (var line in lines) {
            if (!string.IsNullOrWhiteSpace(line)) {
                foreach (char c in line) {
                    var tmp = ""+c;
                    treeGrid.Add(int.Parse(tmp));
                }
            }
        }

        for (int i = gridSize; i < treeGrid.Count()-gridSize; i++) {
            if (i%gridSize == 0 || i%gridSize == gridSize-1) {
                totalVisibleTrees++;
                continue;
            }

            int biggestTreeRight = -1;
            for (int j = i+1; !(j%gridSize==0); j++) {
                if (treeGrid[j]>biggestTreeRight) {
                    biggestTreeRight = treeGrid[j];
                }
            }
            int biggestTreeLeft = -1;
            for (int j = i-1; !(j%gridSize==gridSize-1); j--) {
                if (treeGrid[j]>biggestTreeLeft) {
                    biggestTreeLeft = treeGrid[j];
                }
            }
            int biggestTreeDown = -1;
            for (int j = i+gridSize; j<treeGrid.Count(); j+=gridSize) {
                if (treeGrid[j]>biggestTreeDown) {
                    biggestTreeDown = treeGrid[j];
                }
            }
            int biggestTreeUp = -1;
            for (int j = i-gridSize; j >= 0; j-=gridSize) {
                if (treeGrid[j]>biggestTreeUp) {
                    biggestTreeUp = treeGrid[j];
                }
            }

            if(treeGrid[i]>biggestTreeRight     ||
               treeGrid[i]>biggestTreeLeft      ||
               treeGrid[i]>biggestTreeDown      ||
               treeGrid[i]>biggestTreeUp) 
            {
                totalVisibleTrees++;
                continue;
            } else {
                Console.WriteLine("{5}\t[{0}]\n[{1}]\t[{2}]\t[{3}]\n\t[{4}]\n",biggestTreeUp, biggestTreeLeft, treeGrid[i], biggestTreeRight, biggestTreeDown,i);
            }
        }

        Console.WriteLine(totalVisibleTrees);
    }
    
    public static void p2() {
        var lines = File.ReadAllLines(_INPUT_FILE);
        var treeGrid = new List<int>();
        int gridSize = lines[0].Length;

        foreach (var line in lines) {
            if (!string.IsNullOrWhiteSpace(line)) {
                foreach (char c in line) {
                    var tmp = ""+c;
                    treeGrid.Add(int.Parse(tmp));
                }
            }
        }

        int highestScenicScore = -1;
        for (int i = 0; i < treeGrid.Count(); i++) {
            var lineStart = (int)(i/gridSize)*gridSize;
            var lineEnd = (int)(i/gridSize)*gridSize+gridSize;
            int scenicScoreRight = 0;
            for (int j = i+1; j<lineEnd; j++) {
                scenicScoreRight++;
                if (treeGrid[j]>=treeGrid[i]) {
                    break;
                }
            }
            int scenicScoreLeft = 0;
            for (int j = i-1; j>=lineStart; j--) {
                scenicScoreLeft++;
                if (treeGrid[j]>=treeGrid[i]) {
                    break;
                }
            }
            int scenicScoreDown = 0;
            for (int j = i+gridSize; j<treeGrid.Count(); j+=gridSize) {
                scenicScoreDown++;
                if (treeGrid[j]>=treeGrid[i]) {
                    break;
                }
            }
            int scenicScoreUp = 0;
            for (int j = i-gridSize; j >= 0; j-=gridSize) {
                scenicScoreUp++;
                if (treeGrid[j]>=treeGrid[i]) {
                    break;
                }
            }

            var scenicScore = scenicScoreUp * scenicScoreLeft * scenicScoreRight * scenicScoreDown;
            if(scenicScore > highestScenicScore){
                highestScenicScore = scenicScore;
                Console.WriteLine("{4}\t[{0}]\n[{1}]\t[x]\t[{2}]\n\t[{3}]\t{5}\n",scenicScoreUp, scenicScoreLeft, scenicScoreRight, scenicScoreDown,i,scenicScore);
                continue;
            }
        }

        Console.WriteLine(highestScenicScore);
    }
}