namespace adventofcode2022;

public class Day6 {
    private static readonly string _INPUT_FILE = "./input/day6.input";

    public static void p1() {
        var lines = File.ReadAllLines(_INPUT_FILE);
        foreach (var line in lines) {
            if (!string.IsNullOrWhiteSpace(line)) {
                void Func() {
                    for (int i = 0; i < line.Count()-4; i++) {
                        var str0 = line.Substring(i,4);

                        bool CheckString(string str) {
                            for (int j = 0; j < 3; j++) {
                                for (int x = 1; x < 4-j; x++) {
                                    if ((str[j] == str[j+x])) {
                                        return false;
                                    }
                                }
                            }
                            return true;
                        }
                        if (CheckString(str0)) {
                            Console.WriteLine(str0 + "-" + (i + 4));
                            return;
                        }
                    }
                }
                Func();
            }
        }
    }
    
    public static void p2() {
        var lines = File.ReadAllLines(_INPUT_FILE);
        var length = 14;
        foreach (var line in lines) {
            if (!string.IsNullOrWhiteSpace(line)) {
                void Func() {
                    for (int i = 0; i < line.Count()-length; i++) {
                        var str0 = line.Substring(i,length);

                        bool CheckString(string str) {
                            for (int j = 0; j < length-1; j++) {
                                for (int x = 1; x < length-j; x++) {
                                    if ((str[j] == str[j+x])) {
                                        return false;
                                    }
                                }
                            }
                            return true;
                        }
                        if (CheckString(str0)) {
                            Console.WriteLine(str0 + "-" + (i + length));
                            return;
                        }
                    }
                }
                Func();
            }
        }
    }
}