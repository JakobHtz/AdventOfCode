namespace adventofcode2022;

public class Day9 {
    private static readonly string _INPUT_FILE = "./input/day9.input";

    public static void p1() {
        var lines = File.ReadAllLines(_INPUT_FILE);

        var head = new int[2]{0,0};
        var tail = new int[2]{0,0};
        var moveCount = 0;
        var visited = new List<string>();
        visited.Add("0;0");

        foreach (var line in lines) {
            if (!string.IsNullOrWhiteSpace(line)) {
                var moveset = line.Split(" ");
                var instruction = moveset[0].Trim();
                var amount = int.Parse(moveset[1].Trim());
                
                for (int j = 0; j < amount; j++) {
                    switch (instruction) {
                        case "U":
                            head[1]--;
                            break;
                        case "D":
                            head[1]++;
                            break;
                        case "R":
                            head[0]++;
                            break;
                        case "L":
                            head[0]--;
                            break;
                    }
                    //Console.WriteLine("HEAD[{0}][{1}]", head[0], head[1]);

                    void MoveTail() {
                        if (
                            (head[0]-tail[0]<=1 && head[0]-tail[0]>=-1) &&
                            (head[1]-tail[1]<=1 && head[1]-tail[1]>=-1)
                        ) {
                            return;
                        }
                        if (head[0]<tail[0]) {
                            tail[0]--;
                        } else if (head[0]>tail[0]) {
                            tail[0]++;
                        }
                        if (head[1]<tail[1]) {
                            tail[1]--;
                        } else if (head[1]>tail[1]) {
                            tail[1]++;
                        }
                        //Console.WriteLine("TAIL[{0}][{1}]", tail[0], tail[1]);
                        visited.Add(string.Format("{0};{1}", tail[0], tail[1]));
                        moveCount++;
                    }
                    MoveTail();
                }
            }
        }
        Console.WriteLine(moveCount + "-" + visited.Distinct().Count());
    }
    
    public static void p2() {
        var lines = File.ReadAllLines(_INPUT_FILE);

        var snake = new int[][]{
            new int[]{0,0}, //Head
            new int[]{0,0}, //1
            new int[]{0,0}, //2
            new int[]{0,0}, //3
            new int[]{0,0}, //4
            new int[]{0,0}, //5
            new int[]{0,0}, //6
            new int[]{0,0}, //7
            new int[]{0,0}, //8
            new int[]{0,0}, //Tail
        };
        var moveCount = 0;
        var visited = new List<string>();
        visited.Add("0;0");

        foreach (var line in lines) {
            if (!string.IsNullOrWhiteSpace(line)) {
                var moveset = line.Split(" ");
                var instruction = moveset[0].Trim();
                var amount = int.Parse(moveset[1].Trim());
                
                for (int j = 0; j < amount; j++) {
                    switch (instruction) {
                        case "U":
                            snake[0][1]--;
                            break;
                        case "D":
                            snake[0][1]++;
                            break;
                        case "R":
                            snake[0][0]++;
                            break;
                        case "L":
                            snake[0][0]--;
                            break;
                    }
                    //Console.WriteLine("HEAD[{0}][{1}]", tails[0][0], tails[0][1]);

                    void MoveTail() {
                        for (var x = 1; x < snake.Length; x++) {
                            var head = snake[x-1];
                            var tail = snake[x];
                            if (
                                (head[0]-tail[0]<=1 && head[0]-tail[0]>=-1) &&
                                (head[1]-tail[1]<=1 && head[1]-tail[1]>=-1)
                            ) {
                                return;
                            }
                            if (head[0]<tail[0]) {
                                tail[0]--;
                            } else if (head[0]>tail[0]) {
                                tail[0]++;
                            }
                            if (head[1]<tail[1]) {
                                tail[1]--;
                            } else if (head[1]>tail[1]) {
                                tail[1]++;
                            }
                            if (x == snake.Length-1) {
                                moveCount++;
                                visited.Add(string.Format("{0};{1}", tail[0], tail[1]));
                                //Console.WriteLine("TAIL[{0}][{1}]", tail[0], tail[1]);
                            }
                        }
                    }
                    MoveTail();
                }
            }
        }
        Console.WriteLine(moveCount + "-" + visited.Count() + "-" + visited.Distinct().Count());
    }
}