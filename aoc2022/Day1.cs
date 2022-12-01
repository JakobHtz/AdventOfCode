namespace adventofcode2022;

public class Day1 {
    public static void p1() {
        var lines = File.ReadAllLines("./input/day1.input");
        var sum = 0;
        var calories = new List<int>();
        foreach (var line in lines) {
            if (string.IsNullOrWhiteSpace(line)) {
                calories.Add(sum);
                sum = 0;
            } else {
                sum += int.Parse(line);
            }
        }
        calories.Add(sum);
        Console.WriteLine(calories.IndexOf(calories.Max())+1 + ", " + calories.Max());
        calories.Sort();
        var length = calories.Count;
        Console.WriteLine(calories[length-1]+calories[length-3]+calories[length-2]);
    }
}
