namespace adventofcode2022;

public class Day5 {
    private static readonly string _INPUT_FILE = "./input/day5.input";

    public static void p1() {
        var lines = File.ReadAllLines(_INPUT_FILE);
        List<Stack<char>> stacks = new List<Stack<char>>();
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());

        for (int i = 7; i >= 0; i--) {
            var line = lines[i];
            for (int j = 0; j < 9; j++) {
                var containerWidth = 4;
                string container;
                if (line.Length>containerWidth) {
                    container = line.Substring(0,containerWidth);
                    line = line.Substring(containerWidth, line.Length-containerWidth);
                } else {
                    container = line;
                }
                if (!string.IsNullOrWhiteSpace(container)) {
                    stacks[j].Push((container.Trim()).Substring(1,1)[0]);
                }
            }
        }

        for (int i = 10; i < lines.Count(); i++ ) {
            var line = lines[i];
            if (!string.IsNullOrWhiteSpace(line)) {
                var moves = line.Split(" ");
                int crateCount = int.Parse(moves[1].Trim());
                int fromStack = int.Parse(moves[3].Trim())-1;
                int toStack = int.Parse(moves[5].Trim())-1;

                for (int j = 0; j < crateCount; j++) {
                    char crate = stacks[fromStack].Pop();
                    stacks[toStack].Push(crate);
                }
            }
        }

        var text = "";
        for (int i = 0; i < 9; i++) {
            text += stacks[i].Peek();
        }
        Console.WriteLine(text);
    }
    
    public static void p2() {
        var lines = File.ReadAllLines(_INPUT_FILE);
        List<Stack<char>> stacks = new List<Stack<char>>();
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());
        stacks.Add(new Stack<char>());

        for (int i = 7; i >= 0; i--) {
            var line = lines[i];
            for (int j = 0; j < 9; j++) {
                var containerWidth = 4;
                string container;
                if (line.Length>containerWidth) {
                    container = line.Substring(0,containerWidth);
                    line = line.Substring(containerWidth, line.Length-containerWidth);
                } else {
                    container = line;
                }
                if (!string.IsNullOrWhiteSpace(container)) {
                    stacks[j].Push((container.Trim()).Substring(1,1)[0]);
                }
            }
        }

        for (int i = 10; i < lines.Count(); i++ ) {
            var line = lines[i];
            if (!string.IsNullOrWhiteSpace(line)) {
                var moves = line.Split(" ");
                int crateCount = int.Parse(moves[1].Trim());
                int fromStack = int.Parse(moves[3].Trim())-1;
                int toStack = int.Parse(moves[5].Trim())-1;
                var tmpStack = new Stack<char>();

                for (int j = 0; j < crateCount; j++) {
                    tmpStack.Push(stacks[fromStack].Pop());
                }
                for (int j = 0; j < crateCount; j++) {
                    stacks[toStack].Push(tmpStack.Pop());
                }
            }
        }

        var text = "";
        for (int i = 0; i < 9; i++) {
            text += stacks[i].Peek();
        }
        Console.WriteLine(text);
    }
}
