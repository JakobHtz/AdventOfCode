using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace adventofcode2022 {
    public class Day7 {
        private static readonly string _INPUT_FILE = "./input/day7.input";

        public static void p1() {
            var rootDir = GetDirStructure();
            var sum = 0;            
            void Func(Dir dir) {
                if (dir.GetTotalMemory() <= 100000) {
                    sum += dir.GetTotalMemory();
                }
                foreach (var next in dir.dirs) {
                    Func(next);
                }
            }
            Func(rootDir);

            Console.WriteLine(sum);
        }
        
        public static void p2() {
            var rootDir = GetDirStructure();
            var totalMemoryUsed = rootDir.GetTotalMemory();
            var totalMemory = 70_000_000;
            var memoryNeeded = 30_000_000;
            var memoryToFree = (memoryNeeded+totalMemoryUsed)-totalMemory;

            var list = new List<int>();            
            void Func(Dir dir) {
                if (dir.GetTotalMemory() >= memoryToFree) {
                    list.Add(dir.GetTotalMemory());
                }
                foreach (var next in dir.dirs) {
                    Func(next);
                }
            }
            Func(rootDir);
            list.Sort();

            Console.WriteLine(list[0]);
        }

        private static Dir GetDirStructure() {
            var lines = File.ReadAllLines(_INPUT_FILE);
            Dir rootDir = new Dir("/", null);
            Dir curDir = rootDir;

            foreach (var line in lines) {
                if (!string.IsNullOrWhiteSpace(line)) {
                    if (line.Substring(0,1) == "$") {
                        if (line.Substring(2,2)=="cd") {
                            var dirName = line.Split(" ")[2].Trim();

                            if (dirName == "..") {
                                curDir = curDir.previousDir;
                            } else if (dirName == "/") {
                                curDir = rootDir;
                            } else {
                                var newDir = new Dir(dirName, curDir);
                                curDir.dirs.Add(newDir);
                                curDir = newDir;
                            }
                            continue;
                        }
                    } else if (line.Substring(0,3)=="dir") {
                        continue;
                    } else {
                        var amount = int.Parse(line.Split(" ")[0]);
                        curDir.totalMemory += amount;
                    }
                }
            }
            return rootDir;
        }
    }

    class Dir{
        public readonly string name;
        public readonly Dir previousDir;
        public int totalMemory = 0;
        public List<Dir> dirs = new List<Dir>();

        public Dir(string name, Dir previousDir) {
            this.name = name;
            this.previousDir = previousDir;
        }

        public int GetTotalMemory() {
            if (dirs.Count() > 0) {
                var sum = 0;
                foreach (var dir in dirs) {
                    sum += dir.GetTotalMemory();
                }
                return sum + totalMemory;
            }
            return totalMemory;
        }
    }
}
