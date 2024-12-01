using System.Text.RegularExpressions;

#region Part 1
var inputListLeft = new List<int>();
var inputListRight = new List<int>();
var diffSum = 0;

// open list
using (var reader = new StreamReader("InputList.txt")) {
    // list is two ints separated by three spaces
    var pattern = @"^(\d+)\s\s\s(\d+)$";
    var line = reader.ReadLine();
    Console.WriteLine($"Read {line}");

    while (!string.IsNullOrEmpty(line)) {
        var matches = Regex.Matches(line, pattern);
        // add our matches
        inputListLeft.Add(int.Parse(matches[0].Groups[1].Value));
        inputListRight.Add(int.Parse(matches[0].Groups[2].Value));
        line = reader.ReadLine();
        Console.WriteLine($"Read {line}");
    }
}

Console.WriteLine("Sorting lists");
inputListLeft.Sort();
inputListRight.Sort();

// lists are equal length, don't need to Max() the two of them
for (var i = 0; i < inputListLeft.Count; i++) {
    // use absolute value to negate left or right being larger and handling negative values
    var diff = Math.Abs(inputListLeft[i] - inputListRight[i]);
    diffSum += diff;
    Console.WriteLine($"Total Diff: {diffSum} | Added Diff: {diff} | Left Value: {inputListLeft[i]} | Right Value: {inputListRight[i]}");
}

Console.WriteLine($"Total Final Diff: {diffSum}");
#endregion